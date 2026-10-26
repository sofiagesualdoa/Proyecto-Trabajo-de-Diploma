import json
import re

d = json.load(open("DAL/traducciones.json", encoding="utf-8"))
with open("Venta Productos Cosméticos/FormHistorialPrestamos.cs", encoding="utf-8") as f:
    code = f.read()

trad_calls = re.findall(r'Traducir\("((?:[^"\\]|\\.)*)"\)', code, re.DOTALL)
print(f"Total Traducir calls found: {len(trad_calls)}")

missing = []
for call in trad_calls:
    unescaped = call.replace('\\n', '\n').replace('\\"', '"')
    if unescaped not in d:
        missing.append(unescaped)

print(f"Missing count: {len(missing)}")
for m in missing:
    print("MISSING:", repr(m))
