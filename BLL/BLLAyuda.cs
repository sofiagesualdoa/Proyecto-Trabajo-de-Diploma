using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLAyuda
    {
        private static readonly List<BEItemAyuda> catalogoAyuda = new List<BEItemAyuda>
        {
            new BEItemAyuda
            {
                ClaveModulo = "FormInicioSesion",
                TituloModulo = "Inicio de Sesión y Autenticación",
                Objetivo = "Validar la identidad del usuario en el sistema Bookly mediante credenciales seguras (nombre de usuario y contraseña).",
                Pasos = "1. Ingrese su identificador en el campo 'Usuario'.\n2. Ingrese su contraseña secreta en el campo 'Contraseña' (los caracteres permanecen enmascarados).\n3. Presione el botón 'Ingresar' o pulse la tecla Enter en su teclado.\n4. Si los datos son correctos, se habilitará el menú principal del sistema. De lo contrario, se indicará el motivo del rechazo.",
                ControlesAtajos = "• Tecla Enter: Ejecuta la acción de inicio de sesión.\n• Tecla Esc: Cancela el ingreso o cierra la ventana.\n• Tecla F1: Despliega este panel de ayuda contextual.\n• Botón Ingresar: Procesa la autenticación del usuario.",
                ReglasSeguridad = "• Política de Bloqueo: Tras tres (3) intentos fallidos consecutivos de ingreso con contraseña incorrecta, la cuenta se bloquea automáticamente por seguridad.\n• Seguridad Criptográfica: Las contraseñas se almacenan mediante hash criptográfico unidireccional SHA-256 en la base de datos."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormSistema",
                TituloModulo = "Menú Principal y Navegación del Sistema",
                Objetivo = "Proporcionar acceso estructurado a todos los módulos funcionales de Bookly según la matriz de permisos RBAC del usuario activo.",
                Pasos = "1. Despliegue los menús superiores: 'Ventas', 'Inventario', 'Reportes', 'Administración', 'Usuario' y 'Ayuda'.\n2. Haga clic en la funcionalidad deseada para abrir la pantalla correspondiente.\n3. Desde el menú 'Usuario' puede cambiar su idioma preferido o modificar su clave personal.\n4. Desde el menú 'Ayuda' puede acceder a este Centro de Ayuda, al Manual de Usuario completo en PDF o a la Guía de Instalación.",
                ControlesAtajos = "• Tecla F1: Abre la Ayuda Contextual del sistema.\n• Menú Ventas: Nueva Venta, Historial de Ventas, Historial de Préstamos.\n• Menú Inventario: Catálogo de Libros, Préstamo de Libros, Historial de Modificaciones.\n• Menú Reportes: Reporte Inteligente (restringido a Gerente).\n• Menú Administración: Usuarios, Perfiles, Bitácora, BackUp y Restore.",
                ReglasSeguridad = "• Control de Acceso RBAC: Las opciones del menú se habilitan o inhabilitan en función de los permisos otorgados al perfil autenticado (Vendedor, Gerente, Administrador).\n• Cierre Seguro: Utilice la opción 'Cerrar Sesión' antes de abandonar la terminal de trabajo para registrar la finalización en bitácora."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormClientes",
                TituloModulo = "Gestión de Clientes y Protección de Datos",
                Objetivo = "Registrar, modificar, consultar y auditar la información personal y de contacto de los clientes y socios de la librería.",
                Pasos = "1. Para dar de alta un cliente: Ingrese DNI, Nombre, Apellido, Teléfono, Correo Electrónico y Dirección particular. Luego presione 'Guardar'.\n2. Para modificar: Localice al cliente en la grilla inferior haciendo clic sobre la fila, edite los campos deseados y presione 'Guardar'.\n3. Para buscar: Utilice los filtros rápidos por DNI o Apellido para acotar el listado de resultados.\n4. Para reiniciar el formulario: Presione 'Limpiar' para dejar los campos en blanco.",
                ControlesAtajos = "• Botón Guardar: Da de alta o actualiza los datos del cliente seleccionado.\n• Botón Limpiar: Limpia los campos de texto para una nueva carga.\n• Botón Salir: Regresa al menú principal o a la pantalla de origen.\n• Tecla F1: Muestra esta ayuda contextual.",
                ReglasSeguridad = "• Encriptación Reversible AES-256: El campo Dirección se encuentra cifrado en la base de datos con algoritmo AES-256 CBC y validación HMAC-SHA256.\n• Privilegio Exclusivo de Gerencia: Solo el perfil Gerente (IdPerfil = 8) puede visualizar la dirección desencriptada en texto claro. Para Vendedores y Administradores se muestra enmascarado como '[Dato Protegido - Solo Gerente]'."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormLibros",
                TituloModulo = "Catálogo de Libros e Inventario",
                Objetivo = "Administrar el catálogo bibliográfico y gestionar las existencias diferenciadas de stock para venta directa y para préstamos.",
                Pasos = "1. Alta de Libro: Complete ISBN (código de 13 dígitos), Título, Autor, Editorial, Género Literario, Precio ($), Stock de Venta y Stock de Préstamos. Presione 'Guardar'.\n2. Edición de Libro: Seleccione una obra de la grilla, modifique sus datos o precios y guarde los cambios.\n3. Reposición de Stock: Seleccione el libro en la grilla, digite en el campo de reposición la cantidad de ejemplares a ingresar y presione 'Reponer Stock'.\n4. Filtros: Puede buscar por ISBN, Título, Autor o Editorial en los cuadros de búsqueda superiores.",
                ControlesAtajos = "• Botón Guardar: Persiste las modificaciones o el alta del libro.\n• Botón Reponer Stock: Suma unidades al stock del libro seleccionado.\n• Doble clic en Grilla: Carga los datos del libro en el formulario de edición.\n• Tecla F1: Despliega la asistencia contextual.",
                ReglasSeguridad = "• Separación de Stock: Las existencias de venta no se mezclan con las de préstamo para asegurar disponibilidad en ambos servicios.\n• Auditoría de Cambios: Cada actualización de precio o stock genera un registro histórico en la tabla 'Libro_C' y recalcula automáticamente los dígitos verificadores DVH y DVV."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormLibroCambios",
                TituloModulo = "Historial de Modificaciones de Libros",
                Objetivo = "Auditar cronológicamente las variaciones de precios y niveles de existencias realizadas sobre los ejemplares del catálogo.",
                Pasos = "1. Seleccione el libro a auditar en el selector superior o filtre por rango de fechas.\n2. La grilla exhibirá la fecha exacta de cada cambio, el usuario responsable, los valores anteriores y los valores modificados.\n3. Revise las variaciones para constatar la consistencia de los aumentos de precio o ingresos de mercadería.",
                ControlesAtajos = "• Selector de Libro: Permite enfocar la auditoría en un título determinado.\n• Grilla de Historial: Muestra fecha, usuario, precio anterior/nuevo y stock anterior/nuevo.\n• Botón Salir: Cierra la ventana de auditoría.\n• Tecla F1: Muestra la ayuda de auditoría.",
                ReglasSeguridad = "• Pantalla de Solo Lectura: La información es inmutable y proviene de la tabla histórica 'Libro_C' para garantizar trazabilidad e impedir adulteraciones manuales."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormVenta",
                TituloModulo = "Registro de Ventas Directas de Libros",
                Objetivo = "Gestionar el circuito de venta minorista de ejemplares a clientes registrados, liquidar impuestos y proceder al cobro con emisión de factura.",
                Pasos = "1. Ingrese el DNI del cliente en el cuadro de búsqueda y presione 'Buscar'. Si el cliente no existe, puede presionar 'Nuevo Cliente' para darlo de alta.\n2. Busque el libro deseado por ISBN o Título, ingrese la cantidad de ejemplares a comprar y presione 'Añadir al Carrito'. El sistema valida que haya stock de venta suficiente.\n3. Verifique el detalle de ítems en la grilla del carrito, el Subtotal Neto Gravado, el IVA (21%) y el Total a pagar.\n4. Si desea quitar un ítem del carrito, selecciónelo y presione 'Quitar del Carrito'.\n5. Presione 'Cobrar' para acceder a la pasarela de pago con tarjeta y emitir la factura formal.",
                ControlesAtajos = "• Botón Añadir al Carrito: Agrega el libro y cantidad seleccionada a la orden.\n• Botón Quitar: Remueve el producto seleccionado del carrito.\n• Botón Cobrar: Abre la pasarela de pago para procesar la transacción.\n• Botón Nuevo Cliente: Abre el formulario de clientes para un alta inmediata.\n• Tecla F1: Abre la ayuda contextual.",
                ReglasSeguridad = "• Validación de Inventario: No se permite añadir al carrito cantidades superiores a las existencias físicas de venta disponibles.\n• Facturación Electrónica: Toda venta confirmada descuenta el stock y desencadena la emisión obligatoria de la Factura en formato PDF digital."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormCobro",
                TituloModulo = "Pasarela de Cobro y Facturación Electrónica",
                Objetivo = "Procesar transacciones de pago con tarjeta de crédito o débito y generar el comprobante fiscal en PDF.",
                Pasos = "1. Ingrese el número de tarjeta (16 dígitos). El sistema lo valida en tiempo real con el Algoritmo de Luhn.\n2. Ingrese el nombre y apellido del titular tal como figura en el plástico.\n3. Indique la fecha de vencimiento en formato MM/AA (verificando que no esté vencida).\n4. Ingrese el código de seguridad CVV (3 dígitos al dorso).\n5. Seleccione la cantidad de cuotas y presione 'Procesar Pago'.\n6. Seleccione la carpeta donde guardar el PDF de la Factura oficial.",
                ControlesAtajos = "• Botón Procesar Pago: Valida los datos y confirma el cobro.\n• Botón Cancelar: Cancela la operación de pago y retorna a la pantalla de origen.\n• Tecla F1: Muestra esta ayuda contextual.",
                ReglasSeguridad = "• Cumplimiento PCI-DSS: Los números de tarjeta y códigos CVV no se almacenan en texto plano en la base de datos.\n• Factura en PDF: El motor de reportes genera un comprobante formal con membrete institucional, discriminación de IVA (21%), datos del cliente y detalle de ítems."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormHistorialVentas",
                TituloModulo = "Historial y Reimpresión de Facturas de Venta",
                Objetivo = "Consultar el registro histórico de todas las ventas concretadas en la librería y permitir la reimpresión de facturas comerciales.",
                Pasos = "1. Aplique filtros por número de factura, cliente o rango de fechas si desea acotar la búsqueda.\n2. Seleccione la venta deseada en la grilla para inspeccionar su fecha, cliente, medio de pago e importe total.\n3. Presione el botón 'Reimprimir / Ver Factura PDF' para generar o visualizar nuevamente el comprobante en su lector de PDF.",
                ControlesAtajos = "• Botón Reimprimir: Genera y abre el documento PDF de la factura seleccionada.\n• Botón Filtrar: Refresca la grilla según los criterios ingresados.\n• Botón Salir: Cierra el visor de historial.\n• Tecla F1: Muestra la ayuda contextual.",
                ReglasSeguridad = "• Inmutabilidad de Comprobantes: Las facturas emitidas conservan los valores históricos de precios, alícuotas de IVA y totales correspondientes al momento de la venta."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormPrestamo",
                TituloModulo = "Préstamos Bibliográficos y Devoluciones con Mora",
                Objetivo = "Gestionar el ciclo completo de circulación bibliográfica: entrega de libros en préstamo y recepción de ejemplares con cálculo y liquidación automática de mora.",
                Pasos = "Para Registrar un Préstamo:\n1. Busque al socio por DNI y seleccione el libro deseado validando que tenga stock de préstamo.\n2. Seleccione la Fecha Pactada de Devolución.\n3. Presione 'Registrar Préstamo'. Se abrirá la pasarela de cobro para abonar el servicio/alquiler con tarjeta y se emitirá la Factura correspondiente.\n4. El stock de préstamos se descontará en 1 unidad.\n\nPara Registrar una Devolución:\n1. Seleccione el préstamo activo en la grilla de préstamos.\n2. Presione 'Registrar Devolución'. El sistema comprobará si existe demora respecto a la fecha pactada.\n3. Si hubo mora: Se notifican los días de atraso y el recargo a abonar. Se abre la pasarela de cobro para pagar el recargo con tarjeta y emitir la Factura de Recargo.\n4. Emisión de Comprobante: Se emite el Comprobante Oficial de Devolución en PDF, el préstamo pasa a 'Finalizado' (o 'Finalizado con Mora') y el ejemplar se reintegra al stock.",
                ControlesAtajos = "• Botón Registrar Préstamo: Inicia el trámite de entrega del libro.\n• Botón Registrar Devolución: Inicia la recepción del ejemplar y evaluación de mora.\n• Botón Nuevo Cliente: Permite registrar un socio sin salir de la pantalla.\n• Tecla F1: Despliega esta asistencia contextual.",
                ReglasSeguridad = "• Liquidación Automática de Mora: El recargo por devolución tardía se calcula mediante una tarifa diaria preestablecida y exige factura por el importe percibido.\n• Reintegración de Stock: Ningún ejemplar devuelto se da por reincorporado hasta la emisión efectiva del comprobante de devolución."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormHistorialPrestamos",
                TituloModulo = "Historial de Préstamos y Devoluciones",
                Objetivo = "Consultar el estado de todos los préstamos registrados en el sistema, diferenciando entre activos, devueltos en término y devueltos con mora.",
                Pasos = "1. Utilice el selector de estado para filtrar por 'Activos', 'Finalizados' o 'Finalizados con Mora'.\n2. Puede buscar por DNI de cliente o por título de libro.\n3. Seleccione un préstamo de la grilla para inspeccionar sus fechas de entrega, fecha pactada y fecha real de restitución.\n4. Si el préstamo está finalizado, puede presionar 'Reimprimir Comprobante de Devolución' para volver a abrir el PDF.",
                ControlesAtajos = "• Selector de Estado: Filtra los registros según su situación de cumplimiento.\n• Botón Reimprimir: Vuelve a generar el comprobante de devolución en PDF.\n• Botón Salir: Cierra la consulta de préstamos.\n• Tecla F1: Muestra la ayuda de la pantalla.",
                ReglasSeguridad = "• Trazabilidad de Cumplimiento: Permite evaluar el historial de conducta de los socios respecto a la puntualidad en las devoluciones."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormReporteInteligente",
                TituloModulo = "Reporte Inteligente y Analítica Predictiva",
                Objetivo = "Asistir al nivel directivo y gerencial en la toma de decisiones estratégicas mediante KPIs, análisis multidimensional de ventas y demanda, y modelos de predicción futura.",
                Pasos = "1. Defina el período de auditoría en los selectores 'Fecha Desde' y 'Fecha Hasta', o use los botones rápidos 'Mes Actual' o 'Todo el Historial'.\n2. Presione 'Actualizar' para procesar los datos de ventas y préstamos en tiempo real.\n3. Examine las Tarjetas de KPIs: Recaudación Total consolidada ($), Ventas Directas (ejemplares y $) y Circulación de Préstamos (solicitudes y $).\n4. Analice los 3 gráficos interactivos:\n   • Gráfico 1: Ventas por Editorial (porcentaje y facturación por sello).\n   • Gráfico 2: Demanda por Autor (ejemplares totales entre ventas y préstamos).\n   • Gráfico 3: Predicción: Libros Más Vendidos (Próximo Mes), con la estimación de ejemplares y recaudación proyectada para anticipar pedidos.\n5. Lea las sugerencias del panel inferior de 'Predicciones y Recomendaciones Inteligentes' para optimizar compras y prevenir quiebres de catálogo.",
                ControlesAtajos = "• Botón Actualizar: Recalcula todas las métricas en base al rango de fechas.\n• Botón Mes Actual: Configura el rango temporal para el mes en curso.\n• Botón Todo el Historial: Amplía el análisis a toda la base histórica.\n• Botón Salir: Cierra el reporte inteligente.\n• Tecla F1: Despliega esta ayuda contextual.",
                ReglasSeguridad = "• Acceso Restringido Exclusivo: Este formulario requiere el permiso 'Reporte Inteligente' (IdPermiso = 26), asignado únicamente al perfil Gerente (IdPerfil = 8). Los perfiles operativos no tienen acceso a estas métricas confidenciales."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormUsuario",
                TituloModulo = "Gestión de Usuarios del Sistema",
                Objetivo = "Administrar las cuentas de usuario autorizadas para operar Bookly, asignar perfiles de acceso y desbloquear cuentas.",
                Pasos = "1. Alta de Usuario: Ingrese Nombre, Apellido, DNI, Correo Electrónico, Nombre de Usuario y seleccione el Perfil asignado en el menú desplegable. Presione 'Guardar'.\n2. Modificación: Seleccione el usuario de la grilla, modifique sus datos o su perfil y presione 'Guardar'.\n3. Desbloqueo de Usuario: Si un usuario fue bloqueado por reiterar contraseñas erróneas, selecciónelo y presione 'Desbloquear Usuario'.\n4. Para cancelar o regresar: Presione el botón 'Salir'.",
                ControlesAtajos = "• Botón Guardar: Guarda los cambios del usuario.\n• Botón Desbloquear: Rehabilita el acceso para un usuario bloqueado.\n• Botón Salir: Cierra la ventana de usuarios.\n• Tecla F1: Muestra esta ayuda contextual.",
                ReglasSeguridad = "• Perfil Obligatorio: Todo usuario debe tener asignado al menos un perfil de seguridad válido.\n• Restricción de Administración: Este módulo solo puede ser operado por usuarios con perfil Administrador."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormPerfil",
                TituloModulo = "Gestión de Perfiles y Permisos (RBAC)",
                Objetivo = "Configurar la matriz de control de acceso basada en roles utilizando el patrón Composite (Familias y Permisos individuales).",
                Pasos = "1. Seleccione en la lista el perfil a configurar (ej. Administrador, Vendedor, Gerente).\n2. El árbol interactivo mostrará los permisos y familias asignados a dicho rol.\n3. Marque o desmarque las casillas de verificación para conceder o revocar permisos específicos.\n4. Presione 'Guardar' para persistir la configuración en la base de datos.",
                ControlesAtajos = "• Selector de Perfil: Permite conmutar entre los diferentes perfiles del sistema.\n• Árbol de Permisos: Muestra jerárquicamente familias y permisos atómicos.\n• Botón Guardar: Aplica las modificaciones de permisos.\n• Tecla F1: Abre la ayuda contextual.",
                ReglasSeguridad = "• Principio de Menor Privilegio: Asigne únicamente los permisos estrictamente necesarios para las funciones laborales de cada perfil.\n• Integridad DVV: Cada cambio en la matriz de permisos actualiza los dígitos verificadores correspondientes."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormBitacora",
                TituloModulo = "Auditoría y Bitácora de Eventos",
                Objetivo = "Monitorear, auditar y filtrar las acciones críticas y sucesos operacionales registrados por el motor de seguridad de Bookly.",
                Pasos = "1. Establezca el rango de fechas en 'Desde' y 'Hasta'.\n2. Opcionalmente filtre por Usuario responsable, Módulo afectado o Nivel de Criticidad (Baja = 1, Media = 2, Alta = 3).\n3. Presione el botón 'Filtrar' para consultar los eventos coincidentes en la grilla.\n4. Revise el detalle del suceso para constatar fecha, hora, usuario, criticidad y descripción.",
                ControlesAtajos = "• Botón Filtrar: Ejecuta la consulta de auditoría con los filtros seleccionados.\n• Botón Limpiar Filtros: Restablece los filtros para ver todos los eventos recientes.\n• Botón Salir: Cierra el visor de bitácora.\n• Tecla F1: Despliega la asistencia contextual.",
                ReglasSeguridad = "• Inmutabilidad Forense: Los registros de la bitácora no pueden ser editados ni eliminados desde la aplicación, asegurando la no repudiación de las acciones."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormCambioClave",
                TituloModulo = "Cambio de Contraseña de Usuario",
                Objetivo = "Permitir la actualización de la contraseña personal de acceso al sistema, ya sea de forma voluntaria o por requerimiento obligatorio.",
                Pasos = "1. Ingrese su contraseña vigente en el campo 'Contraseña Actual'.\n2. Ingrese su nueva contraseña en el campo 'Nueva Contraseña' (debe tener al menos 4 caracteres).\n3. Confirme la nueva clave repitiéndola en el campo 'Confirmar Nueva Contraseña'.\n4. Presione el botón 'Aceptar'.",
                ControlesAtajos = "• Botón Aceptar: Aplica el cambio de contraseña y registra el evento en bitácora.\n• Botón Cancelar: Cancela la operación sin modificar la contraseña.\n• Tecla F1: Muestra esta ayuda contextual.",
                ReglasSeguridad = "• Las contraseñas se almacenan mediante hash criptográfico SHA-256.\n• El sistema valida que la nueva contraseña coincida exactamente con la confirmación y que no sea idéntica a la anterior."
            },
            new BEItemAyuda
            {
                ClaveModulo = "FormErrorIntegridad",
                TituloModulo = "Control de Integridad de Datos (Dígitos Verificadores)",
                Objetivo = "Detectar, alertar y permitir la subsanación de inconsistencias físicas detectadas en la base de datos mediante Dígitos Verificadores Horizontales (DVH) y Verticales (DVV).",
                Pasos = "1. Si al iniciar el sistema se detecta una corrupción o alteración externa en una tabla, se abrirá automáticamente esta pantalla de emergencia.\n2. La grilla mostrará la tabla comprometida, el identificador del registro afectado y el tipo de discrepancia detectada.\n3. El Administrador cuenta con dos alternativas de resolución:\n   • 'Restaurar Último Respaldo': Si la alteración fue indebida o producto de una falla, se restaura una copia de seguridad limpia.\n   • 'Recalcular Dígitos Verificadores': Si la modificación respondió a una tarea de mantenimiento o migración autorizada en SQL Server, se recalculan los códigos hash para restablecer la coherencia.",
                ControlesAtajos = "• Botón Recalcular Dígitos: Actualiza los hashes DVH y DVV de todas las tablas de la base de datos.\n• Botón Restaurar Backup: Abre el asistente para levantar un respaldo previo (.bak).\n• Botón Salir: Cierra la aplicación ante la imposibilidad de operar en estado inconsistente.\n• Tecla F1: Muestra la ayuda de contingencia.",
                ReglasSeguridad = "• Protección Antifraude: Impide que operadores o atacantes modifiquen directamente tablas en SQL Server Management Studio para alterar precios, saldos o permisos sin conocimiento del sistema."
            }
        };

        public List<BEItemAyuda> ObtenerTodosLosTemas()
        {
            return catalogoAyuda.OrderBy(a => a.TituloModulo).ToList();
        }

        public BEItemAyuda ObtenerAyudaPorModulo(string claveModulo)
        {
            if (string.IsNullOrWhiteSpace(claveModulo))
            {
                return catalogoAyuda[1];
            }

            var item = catalogoAyuda.FirstOrDefault(a => a.ClaveModulo.Equals(claveModulo, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                return item;
            }

            var itemPorTitulo = catalogoAyuda.FirstOrDefault(a => a.TituloModulo.IndexOf(claveModulo, StringComparison.OrdinalIgnoreCase) >= 0);
            if (itemPorTitulo != null)
            {
                return itemPorTitulo;
            }

            return catalogoAyuda[1];
        }

        public List<BEItemAyuda> BuscarTemas(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
            {
                return ObtenerTodosLosTemas();
            }

            string term = termino.ToLowerInvariant().Trim();
            return catalogoAyuda.Where(a =>
                a.TituloModulo.ToLowerInvariant().Contains(term) ||
                a.Objetivo.ToLowerInvariant().Contains(term) ||
                a.Pasos.ToLowerInvariant().Contains(term) ||
                a.ControlesAtajos.ToLowerInvariant().Contains(term) ||
                a.ReglasSeguridad.ToLowerInvariant().Contains(term)
            ).OrderBy(a => a.TituloModulo).ToList();
        }
    }
}
