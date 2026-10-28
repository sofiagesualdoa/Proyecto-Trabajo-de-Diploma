import docx
import xml.etree.ElementTree as ET

doc = docx.Document(r"scratch/Proyecto.docx")
ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}

for idx in [26, 27, 28, 29, 34, 38, 44]:
    p = doc.paragraphs[idx]
    root = ET.fromstring(p._element.xml)
    ppr = root.find("w:pPr", ns)
    print(f"P{idx}: pPr={ET.tostring(ppr).decode() if ppr is not None else 'None'}")
