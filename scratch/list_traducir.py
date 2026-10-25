import re

files = [
    'Venta Productos Cosméticos/FormPrestamo.cs',
    'Venta Productos Cosméticos/FormPrestamo.Designer.cs',
    'Venta Productos Cosméticos/FormCobro.cs',
    'Venta Productos Cosméticos/FormCobro.Designer.cs',
    'BLL/BLLPrestamo.cs'
]

for fp in files:
    print(f"\n=== {fp} ===")
    with open(fp, 'r', encoding='utf-8', errors='replace') as f:
        lines = f.readlines()
    for idx, l in enumerate(lines, 1):
        if 'Traducir(' in l or '.Text =' in l:
            print(f"{idx}: {l.strip()}")
