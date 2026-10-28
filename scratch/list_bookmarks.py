import docx
import xml.etree.ElementTree as ET

doc = docx.Document(r"scratch/Proyecto.docx")
bookmarks = {}
ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}

for i, p in enumerate(doc.paragraphs):
    root = ET.fromstring(p._element.xml)
    for bm in root.findall(".//w:bookmarkStart", ns):
        name = bm.get(f"{{{ns['w']}}}name")
        if name and not name.startswith("_"):
            bookmarks[name] = (i, p.text.strip()[:60])

print(f"Total user bookmarks found: {len(bookmarks)}")
for k, v in sorted(bookmarks.items()):
    print(f"{k} -> P{v[0]}: {v[1]}")
