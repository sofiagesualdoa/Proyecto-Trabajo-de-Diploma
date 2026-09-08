# Apuntes de Cátedra - Trabajo de Diploma (UAI)
**Docente:** Gamboa Jiménez, Leonel  
**Materia:** Trabajo de Diploma / ADS 2 / Ingeniería de Software

---

## 1. Cronograma y Entregas
* **Entrega 1:** Proceso de Negocio 1 (PN1: Ventas) totalmente diseñado y programado.
* **Entrega 2:** Proceso de Negocio 2 (PN2: Préstamos) totalmente diseñado y programado + Dígito Verificador.
* **Entrega 3:** Diagrama de clases y base de datos + instalador + bitácora de cambios + ayuda contextual + control de cambios.
* **Parcial 1:** Hilos (Threads).
* **Parcial 2:** Reflection.

---

## 2. Reglas de Arquitectura y Diseño
* **Dígito Verificador (DV):** Obligatorio en **todas las tablas** de la base de datos (DVH por fila, DVV por tabla o conjunto).
* **DSS (Diagrama de Secuencia del Sistema):**
  * Flujo estricto: `Actor -> GUI -> BLL -> DAL -> [Bitácora de Eventos / Cambios]`.
  * La GUI en la que está el usuario es la que inicia la interacción (no interesa el menú principal en el DSS).
  * **El dígito verificador y las bitácoras no tienen retorno hacia la GUI.**
* **Capas:**
  * Capa de **Servicios** separada (Bitácora, Idioma/Observer, Sesión/Singleton, Seguridad, Encriptación, Dígito Verificador).
  * Capa **BLL** pura para la lógica de negocio del dominio (`BLLLibro`, `BLLCarrito`, `BLLVenta`, etc.).
  * Capa **DAL** para acceso a datos.
  * Capa **BE** para las entidades de negocio.

---

## 3. Seguridad y Auditoría
* **Encriptación Reversible:** Para campos sensibles (ejemplo: dirección de cliente, email, datos personales). Se debe documentar en qué parte de la base de datos se aplica.
* **Bitácora de Eventos:** Registro histórico de acciones (Login, Logout, Alta, Modificación, Baja, etc.). No se revierte.
* **Bitácora de Cambios:** Específica para entidades maestras (ej. Productos/Libros). Guarda el estado anterior y posterior con posibilidad de revertir (rollback) los cambios realizados.
* **Triggers:** Uso de triggers de base de datos (ej. al eliminar o modificar registros para actualizar totales o stocks de tablas padre/asociadas).

---

## 4. Patrones de Diseño Requeridos
* **Builder:** Patrón creacional.
* **Chain of Responsibility:** Patrón de comportamiento.
*(3 ejemplos de aplicación de cada uno, 2 programados sin persistencia y por consola para el TP de patrones).*

---

## 5. Requisitos No Funcionales y Ayuda
* **Ayuda contextual por pantalla:** Cada pantalla debe tener su ayuda vinculada. Si tiene más de 3 páginas, debe permitir navegación y linkeo a puntos específicos.
* **Reinstalador / Backup:** Advertir siempre que se debe realizar backup previo para no pisar la base de datos existente.
