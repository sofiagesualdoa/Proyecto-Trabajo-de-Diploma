import docx
import xml.etree.ElementTree as ET

doc = docx.Document(r"scratch/Proyecto.docx")

print("=== PARAGRAPHS 24 TO 66 ===")
for i in range(24, 67):
    p = doc.paragraphs[i]
    xml = p._element.xml
    # find all instrText
    root = ET.fromstring(xml)
    ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}
    instrs = [node.text for node in root.findall(".//w:instrText", ns)]
    print(f"P{i}: text={repr(p.text)}")
    if instrs:
        print(f"     hyperlinks={instrs}")
