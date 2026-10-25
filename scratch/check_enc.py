with open('Venta Productos Cosméticos/FormPrestamo.cs', 'rb') as f:
    raw = f.read()
# Let's check how it's encoded: UTF-8 with BOM, UTF-8, or CP1252
for enc in ['utf-8-sig', 'utf-8', 'cp1252', 'latin1']:
    try:
        decoded = raw.decode(enc)
        print(f"Decoded with {enc}: success")
        # Let's check a sample line
        for l in decoded.splitlines():
            if 'Traducir("Buscar' in l or 'Traducir("Ingrese' in l:
                print(f"   {l.strip()}")
        break
    except Exception as e:
        print(f"Failed {enc}: {e}")
