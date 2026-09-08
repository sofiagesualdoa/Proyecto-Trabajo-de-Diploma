# Especificación del Proyecto Integrador: Bookly
**Universidad:** Universidad Abierta Interamericana (UAI)  
**Facultad:** Tecnología Informática  
**Materia:** Trabajo de Diploma  
**Docente:** Gamboa Jiménez, Leonel  
**Alumno:** Gesualdo Antonini, Sofía  

---

## 1. Dominio del Problema (Bookly)
Bookly es un sistema para la comercialización y préstamo de libros (nuevos y usados) en tienda física.
* **Procesos de Negocio Principales:**
  1. **PN1:** Gestión de Ventas de Libros en Tienda Física.
  2. **PN2:** Gestión de Préstamos y Devolución de Ejemplares en Tienda Física.
  3. **Gestión de Inventario y Reposición.**

---

## 2. Proceso de Negocio 1 (PN1): Ventas en Tienda Física

### Casos de Uso del Proceso:
* **CUN01: Registrar libro en el carrito**
  * **Actor:** Vendedor
  * **Precondición:** Vendedor logueado, carrito en curso existente, libro en catálogo con existencias.
  * **Flujo:** Incluye CUN02 (Seleccionar libro) -> Verifica existencias disponibles -> Si hay stock: si no estaba lo registra (`RegistrarLibro`), si ya estaba incrementa la cantidad (`IncrementarCantidad`) -> Informa éxito -> Refresca carrito.
  * **Flujo Alternativo:** Sin existencias -> Informa error al vendedor.
* **CUN02: Seleccionar libro**
  * Consulta y filtrado de catálogo en base a criterios ingresados (Título, Autor, ISBN).
* **CUN03: Cobrar venta**
  * Finalizar compra -> Asociar DNI cliente -> Indicar total -> Seleccionar tarjeta (débito/crédito) -> Procesar pago con entidad bancaria -> Confirmación -> Emitir Factura -> Actualizar stock de libros -> Registrar venta en historial.
  * **Flujo Alternativo:** Cliente no registrado -> Extiende a CUN04. Pago rechazado -> Venta revocada/cancelada.
* **CUN04: Registrar usuario / cliente**
  * Captura de DNI, Nombre, Apellido, Email, Teléfono, Dirección. Validación de no existencia previa y persistencia.

---

## 3. Modelo de Datos y DER (Diagrama Entidad-Relación)

### Tablas y Relaciones:
1. **`Libro`**
   * `PK IdLibro` (o `ISBN_657SGA`)
   * `Titulo`
   * `Autores`
   * `Editorial`
   * `Existencias` (Stock)
   * `Precio`
   * `Activo`
   * `DVH`

2. **`Carrito`**
   * `PK IdCarrito: int`
   * `FK IdVenta: int` (asociado al concretar venta)
   * `DNICliente: int`
   * `DVH`

3. **`DetalleCarrito` (Tabla intermedia)**
   * `PK/FK IdCarrito: int`
   * `PK/FK IdLibro: int` (o `ISBN: string`)
   * `Cantidad: int`
   * `DVH`
   *(Relación muchos a muchos entre Carrito y Libro)*

4. **`Venta`**
   * `PK IdVenta: int`
   * `FK DNICliente: int`
   * `Fecha: date`
   * `Hora: time`
   * `Total: decimal`
   * `DVH`

5. **`Factura`**
   * `PK IdFactura: int`
   * `FK IdVenta: int`
   * `DNICliente: int`
   * `Fecha: date`
   * `Hora: time`
   * `Total: decimal`
   * `DVH`

6. **`Pago`**
   * `PK IdPago: int`
   * `FK IdVenta: int`
   * `MedioPago: varchar`
   * `Importe: decimal`
   * `DVH`

7. **`Cliente`**
   * `PK DNI: int`
   * `Nombre: varchar(100)`
   * `Apellido: varchar(100)`
   * `Email: nvarchar(100)`
   * `Teléfono: int`
   * `Dirección: nvarchar(200)` (campo sensible sujeto a encriptación reversible)
   * `DVH`

---

## 4. Diagrama de Clases y Responsabilidades (Capas)

### Capa BE (Entidades)
* **`BELibro`:** Atributos del libro (`ISBN_657SGA`, `Título_657SGA`, etc.).
* **`BECarrito`:** `IdCarrito`, `DNICliente`, `List<BEDetalleCarrito> Detalles`, cálculo de `Total`.
* **`BEDetalleCarrito`:** `IdCarrito`, `ISBN`, `Cantidad`, `DVH`, y referencia `BELibro Libro` con propiedades de solo lectura (`Título`, `Autor`, `PrecioUnitario`, `Subtotal`).
* **`BECliente`:** Datos del cliente.
* **`BEVenta`:** Cabecera de venta.
* **`BEFactura`:** Factura emitida.

### Capa BLL (Negocio)
* **`BLLLibro`:** `BuscarLibros`, `VerificarUnidades(Libro): int`, altas, modificaciones, bajas.
* **`BLLCarrito`:** `AgregarLibro(Libro, cantidad)`, `IncrementarCantidad(Libro, cantidad)`, `RegistrarLibro(Libro, cantidad)`, `VaciarCarrito()`, `CalcularTotal()`, `AsociarDNI(int)`.
* **`BLLVenta`:** `AsociarCarrito(Carrito)`, `GenerarFactura()`, `GuardarVenta(Venta)`.
* **`BLLPago` / `BLLCliente`:** Procesamiento de pagos y gestión de clientes.

### Capa DAL (Acceso a Datos)
* `DALLibro`, `DALCarrito`, `DALVenta`, `DALCliente`, `DALPago`.

### Capa Servicios
* `ServicioIdioma` (Observer para internacionalización).
* `ServicioSessionManager` (Singleton).
* `ServicioEvento` / `Bitacora` (Auditoría sin retorno a GUI).
* `GeneradorDigVerificador` / `ServicioDVV` (DVH y DVV sin retorno a GUI).
* `ServicioCifrado` (Encriptación reversible).
