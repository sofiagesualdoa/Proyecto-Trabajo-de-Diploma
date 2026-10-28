import docx
import xml.etree.ElementTree as ET

doc = docx.Document(r"scratch/Proyecto.docx")
ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}

# Map of bookmarks in body
bm_map = {}
for i, p in enumerate(doc.paragraphs):
    if i < 66:
        continue
    root = ET.fromstring(p._element.xml)
    for bm in root.findall(".//w:bookmarkStart", ns):
        name = bm.get(f"{{{ns['w']}}}name")
        if name and not name.startswith("_"):
            bm_map[name] = (i, p.text.strip())

print(f"Total bookmarks in body: {len(bm_map)}")
for k, (para_idx, text) in sorted(bm_map.items()):
    print(f"Bookmark: {k:10} | Para {para_idx:4} | Text: {text[:60]}")
