import re
import json

def extract_strings(filepath):
    with open(filepath, 'r', encoding='utf-8', errors='replace') as f:
        text = f.read()

    traducir_matches = []
    # Match Traducir("...") or Traducir(@"...")
    # Note: also handle string concatenation like Traducir("line1" + "line2")
    pattern = r'Traducir\s*\(\s*(?:string\.Format\s*\(\s*)?(@?"(?:[^"\\]|\\.)*")'
    for m in re.finditer(pattern, text):
        raw = m.group(1)
        if raw.startswith('@"'):
            val = raw[2:-1].replace('""', '"')
        else:
            val = raw[1:-1].replace('\\n', '\n').replace('\\r', '\r').replace('\\t', '\t').replace('\\"', '"').replace('\\\\', '\\')
        traducir_matches.append(val)

    text_matches = []
    text_pattern = r'\.Text\s*=\s*(@?"(?:[^"\\]|\\.)*")\s*;'
    for m in re.finditer(text_pattern, text):
        raw = m.group(1)
        if raw.startswith('@"'):
            val = raw[2:-1].replace('""', '"')
        else:
            val = raw[1:-1].replace('\\n', '\n').replace('\\r', '\r').replace('\\t', '\t').replace('\\"', '"').replace('\\\\', '\\')
        text_matches.append(val)

    return traducir_matches, text_matches

with open('DAL/traducciones.json', 'r', encoding='utf-8') as f:
    existing = json.load(f)

files = [
    'Venta Productos Cosméticos/FormPrestamo.cs',
    'Venta Productos Cosméticos/FormPrestamo.Designer.cs',
    'Venta Productos Cosméticos/FormCobro.cs',
    'Venta Productos Cosméticos/FormCobro.Designer.cs',
    'BLL/BLLPrestamo.cs'
]

results = {}
for fp in files:
    trads, texts = extract_strings(fp)
    results[fp] = {'trads': trads, 'texts': texts}

all_keys = set()
for fp, d in results.items():
    for item in d['trads'] + d['texts']:
        if item and not item.startswith('label') and not item.startswith('Form') and not item.startswith('$') and not item.startswith('{'):
            all_keys.add(item)

missing = {}
found = {}
for k in sorted(all_keys):
    if k in existing:
        found[k] = existing[k]
    else:
        missing[k] = None

out = {
    'existing_count': len(found),
    'missing_count': len(missing),
    'missing_keys': list(missing.keys()),
    'found_keys': found
}

with open('scratch/analysis_keys.json', 'w', encoding='utf-8') as f:
    json.dump(out, f, ensure_ascii=False, indent=2)

print(f"Total keys: {len(all_keys)}, existing: {len(found)}, missing: {len(missing)}")
