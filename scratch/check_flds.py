import docx
import xml.etree.ElementTree as ET

doc = docx.Document(r"scratch/Proyecto.docx")
ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}

for i in range(24, 67):
    p = doc.paragraphs[i]
    root = ET.fromstring(p._element.xml)
    flds = [fc.get(f"{{{ns['w']}}}fldCharType") for fc in root.findall(".//w:fldChar", ns)]
    instrs = [it.text for it in root.findall(".//w:instrText", ns)]
    if flds or instrs or p.text.strip():
        print(f"P{i}: flds={flds}, instrs={instrs}, text={repr(p.text[:40])}")
