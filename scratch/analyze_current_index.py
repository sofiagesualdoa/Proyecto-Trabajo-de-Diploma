import docx
import xml.etree.ElementTree as ET

doc = docx.Document(r"scratch/Proyecto.docx")
ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}

# Find all bookmarks and their paragraph text
bm_to_para = {}
for i, p in enumerate(doc.paragraphs):
    root = ET.fromstring(p._element.xml)
    for bm in root.findall(".//w:bookmarkStart", ns):
        name = bm.get(f"{{{ns['w']}}}name")
        if name and not name.startswith("_"):
            bm_to_para[name] = (i, p.text.strip())

# Find what paragraphs 24 to 65 currently contain
print("=== CURRENT INDEX PARAGRAPHS (P24 to P66) ===")
for i in range(24, 67):
    p = doc.paragraphs[i]
    print(f"P{i} [ind={p.paragraph_format.left_indent}, first_line={p.paragraph_format.first_line_indent}]: {repr(p.text)}")
