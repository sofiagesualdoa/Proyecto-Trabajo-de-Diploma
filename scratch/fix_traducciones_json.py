import json, os, glob

proper_dict = {
    "Bitácora de Cambios": "Change Log",
    "Libros C": "Books C",
    "Filtros de Búsqueda": "Search Filters",
    "Historial de Cambios": "Change History",
    "Stock Venta": "Sale Stock",
    "Stock Préstamo": "Loan Stock",
    "Vigente": "Current",
    "SÍ": "YES",
    "NO": "NO",
    "Total de registros: {0}": "Total records: {0}",
    "La versión seleccionada ya es la versión activa vigente.": "The selected version is already the active version.",
    "¿Confirma restaurar el libro a la versión seleccionada del día {0} a las {1}?": "Confirm restoring the book to the selected version from {0} at {1}?",
    "Confirmar Rollback": "Confirm Rollback",
    "El libro fue restaurado exitosamente a la versión seleccionada.": "The book was successfully restored to the selected version.",
    "La fecha inicial no puede ser mayor a la fecha final.": "The start date cannot be greater than the end date."
}

base_dir = r'c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma'

# Find all traducciones.json in the solution
json_files = glob.glob(os.path.join(base_dir, '**', 'traducciones.json'), recursive=True)

for path in json_files:
    with open(path, 'r', encoding='utf-8') as f:
        data = json.load(f)
    
    fixed = 0
    for k, v in list(data.items()):
        if isinstance(v, dict):
            # Convert object to string
            en_val = v.get('en-US', list(v.values())[0])
            data[k] = en_val
            fixed += 1
    
    # Also ensure proper keys exist as strings
    for k, v in proper_dict.items():
        data[k] = v

    with open(path, 'w', encoding='utf-8') as f:
        json.dump(data, f, ensure_ascii=False, indent=2)
    print(f"Fixed {path} ({fixed} object entries corrected).")
