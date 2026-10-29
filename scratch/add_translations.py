import glob
import json

new_translations = {
    "Serializar": "Serialize",
    "Des Serializar": "Deserialize",
    "Actualizar": "Refresh",
    "Confirmar Serialización": "Confirm Serialization",
    "Confirmar Des-serialización": "Confirm Deserialization",
    "No hay clientes en la grilla para serializar.": "There are no clients in the grid to serialize.",
    "Serialización realizada con éxito.": "Serialization completed successfully.",
    "Des-serialización realizada con éxito.": "Deserialization completed successfully.",
    "Matriz de datos actualizada con los registros actuales de la base de datos.": "Data matrix refreshed with current database records.",
    "Seleccionar destino para serializar clientes": "Select destination to serialize clients",
    "Seleccionar archivo XML de clientes para des-serializar": "Select clients XML file to deserialize"
}

files = glob.glob('**/traducciones.json', recursive=True)
print(f"Found {len(files)} traducciones.json files")

for f in files:
    with open(f, 'r', encoding='utf-8') as fp:
        d = json.load(fp)
    
    # Ensure flat strings
    for k, v in new_translations.items():
        if k not in d:
            d[k] = v
            
    with open(f, 'w', encoding='utf-8') as fp:
        json.dump(d, fp, ensure_ascii=False, indent=2)

print("Updated all traducciones.json files cleanly!")
