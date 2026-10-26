import json

new_translations = {
    "Registrar Devolución": "Register Return",
    "Debe seleccionar un préstamo de la lista para registrar la devolución.": "You must select a loan from the list to register the return.",
    "Solo es posible registrar la devolución de préstamos con estado 'Activo'.": "It is only possible to register the return of loans with 'Active' status.",
    "¿Confirma la recepción del ejemplar físico en buen estado y el registro de la devolución para el préstamo #{0}?\n\nLibro: {1}\nCliente: {2} (DNI: {3})": "Do you confirm receipt of the physical copy in good condition and the return registration for loan #{0}?\n\nBook: {1}\nCustomer: {2} (ID: {3})",
    "Confirmar Devolución": "Confirm Return",
    "El préstamo presenta {0} día(s) de demora respecto a la fecha pactada ({1:dd/MM/yyyy}).\n\nSe ha calculado un recargo por mora de ${2:N2}.\n\n¿Desea proceder al cobro del recargo con tarjeta para continuar con la devolución?": "The loan has {0} day(s) of delay with respect to the agreed date ({1:dd/MM/yyyy}).\n\nA late fee of ${2:N2} has been calculated.\n\nDo you want to proceed to charge the surcharge with card to continue with the return?",
    "Recargo por Mora": "Late Fee Surcharge",
    "No se pudo completar la devolución debido a que el recargo por mora no fue abonado.": "The return could not be completed because the late fee was not paid.",
    "Operación Cancelada": "Operation Cancelled",
    "Guardar Comprobante de Devolución": "Save Return Receipt",
    "¡Devolución registrada exitosamente!\n\nEstado final del préstamo: {0}\nEjemplar reincorporado al catálogo de préstamos.\nComprobante emitido en:\n{1}": "Return registered successfully!\n\nFinal loan status: {0}\nCopy returned to the loan catalogue.\nReceipt issued at:\n{1}"
}

files = ['DAL/traducciones.json', 'Servicios/traducciones.json']

for path in files:
    with open(path, 'r', encoding='utf-8') as f:
        data = json.load(f)
    for k, v in new_translations.items():
        data[k] = v
    with open(path, 'w', encoding='utf-8') as f:
        json.dump(data, f, ensure_ascii=False, indent=2)
    print(f'Updated {path} with {len(new_translations)} keys')
