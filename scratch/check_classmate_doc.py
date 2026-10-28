import docx

doc = docx.Document(r"C:\Users\usuario\.gemini\antigravity\brain\6d6f5d5a-4cad-4d65-af9e-bdf70f4db580\.user_uploaded\media_1793025563617_a3f2539d.docx")
headings = []
for i, p in enumerate(doc.paragraphs):
    if p.style.name.startswith("Heading") or p.text.startswith("CU") or "Entrega" in p.text or "G0" in p.text or "G1" in p.text:
        headings.append((i, p.style.name, p.text[:80]))

print(f"Total headings found: {len(headings)}")
for h in headings[:40]:
    print(h)
