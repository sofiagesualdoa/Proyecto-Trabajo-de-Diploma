import glob
import json

new_keys = {
    "Guardar Factura de Recargo por Mora": "Guardar Factura de Recargo por Mora",
    "Guardar Factura de Préstamo": "Guardar Factura de Préstamo",
    "¡Recargo por mora cobrado exitosamente!\nN° Factura: {0}\nImporte abonado: ${1:N2}\n\nFactura emitida en:\n{2}": "¡Recargo por mora cobrado exitosamente!\nN° Factura: {0}\nImporte abonado: ${1:N2}\n\nFactura emitida en:\n{2}",
    "¡Préstamo confirmado exitosamente!\nN° Factura: {0}\nFecha Pactada de Devolución: {1:dd/MM/yyyy}\nImporte abonado: ${2:N2}\n\nFactura emitida en:\n{3}": "¡Préstamo confirmado exitosamente!\nN° Factura: {0}\nFecha Pactada de Devolución: {1:dd/MM/yyyy}\nImporte abonado: ${2:N2}\n\nFactura emitida en:\n{3}",
    "Imprimir Comprobante": "Imprimir Comprobante",
    "Seleccione un préstamo de la grilla para imprimir su comprobante.": "Seleccione un préstamo de la grilla para imprimir su comprobante.",
    "El comprobante oficial de devolución sólo puede emitirse una vez finalizado el préstamo.": "El comprobante oficial de devolución sólo puede emitirse una vez finalizado el préstamo."
}

files = glob.glob('**/traducciones.json', recursive=True)
print(f"Found {len(files)} files")

for fpath in files:
    try:
        with open(fpath, 'r', encoding='utf-8') as f:
            data = json.load(f)
        
        updated = False
        for k, v in new_keys.items():
            if k not in data:
                data[k] = v
                updated = True
        
        if updated:
            with open(fpath, 'w', encoding='utf-8') as f:
                json.dump(data, f, ensure_ascii=False, indent=2)
            print(f"Updated {fpath}")
        else:
            print(f"Already up-to-date: {fpath}")
    except Exception as e:
        print(f"Error updating {fpath}: {e}")
