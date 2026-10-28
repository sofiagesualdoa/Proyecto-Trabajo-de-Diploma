import docx

doc = docx.Document(r"C:\Users\usuario\.gemini\antigravity\brain\6d6f5d5a-4cad-4d65-af9e-bdf70f4db580\.user_uploaded\media_1793025563617_a3f2539d.docx")
for i, table in enumerate(doc.tables):
    txt = "\n".join(["\t".join([c.text.strip().replace("\n", " ") for c in row.cells]) for row in table.rows])
    if "Serializ" in txt or "serializ" in txt:
        print(f"=== Table {i} ===")
        print(txt[:1000])
