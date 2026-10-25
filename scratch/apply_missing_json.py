import json

with open('scratch/missing_final.json', 'r', encoding='utf-8') as f:
    missing = json.load(f)

files = ['DAL/traducciones.json', 'Servicios/traducciones.json']

for path in files:
    with open(path, 'r', encoding='utf-8') as f:
        data = json.load(f)
    for k, v in missing.items():
        if k not in data:
            data[k] = v
    with open(path, 'w', encoding='utf-8') as f:
        json.dump(data, f, ensure_ascii=False, indent=2)
    print(f'Updated {path} with {len(missing)} missing keys')
