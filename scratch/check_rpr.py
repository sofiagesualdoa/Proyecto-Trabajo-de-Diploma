import docx
import xml.etree.ElementTree as ET

doc = docx.Document(r"scratch/Proyecto.docx")
ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}

# Let's inspect paragraphs 26 and 34 rPr
for idx in [26, 29, 34, 44]:
    p = doc.paragraphs[idx]
    print(f"P{idx}:")
    root = ET.fromstring(p._element.xml)
    for r in root.findall(".//w:r", ns):
        rpr = r.find("w:rPr", ns)
        rpr_str = ET.tostring(rpr).decode() if rpr is not None else "None"
        t = r.find("w:t", ns)
        t_text = t.text if t is not None else ""
        print(f"   text={repr(t_text)} | rPr={rpr_str}")
