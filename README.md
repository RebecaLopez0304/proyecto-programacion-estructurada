# Proyecto de Estados Financieros

Sistema de gestión de estados financieros que permite administrar y calcular:
- Balance General
- Estado de Resultados
- Flujo de Efectivo

## Estructura del Proyecto

```
proyecto-programacion/
├── EstadosFinancieros/
│   ├── BalanceGeneral/
│   │   ├── BalanceGeneral.cs          # Lógica del Balance General
│   │   └── CuentasBalanceGeneral.cs   # Catálogo de cuentas del Balance General
│   ├── EstadoResultados/
│   │   ├── EstadoResultados.cs        # Lógica del Estado de Resultados
│   │   └── CuentasEstadoResultados.cs # Catálogo de cuentas del Estado de Resultados
│   └── FlujoEfectivo/
│       ├── FlujoEfectivo.cs          # Lógica del Flujo de Efectivo
│       └── CuentasFlujoEfectivo.cs   # Catálogo de cuentas del Flujo de Efectivo
├── Comunes/
│   ├── Cuenta.cs                      # Clase base Cuenta
│   └── Utilidades.cs                  # Funciones de utilidad compartidas
└── Program.cs                         # Punto de entrada del programa
```

## Balance General

Incluye las siguientes clasificaciones:
- **Activos**: Circulante, Fijo, Intangible, Otros
- **Pasivos**: Corto Plazo, Largo Plazo
- **Capital**: Contribuido, Ganado

## Estado de Resultados

Incluye las siguientes categorías:
- Ingresos
- Costo de Ventas
- Gastos de Operación (Venta y Administración)
- Gastos y Productos Financieros
- Otros Gastos y Productos
- Impuestos

## Flujo de Efectivo

Incluye las siguientes actividades:
- Actividades de Operación
- Actividades de Inversión
- Actividades de Financiamiento

## Cómo ejecutar

```bash
dotnet run
```
