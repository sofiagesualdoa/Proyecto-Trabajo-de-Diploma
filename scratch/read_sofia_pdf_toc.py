import pypdf

reader = pypdf.PdfReader("Proyecto.pdf")
print("Total pages:", len(reader.pages))

# Look at pages 1 to 15 (Index/TOC)
for i in range(min(15, len(reader.pages))):
    txt = reader.pages[i].extract_text() or ""
    first_lines = [l.strip() for l in txt.split("\n") if l.strip()][:5]
    print(f"Page {i+1}: {first_lines}")
