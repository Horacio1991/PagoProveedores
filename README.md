# Gestión de Pagos a Proveedores

Este proyecto de software desarrollado en C# .NET WPF permite gestionar pagos a proveedores, utilizando interfaces gráficas para manejar proveedores y sus respectivas deudas.

## Funcionalidades

- **ABM de Proveedores**: Agregar, modificar y eliminar proveedores con legajo y nombre.
- **Visualización de Deudas**: Mostrar las deudas asociadas a cada proveedor seleccionado.
- **Pagos**: Realizar pagos en efectivo y con cheque, calculando recargos por pagos tardíos.

## Estructura del Proyecto

El proyecto consta de las siguientes partes principales:

- **Clases**: Implementación de clases como `Proveedor`, `Pago`, `PagoEfectivo`, `PagoCheque`, que utilizan herencia y cumplen con la interfaz `IPago`.
- **Interfaz Gráfica**: Desarrollada en XAML para mostrar y gestionar proveedores y pagos.
- **Manejo de Datos**: Utilización de listas y diccionarios para almacenar y gestionar datos de proveedores y deudas.

## Uso del Programa

### Requisitos

- Instalación de .NET Framework.
- Entorno de desarrollo compatible con C# y WPF.

### Instrucciones de Ejecución

1. Clonar el repositorio o descargar el código.
2. Abrir el proyecto en Visual Studio.
3. Compilar y ejecutar la solución.

### Interfaz de Usuario

La interfaz de usuario se compone de:

- **Lista de Proveedores**: Seleccionar un proveedor muestra sus deudas asociadas.
- **Formulario de Proveedores**: Agregar, modificar o eliminar proveedores.
- **Grilla de Deudas**: Mostrar detalles de cada deuda y permitir pagos.
- **Botones de Pagos**: Realizar pagos en efectivo o con cheque según la deuda seleccionada.

## Modificaciones Recientes

- Implementación de manejo de excepciones `try-catch` en toda la aplicación.
- Autocompletado de campos al seleccionar un proveedor para modificar.



