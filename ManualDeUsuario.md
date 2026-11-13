# 📖 Manual de Usuario - Sistema Bookly v3.0
**Universidad Abierta Interamericana (UAI) - Facultad de Tecnología Informática**  
**Carrera:** Ingeniería en Sistemas Informáticos  
**Asignatura:** Trabajo de Diploma  
**Alumna:** Sofía Gesualdo Antonini (Legajo: 46.956.657)  
**Docente:** Ing. Leonel Gamboa Jiménez  
**Año:** 2026  

---

## 📑 Índice General
1. [Introducción y Requisitos del Entorno](#1-introducción-y-requisitos-del-entorno)
2. [Acceso, Autenticación y Seguridad (Inicio de Sesión)](#2-acceso-autenticación-y-seguridad)
3. [Navegación Principal y Matriz de Privilegios (RBAC)](#3-navegación-principal-y-matriz-de-privilegios)
4. [Módulo de Gestión de Clientes y Protección de Datos Personales](#4-módulo-de-gestión-de-clientes-y-protección-de-datos)
5. [Módulo de Catálogo de Libros y Control de Inventario](#5-módulo-de-catálogo-de-libros-y-control-de-inventario)
6. [Proceso de Venta Directa y Facturación Electrónica en PDF](#6-proceso-de-venta-directa-y-facturación-electrónica)
7. [Proceso de Circulación y Préstamos Bibliográficos](#7-proceso-de-circulación-y-préstamos-bibliográficos)
8. [Devolución de Ejemplares y Liquidación de Mora](#8-devolución-de-ejemplares-y-liquidación-de-mora)
9. [Módulo de Reporte Inteligente y Analítica Predictiva (Gerencia)](#9-módulo-de-reporte-inteligente-y-analítica-predictiva)
10. [Auditoría de Seguridad y Bitácora de Eventos](#10-auditoría-de-seguridad-y-bitácora-de-eventos)
11. [Resguardo, Recuperación e Integridad de Base de Datos (DVH/DVV)](#11-resguardo-recuperación-e-integridad-de-base-de-datos)
12. [Sistema de Ayuda Contextual (Tecla F1) y Atajos de Teclado](#12-sistema-de-ayuda-contextual-tecla-f1-y-atajos)

---

## 1. Introducción y Requisitos del Entorno
El sistema **Bookly** constituye una solución integral de software de escritorio orientada a la gestión comercial, circulación bibliográfica, trazabilidad de inventario y análisis directivo de librerías modernas. Diseñado con una arquitectura en capas desacopladas (.NET 8 Windows Forms, Servicios, Lógica de Negocio BLL, Acceso a Datos DAL y Entidades de Negocio BE) bajo lenguaje C# y motor relacional Microsoft SQL Server 2022.

### Requisitos del Sistema
- **Sistema Operativo:** Windows 10 (64 bits) o Windows 11.
- **Entorno de Ejecución:** .NET 8.0 Desktop Runtime (x64).
- **Motor de Base de Datos:** Microsoft SQL Server 2019 / 2022 (Instancia local o red).
- **Memoria RAM:** 4 GB mínimo (8 GB recomendado).
- **Espacio en Disco:** 250 MB libres.
- **Lector de PDF:** Cualquier visor compatible para visualización de comprobantes.

---

## 2. Acceso, Autenticación y Seguridad
El acceso al sistema requiere credenciales previamente asignadas por el Administrador.

### Procedimiento de Inicio de Sesión
1. Ingrese su identificador en el cuadro **Usuario**.
2. Ingrese su clave en el cuadro **Contraseña** (los caracteres se enmascaran automáticamente).
3. Presione **Ingresar** o la tecla **Enter**.

### Política de Bloqueo y Almacenamiento Criptográfico
- **Bloqueo por Intentos Fallidos:** Tras tres (3) intentos erróneos consecutivos, la cuenta se bloquea automáticamente por seguridad institucional. Solo el Administrador puede rehabilitarla.
- **Seguridad de Claves:** Las contraseñas se almacenan mediante hash criptográfico unidireccional SHA-256.

---

## 3. Navegación Principal y Matriz de Privilegios
El menú principal (`FormSistema`) adapta sus opciones visibles y habilitadas dinámicamente según la matriz de permisos RBAC del perfil autenticado:

| Perfil | Módulos Habilitados | Funciones Principales |
| :--- | :--- | :--- |
| **Vendedor** (`IdPerfil = 2`) | Clientes, Libros, Ventas, Préstamos, Cobro, Historiales. | Atención al público, venta de libros, otorgamiento/devolución de préstamos, cobranza con tarjeta y emisión de comprobantes PDF. |
| **Gerente** (`IdPerfil = 8`) | Todo lo operativo + Reporte Inteligente + Desencriptación. | Acceso exclusivo al Reporte Inteligente con analítica predictiva de demanda futura, lectura de datos sensibles de clientes (dirección desencriptada) y toma de decisiones. |
| **Administrador** (`IdPerfil = 1`) | Usuarios, Perfiles, Permisos, Bitácora, Backup, Restore, DV. | Gestión de seguridad informática, asignación de roles, auditoría de eventos críticos, resguardo/restauración de base de datos y control de integridad (DVH/DVV). |

---

## 4. Módulo de Gestión de Clientes y Protección de Datos
Permite dar de alta, editar y buscar a los socios de la librería (`FormClientes`).

### Protección de Datos: Encriptación Reversible AES-256 en Dirección
El campo **Dirección** del cliente se almacena cifrado en la base de datos utilizando el estándar simétrico **AES-256 CBC** con relleno PKCS7 y validación HMAC-SHA256.
- **Perfil Gerente:** Es el único rol facultado para visualizar la dirección desencriptada en texto claro.
- **Otros Perfiles (Vendedor / Administrador):** El sistema exhibe la leyenda `[Dato Protegido - Solo Gerente]`, previniendo filtraciones de datos sensibles.

---

## 5. Módulo de Catálogo de Libros y Control de Inventario
Centraliza el inventario físico (`FormLibros`), diferenciando existencias:
- **Stock de Venta Directa:** Destinado a compras comerciales definitivas.
- **Stock de Préstamos:** Reservado exclusivamente a circulación bibliográfica domiciliaria.
- **Reposición:** Permite ingresar unidades adicionales recibidas de distribuidores con cálculo inmediato de nuevos stock.
- **Auditoría:** Cada modificación de precio o inventario se asienta en la tabla `Libro_C` y actualiza los dígitos verificadores DVH/DVV.

---

## 6. Proceso de Venta Directa y Facturación Electrónica
Circuito comercial de venta (`FormVenta` y `FormCobro`):
1. **Selección de Cliente:** Búsqueda por DNI (o alta inmediata desde botón 'Nuevo Cliente').
2. **Selección de Libros:** Búsqueda en catálogo e ingreso de cantidad, validando stock de venta disponible.
3. **Revisión del Carrito:** Cálculo automático de Subtotal Neto Gravado, IVA (21%) y Total General.
4. **Pasarela de Cobro con Tarjeta:** Ingreso de número de tarjeta (validado con Algoritmo de Luhn), titular, vencimiento y CVV.
5. **Emisión de Factura en PDF:** Descuento automático de stock y generación del documento PDF oficial.

---

## 7. Proceso de Circulación y Préstamos Bibliográficos
Gestión de préstamos domiciliarios (`FormPrestamo`):
1. Selección de socio y ejemplar verificando stock de préstamos.
2. Definición de la **Fecha Pactada de Devolución** y liquidación del costo del servicio/alquiler.
3. Cobro del servicio mediante tarjeta de crédito o débito con emisión de comprobante.
4. Descuento automático de 1 unidad del stock de préstamos y pase a estado **Activo**.

---

## 8. Devolución de Ejemplares y Liquidación de Mora
Recepción del material y control de plazos (`FormPrestamo`):
- **Devolución en Término (Sin Mora):** El préstamo se marca como 'Finalizado', se restaura el ejemplar al stock y se emite el Comprobante de Devolución en PDF sin recargos.
- **Devolución Fuera de Plazo (Con Mora):**
  1. El sistema computa los días de retraso transcurridos y multiplica por la tarifa diaria de penalización.
  2. Notifica el recargo monetario y abre la pasarela de cobro.
  3. El cliente abona con tarjeta y se emite la Factura de Recargo por Mora.
  4. Se genera el **Comprobante Oficial de Devolución en PDF**.
  5. El estado se actualiza a **Finalizado con Mora** y el ejemplar se reintegra a catálogo.

---

## 9. Módulo de Reporte Inteligente y Analítica Predictiva
Herramienta de Business Intelligence para la Gerencia (`FormReporteInteligente`):
- **Rango Temporal Paramétrico:** Filtros por Fecha Desde / Hasta con botones 'Mes Actual' y 'Todo el Historial'.
- **Tarjetas de KPIs:** Recaudación Total ($), Ventas Directas (ejemplares y $) y Circulación de Préstamos (solicitudes y $).
- **Gráfico 1 (Ventas por Editorial):** Donut GDI+ con porcentaje y monto facturado por editorial.
- **Gráfico 2 (Demanda por Autor):** Donut GDI+ consolidando ventas y préstamos por cada autor.
- **Gráfico 3 (Predicción: Libros Más Vendidos - Próximo Mes):** Barras horizontales proyectivas con la demanda esperada de ejemplares y la facturación proyectada a 30 días para anticipar compras y evitar quiebres de inventario.
- **Panel de Recomendaciones:** Abastecimiento predictivo automático, bonificaciones editoriales, autores destacados, auditoría de morosidad (umbral 15%) y alertas de stock agotado/crítico.

---

## 10. Auditoría de Seguridad y Bitácora de Eventos
Monitoreo forense inmutable de acciones del sistema (`FormBitacora`):
- **Criticidad 1 (Baja):** Inicios de sesión, salidas, consultas habituales.
- **Criticidad 2 (Media):** Transacciones de venta, préstamos, cobros, altas/bajas de catálogo.
- **Criticidad 3 (Alta):** Bloqueos de cuentas, fallos de integridad DV, backups y restores.
- **Filtros:** Por rango temporal, usuario, módulo o nivel de criticidad.

---

## 11. Resguardo, Recuperación e Integridad de Base de Datos
- **BackUp y Restore:** Generación y recuperación de copias de seguridad `.bak` en SQL Server.
- **Dígitos Verificadores Horizontales (DVH) y Verticales (DVV):** Detección en tiempo real de cualquier manipulación o adulteración externa de registros en las tablas.
- **Resolución de Inconsistencias (`FormErrorIntegridad`):** Opciones para restaurar el último respaldo seguro o recalcular dígitos verificadores autorizados.

---

## 12. Sistema de Ayuda Contextual (Tecla F1) y Atajos
- **Tecla F1:** Al presionar F1 en cualquier pantalla del sistema, se abre la ventana de **Ayuda Contextual** específica para ese módulo, detallando el objetivo, el procedimiento paso a paso, los controles y las reglas de negocio.
- **Menú Ayuda:**
  - *Ayuda Contextual del Sistema (F1):* Abre el visor contextual interactivo.
  - *Manual de Usuario (PDF):* Abre este documento completo en formato PDF.
  - *Guía de Instalación (Archivo Leéme):* Abre la guía de despliegue `README.pdf`.
- **Atajos Globales:**
  - `F1`: Abrir ayuda contextual de la pantalla actual.
  - `Enter`: Confirmar acción predeterminada.
  - `Escape (Esc)`: Cerrar ventana de ayuda o cancelar operación.
