import docx

doc = docx.Document(r"scratch/Proyecto.docx")

for i in range(26, 36):
    p = doc.paragraphs[i]
    print(f"P{i} [{p.style.name}]: text={repr(p.text)}")
    for r in p.runs:
        print(f"   run text={repr(r.text)}, font={r.font.name}, size={r.font.size}, color={r.font.color.rgb if r.font.color else None}, underline={r.font.underline}, rStyle={r.style.name if r.style else None}")
