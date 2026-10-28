import pypdf

reader = pypdf.PdfReader("Proyecto.pdf")
print("Total pages:", len(reader.pages))
for page_num in range(210, len(reader.pages)+1):
    txt = reader.pages[page_num-1].extract_text()
    lines = [l.strip() for l in txt.split("\n") if l.strip()]
    header = lines[5:7] if len(lines) > 6 else lines
    print(f"Page {page_num}: {header}")
