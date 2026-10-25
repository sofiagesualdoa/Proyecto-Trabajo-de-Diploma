import json

keys_to_add = {
    "Historial de Préstamos": "Loan History",
    "Préstamos Registrados": "Registered Loans",
    "Detalle del Préstamo Seleccionado": "Selected Loan Details",
    "Total Préstamos:": "Total Loans:",
    "ID Préstamo": "Loan ID",
    "Monto Préstamo": "Loan Amount",
    "Monto Recargo": "Surcharge Amount",
    "Fecha Inicio": "Start Date",
    "Fecha Devolución": "Return Date",
    "Fecha Real Devolución": "Actual Return Date",
    "Seleccione un préstamo para visualizar sus detalles.": "Select a loan to view its details."
}

files = ['DAL/traducciones.json', 'Servicios/traducciones.json']

for path in files:
    with open(path, 'r', encoding='utf-8') as f:
        data = json.load(f)
    for k, v in keys_to_add.items():
        if k not in data:
            data[k] = v
    with open(path, 'w', encoding='utf-8') as f:
        json.dump(data, f, ensure_ascii=False, indent=2)
    print(f'Updated {path}')
