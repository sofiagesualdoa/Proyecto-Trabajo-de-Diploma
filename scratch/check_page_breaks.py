import docx

doc = docx.Document(r"scratch/Proyecto.docx")
for i in range(70):
    p = doc.paragraphs[i]
    xml = p._element.xml
    if "lastRenderedPageBreak" in xml or "w:br" in xml or "pageBreakBefore" in xml:
        print(f"P{i} [text={repr(p.text[:30])}]: page break feature found")
