import json

new_translations = {
    "Bitácora de Cambios": {
        "es-ES": "Bitácora de Cambios",
        "en-US": "Change Log"
    },
    "Libros C": {
        "es-ES": "Libros C",
        "en-US": "Books C"
    },
    "Filtros de Búsqueda": {
        "es-ES": "Filtros de Búsqueda",
        "en-US": "Search Filters"
    },
    "Historial de Cambios": {
        "es-ES": "Historial de Cambios",
        "en-US": "Change History"
    },
    "Stock Venta": {
        "es-ES": "Stock Venta",
        "en-US": "Sale Stock"
    },
    "Stock Préstamo": {
        "es-ES": "Stock Préstamo",
        "en-US": "Loan Stock"
    },
    "Vigente": {
        "es-ES": "Vigente",
        "en-US": "Current"
    },
    "SÍ": {
        "es-ES": "SÍ",
        "en-US": "YES"
    },
    "NO": {
        "es-ES": "NO",
        "en-US": "NO"
    },
    "Total de registros: {0}": {
        "es-ES": "Total de registros: {0}",
        "en-US": "Total records: {0}"
    },
    "La versión seleccionada ya es la versión activa vigente.": {
        "es-ES": "La versión seleccionada ya es la versión activa vigente.",
        "en-US": "The selected version is already the active version."
    },
    "¿Confirma restaurar el libro a la versión seleccionada del día {0} a las {1}?": {
        "es-ES": "¿Confirma restaurar el libro a la versión seleccionada del día {0} a las {1}?",
        "en-US": "Confirm restoring the book to the selected version from {0} at {1}?"
    },
    "Confirmar Rollback": {
        "es-ES": "Confirmar Rollback",
        "en-US": "Confirm Rollback"
    },
    "El libro fue restaurado exitosamente a la versión seleccionada.": {
        "es-ES": "El libro fue restaurado exitosamente a la versión seleccionada.",
        "en-US": "The book was successfully restored to the selected version."
    },
    "La fecha inicial no puede ser mayor a la fecha final.": {
        "es-ES": "La fecha inicial no puede ser mayor a la fecha final.",
        "en-US": "The start date cannot be greater than the end date."
    }
}

paths = [
    r'c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\DAL\traducciones.json',
    r'c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\Servicios\traducciones.json'
]

for p in paths:
    with open(p, 'r', encoding='utf-8') as f:
        data = json.load(f)
    
    added = 0
    for key, val in new_translations.items():
        if key not in data:
            data[key] = val
            added += 1
    
    with open(p, 'w', encoding='utf-8') as f:
        json.dump(data, f, ensure_ascii=False, indent=2)
    print(f"Updated {p}: added {added} new keys.")
