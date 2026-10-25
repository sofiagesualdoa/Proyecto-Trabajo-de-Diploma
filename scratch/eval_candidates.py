import json

with open('DAL/traducciones.json', 'r', encoding='utf-8') as f:
    t = json.load(f)

# Explicit list of all user-facing strings in FormPrestamo, FormCobro, and BLLPrestamo:
candidates = [
    # FormPrestamo controls / UI
    ("Nuevo Préstamo", "New Loan"),
    ("Seleccionar Libro", "Select Book"),
    ("Pagar", "Pay"),
    ("Quitar Libro", "Remove Book"),
    ("Limpiar", "Clear"),
    ("Consultar", "Search"),
    ("Salir", "Exit"),
    ("Buscar por Título, Autor, ISBN...", "Search by Title, Author, ISBN..."),

    # FormPrestamo dialogs & validations
    ("Debe seleccionar un libro de la lista para solicitar el préstamo.", "You must select a book from the list to request the loan."),
    ("Aviso", "Notice"),
    ("El ejemplar seleccionado no cuenta con disponibilidad para préstamo.", "The selected copy is not available for loan."),
    ("¿Desea solicitar el préstamo del libro '{0}'?", "Do you want to request the loan of the book '{0}'?"),
    ("Confirmar Libro", "Confirm Book"),
    ("Ingrese la cantidad de días del préstamo:", "Enter the number of loan days:"),
    ("Duración del Préstamo", "Loan Duration"),
    ("La cantidad de días debe ser un número entero mayor a cero.", "The number of days must be an integer greater than zero."),
    ("Ingrese el DNI del cliente solicitante:", "Enter the customer ID of the applicant:"),
    ("Asociar Cliente", "Associate Customer"),
    ("El DNI debe ser numérico y mayor a cero.", "The ID must be numeric and greater than zero."),
    ("El cliente con DNI {0} no se encuentra registrado en el sistema.\n\n¿Desea registrarlo ahora?", "The customer with ID {0} is not registered in the system.\n\nDo you want to register them now?"),
    ("Cliente No Encontrado", "Customer Not Found"),
    ("El cliente se encuentra dado de baja en el sistema.", "The customer is inactive in the system."),
    ("Resumen de la Solicitud de Préstamo:\n\nLibro: {0}\nCliente: {1} {2} (DNI: {3})\nDuración: {4} días\nFecha pactada de devolución: {5:dd/MM/yyyy}\nTotal a abonar: ${6:N2}\n\n¿Desea continuar al cobro?",
     "Loan Request Summary:\n\nBook: {0}\nCustomer: {1} {2} (ID: {3})\nDuration: {4} days\nAgreed return date: {5:dd/MM/yyyy}\nTotal to pay: ${6:N2}\n\nDo you want to proceed to payment?"),
    ("Confirmar Préstamo", "Confirm Loan"),

    # FormCobro controls / UI
    ("Pago", "Payment"),
    ("Cliente:", "Customer:"),
    ("Total:", "Total:"),
    ("Tarjeta de Débito", "Debit Card"),
    ("Tarjeta de Crédito", "Credit Card"),
    ("Medio de Pago:", "Payment Method:"),
    ("Banco", "Bank"),
    ("N° de tarjeta", "Card Number"),
    ("Titular", "Cardholder"),
    ("Vencimiento", "Expiration Date"),
    ("CVV", "CVV"),
    ("Cancelar", "Cancel"),
    ("Confirmar Pago", "Confirm Payment"),

    # FormCobro messages
    ("¡Venta confirmada exitosamente!\nN° Factura: {0}\nImporte abonado: ${1:N2}", "Sale successfully confirmed!\nInvoice No: {0}\nAmount paid: ${1:N2}"),
    ("¡Recargo por mora cobrado exitosamente!\nN° Factura: {0}\nImporte abonado: ${1:N2}", "Late fee successfully charged!\nInvoice No: {0}\nAmount paid: ${1:N2}"),
    ("¡Préstamo confirmado exitosamente!\nN° Factura: {0}\nFecha Pactada de Devolución: {1:dd/MM/yyyy}\nImporte abonado: ${2:N2}", "Loan successfully confirmed!\nInvoice No: {0}\nAgreed Return Date: {1:dd/MM/yyyy}\nAmount paid: ${2:N2}"),
    ("Éxito", "Success"),
    ("Error de Pago", "Payment Error"),

    # BLLPrestamo domain exceptions
    ("El cliente especificado no existe o no se encuentra activo.", "The specified customer does not exist or is not active."),
    ("El cliente ya posee un préstamo activo vigente. No puede solicitar otro hasta devolver el ejemplar adeudado.", "The customer already has an active loan. Cannot request another until returning the pending copy."),
    ("El libro especificado no se encuentra en el catálogo de préstamos.", "The specified book is not found in the loan catalogue."),
    ("La fecha de devolución pactada debe ser posterior al día de hoy.", "The agreed return date must be after today."),
    ("No hay ninguna solicitud de préstamo para cobrar.", "There is no loan request to charge."),
    ("El DNI ingresado no corresponde a ningún cliente registrado en el sistema.", "The entered ID does not correspond to any registered customer in the system."),
    ("El cliente no posee ningún préstamo activo pendiente de devolución.", "The customer does not have any active loan pending return."),
    ("No existe recargo por mora para cobrar en esta devolución.", "There is no late fee surcharge to charge on this return."),
    ("Debe seleccionar un préstamo válido para registrar la devolución.", "You must select a valid loan to record the return.")
]

missing = {}
present = {}
for k, v in candidates:
    if k in t:
        present[k] = t[k]
    else:
        missing[k] = v

print(f"Total evaluated: {len(candidates)}")
print(f"Already present: {len(present)}")
print(f"Missing: {len(missing)}")

with open('scratch/missing_final.json', 'w', encoding='utf-8') as f:
    json.dump(missing, f, ensure_ascii=False, indent=2)
