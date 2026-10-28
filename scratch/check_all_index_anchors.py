import docx
import xml.etree.ElementTree as ET

doc = docx.Document(r"scratch/Proyecto.docx")
ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}

print("=== P24 to P66 Hyperlink Analysis ===")
for i in range(24, 67):
    p = doc.paragraphs[i]
    root = ET.fromstring(p._element.xml)
    
    # Check for w:hyperlink
    hl_anchors = [h.get(f"{{{ns['w']}}}anchor") for h in root.findall(".//w:hyperlink", ns)]
    
    # Check for instrText HYPERLINK
    instrs = [it.text.strip() for it in root.findall(".//w:instrText", ns) if "HYPERLINK" in it.text]
    
    # Extract all text in order
    all_text = "".join(node.text for node in root.findall(".//w:t", ns) if node.text)
    
    print(f"P{i:02d}: text={repr(all_text[:50])}")
    if hl_anchors:
        print(f"     w:hyperlink anchor={hl_anchors}")
    if instrs:
        print(f"     field instr={instrs}")
