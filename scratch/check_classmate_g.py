import docx

doc = docx.Document(r"C:\Users\usuario\.gemini\antigravity\brain\6d6f5d5a-4cad-4d65-af9e-bdf70f4db580\.user_uploaded\media_1793025563617_a3f2539d.docx")
for i, p in enumerate(doc.paragraphs):
    txt = p.text.strip()
    if txt.startswith("G0") or txt.startswith("G1") or "Entrega" in txt:
        print(f"[{i}] {txt}")
