import pypdf

reader = pypdf.PdfReader("Proyecto.pdf")
for page_num in [2, 3, 4, 5, 6, 7]:
    txt = reader.pages[page_num-1].extract_text()
    print(f"--- PAGE {page_num} ---")
    lines = [l.strip() for l in txt.split("\n") if l.strip()]
    for l in lines[5:25]:
        print(" ", l)
