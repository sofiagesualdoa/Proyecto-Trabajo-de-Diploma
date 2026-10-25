import json
import re

with open('DAL/traducciones.json', 'r', encoding='utf-8') as f:
    existing_translations = json.load(f)

files = [
    'Venta Productos Cosméticos/FormPrestamo.cs',
    'Venta Productos Cosméticos/FormPrestamo.Designer.cs',
    'Venta Productos Cosméticos/FormCobro.cs',
    'Venta Productos Cosméticos/FormCobro.Designer.cs',
    'BLL/BLLPrestamo.cs'
]

keys_found = set()

# Pattern for session.Traducir(...) or s.Traducir(...)
traducir_regex = re.compile(r'(?:session|s|ServicioSessionManager\.GetInstance\(\))\s*\.\s*Traducir\s*\(\s*@"([^"]*)"', re.DOTALL)
traducir_regex_simple = re.compile(r'(?:session|s|ServicioSessionManager\.GetInstance\(\))\s*\.\s*Traducir\s*\(\s*"((?:\\.|[^"\\])*)"\)', re.DOTALL)

# In designer, controls have .Text = "..."
text_regex = re.compile(r'\.Text\s*=\s*"((?:\\.|[^"\\])*)"\s*;')

for fpath in files:
    with open(fpath, 'r', encoding='utf-8', errors='ignore') as fp:
        content = fp.read()
    
    for m in text_regex.finditer(content):
        t = m.group(1).encode('utf-8').decode('unicode_escape')
        if t and not t.startswith('label') and not t.startswith('Form'):
            keys_found.add(t)

    for m in traducir_regex_simple.finditer(content):
        t = m.group(1).encode('utf-8').decode('unicode_escape')
        keys_found.add(t)

# Also check for multi-line string.Format with Traducir
# Let's inspect raw occurrences
for k in sorted(keys_found):
    in_dict = k in existing_translations
    print(f"[{'EXISTS' if in_dict else 'MISSING'}] {k}")
