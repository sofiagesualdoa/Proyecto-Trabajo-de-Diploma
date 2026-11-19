# 🌟 Guía de Instalación y Configuración (LEEME)
## Bookly v2.0 - "Libros que te acompañan"
**Sistema de Gestión, Comercialización y Préstamo de Libros**

---

## 📋 1. Requisitos Previos del Sistema

Antes de iniciar la instalación, asegúrese de que el equipo cumpla con los siguientes requerimientos mínimos:
* **Sistema Operativo:** Windows 10 (64-bit) o Windows 11.
* **Plataforma de Ejecución:** .NET 8.0 Runtime para aplicaciones de escritorio Windows.
* **Motor de Base de Datos:** 
  * Microsoft SQL Server 2019 / 2022 (con autenticación de Windows integrada habilitada en la instancia predeterminada `.`), o bien **MSSQLLocalDB**.
  * Utilidad de línea de comandos **`sqlcmd`** instalada y accesible en el PATH del sistema.
* **Permisos:** Privilegios de **Administrador** en el equipo local.
* **Espacio en Disco:** Mínimo 50 MB libres para el sistema y scripts de datos.

---

## 🚀 2. Proceso de Instalación Paso a Paso

El sistema se distribuye a través del instalador interactivo **`Setup_Bookly_v2.0.exe`**.

### Paso 1: Ejecutar el Asistente como Administrador
1. Descargue y descomprima el archivo de distribución `Setup_Bookly_v2.0.zip`.
2. Haga clic derecho sobre **`Setup_Bookly_v2.0.exe`** y seleccione **Ejecutar como administrador**.
3. Se iniciará el asistente de instalación de Bookly en idioma español. Presione **Siguiente**.

### Paso 2: Seleccionar la Carpeta de Destino
Por defecto, el asistente instalará la aplicación en la ruta estándar de programas de 64 bits:
```text
C:\Program Files\Bookly
```
Puede mantener la ruta por defecto o presionar **Examinar...** para indicar una ubicación personalizada. Presione **Siguiente**.

### Paso 3: Selección del Tipo de Instalación (Crítico)
El instalador detectará el entorno y le solicitará seleccionar entre dos modalidades:

* 🟢 **Instalación Inicial de Cero:**  
  * *Cuándo utilizarla:* Primera vez que instala el sistema en el equipo.
  * *Acción:* Ejecuta automáticamente el script de inicialización limpia `Instalacion_Limpia_EverGlow.sql`, creando la base de datos `EverGlow` con el catálogo base, roles, permisos, esquemas de dígitos verificadores (DVH/DVV) y el usuario administrador de fábrica.
  * *Confirmación:* El sistema solicitará confirmación antes de crear o reiniciar la estructura.

* 🟡 **Reinstalación / Actualización:**  
  * *Cuándo utilizarla:* Cuando el sistema ya fue instalado previamente y solo desea actualizar los ejecutables o reparar binarios.
  * *Acción:* Actualiza los archivos del programa pero **preserva la base de datos existente intacta**, protegiendo los datos comerciales y de clientes.
  * ⚠️ **ADVERTENCIA DE SEGURIDAD:** El asistente le mostrará un recordatorio formal indicando que, por precaución operativa, debe contar con un **Backup previo** de la base de datos antes de continuar.

### Paso 4: Tareas Adicionales
Marque la casilla **Crear un acceso directo en el escritorio** si desea tener un acceso rápido en su pantalla principal. Presione **Siguiente**.

### Paso 5: Ejecución de la Instalación
Revise el resumen de la configuración y haga clic en **Instalar**. 
* Si seleccionó *Instalación Inicial de Cero*, el instalador invocará de forma desatendida el script de base de datos en SQL Server.

### Paso 6: Finalización
Al concluir la instalación:
* Podrá dejar tildada la opción **Ejecutar Bookly - Libros que te acompañan** y presionar **Finalizar** para abrir el software de inmediato.
* En el menú Inicio se creará el grupo **Bookly**, que incluye accesos directos al sistema, al **Manual de Usuario** en formato PDF y al desinstalador.

---

## 🔑 3. Acceso Inicial al Sistema (Credenciales de Fábrica)

Para el primer inicio de sesión tras una instalación limpia, utilice las credenciales del Administrador configuradas en la base de datos:

| Campo | Valor por Defecto |
|---|---|
| **Nombre de Usuario** | `pruebaAdmin` *(o DNI: `98765432`)* |
| **Contraseña** | `12345` |
| **Rol Asignado** | `Administrador` (Control total y gestión de seguridad) |

> **Nota de Seguridad:** Se recomienda acceder al menú *Usuario -> Cambiar Clave* para modificar la contraseña por defecto en el primer uso.

---

## 📂 4. Estructura de Archivos Desplegados

En la carpeta de instalación (`C:\Program Files\Bookly`) se encontrarán los siguientes elementos principales:
* **`Venta y Préstamo de Libros.exe`**: Ejecutable principal del sistema.
* **`ManualDeUsuario.pdf`**: Manual de usuario y ayuda operativa.
* **`bookly.ico`**: Icono institucional del sistema.
* **Carpeta `\Database\`**:
  * `Instalacion_Limpia_EverGlow.sql`: Script DDL/DML completo de la base de datos `EverGlow`.
  * `Ejecutar_Script_BD.bat`: Script por lotes para ejecución y diagnóstico directo contra SQL Server o LocalDB.
* **`unins000.exe`**: Desinstalador seguro del sistema.

---

## 🛠️ 5. Preguntas Frecuentes y Solución de Problemas (FAQ)

### ¿Qué hacer si el asistente muestra advertencia con código de error al inicializar la base de datos?
1. Verifique que el servicio de **SQL Server (MSSQLSERVER)** o **SQL Server Express** se encuentre en estado **En Ejecución** desde el panel de Servicios de Windows (`services.msc`).
2. Abra una consola de comandos o diríjase a la carpeta instalada:
   ```text
   C:\Program Files\Bookly\Database\
   ```
3. Ejecute manualmente haciendo clic derecho sobre **`Ejecutar_Script_BD.bat`** -> **Ejecutar como administrador**. El script intentará la conexión primero con la instancia local por defecto y, de no hallarla, intentará con `(localdb)\MSSQLLocalDB`.

### ¿Se pueden perder mis datos si reinstalo el sistema?
No, siempre y cuando en el **Paso 3** del asistente seleccione la opción **Reinstalación / Actualización**. Esta modalidad garantiza que la base de datos `EverGlow` no sea tocada. Igualmente, recuerde siempre realizar un backup desde el menú *Administración -> BackUp* antes de cualquier actualización.

### ¿Cómo desinstalar el sistema?
Diríjase a *Configuración de Windows -> Aplicaciones -> Aplicaciones instaladas*, busque **Bookly - Libros que te acompañan** y seleccione **Desinstalar** (o ejecute el acceso directo de desinstalación desde el menú Inicio). La desinstalación eliminará los archivos de programa pero conservará su motor de base de datos para evitar pérdida involuntaria de registros.
