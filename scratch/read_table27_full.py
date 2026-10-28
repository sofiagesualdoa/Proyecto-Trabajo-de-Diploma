import docx

doc = docx.Document(r"C:\Users\usuario\.gemini\antigravity\brain\6d6f5d5a-4cad-4d65-af9e-bdf70f4db580\.user_uploaded\media_1793025563617_a3f2539d.docx")
table = doc.tables[27]
for r in table.rows:
    row_txt = [c.text.strip().replace("\n", " ") for c in r.cells]
    print(" | ".join(row_txt))
