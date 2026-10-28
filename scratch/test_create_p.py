import docx
from docx.oxml import OxmlElement
from docx.oxml.ns import qn
import xml.etree.ElementTree as ET

def create_index_paragraph(text, anchor, level=0):
    p = OxmlElement('w:p')
    pPr = OxmlElement('w:pPr')
    if level == 1:
        ind = OxmlElement('w:ind')
        ind.set(qn('w:firstLine'), '720')
        pPr.append(ind)
    elif level == 2:
        ind = OxmlElement('w:ind')
        ind.set(qn('w:firstLine'), '1440')
        pPr.append(ind)
    
    p_rPr = OxmlElement('w:rPr')
    rStyle = OxmlElement('w:rStyle')
    rStyle.set(qn('w:val'), 'Hipervnculo')
    p_rPr.append(rStyle)
    pPr.append(p_rPr)
    p.append(pPr)
    
    hl = OxmlElement('w:hyperlink')
    hl.set(qn('w:anchor'), anchor)
    hl.set(qn('w:history'), '1')
    
    r = OxmlElement('w:r')
    rPr = OxmlElement('w:rPr')
    rStyle_r = OxmlElement('w:rStyle')
    rStyle_r.set(qn('w:val'), 'Hipervnculo')
    rPr.append(rStyle_r)
    color = OxmlElement('w:color')
    color.set(qn('w:val'), '1155CC')
    rPr.append(color)
    u = OxmlElement('w:u')
    u.set(qn('w:val'), 'single')
    rPr.append(u)
    r.append(rPr)
    
    t = OxmlElement('w:t')
    t.text = text
    r.append(t)
    
    hl.append(r)
    p.append(hl)
    return p

p = create_index_paragraph("N01.PN1.Gestión de ventas en tienda física", "n01pn1", level=1)
xml_str = ET.tostring(p).decode()
print("Generated XML:")
print(xml_str)
