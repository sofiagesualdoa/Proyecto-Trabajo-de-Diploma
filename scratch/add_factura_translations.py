import glob
import json

new_translations = {
    "Imprimir Factura": "Print Invoice",
    "Guardar Factura de Venta": "Save Sales Invoice",
    "Factura emitida exitosamente en:\n{0}": "Invoice issued successfully in:\n{0}",
    "Seleccione una venta de la grilla para imprimir su factura.": "Select a sale from the grid to print its invoice.",
    "¡Venta confirmada exitosamente!\nN° Factura: {0}\nImporte abonado: ${1:N2}\n\nFactura emitida en:\n{2}": "Sale confirmed successfully!\nInvoice No: {0}\nAmount paid: ${1:N2}\n\nInvoice issued in:\n{2}"
}

files = glob.glob('**/traducciones.json', recursive=True)
for f in files:
    with open(f, 'r', encoding='utf-8') as fp:
        d = json.load(fp)
    for k, v in new_translations.items():
        if k not in d:
            d[k] = v
    with open(f, 'w', encoding='utf-8') as fp:
        json.dump(d, fp, ensure_ascii=False, indent=2)

print("Updated all traducciones.json files with invoice translations!")
