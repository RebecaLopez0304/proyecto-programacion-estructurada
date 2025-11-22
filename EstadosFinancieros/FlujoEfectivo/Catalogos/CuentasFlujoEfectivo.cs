using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos
{
    // Aquí definimos las listas de cuentas que usa el Flujo de Efectivo
    // Cada lista representa una actividad: Operación, Inversión, Financiamiento
    public static class CuentasFlujoEfectivo
    {
        // MARK: - Actividades de Operación
        // Movimientos de efectivo relacionados con las actividades principales del negocio
        public static readonly List<Cuenta> ActividadesOperacion = new()
        {
            // (+) Punto de partida: resultado neto del ejercicio
            new Cuenta("Utilidad o pérdida neta del ejercicio", true, "Capital"),

            // (+) Partidas que no requirieron salida de efectivo, se suman de vuelta
            new Cuenta("Depreciación de activo fijo", true, "Activo"),

            // (+) Desgaste de activos intangibles que no implicó salida de efectivo
            new Cuenta("Amortización de activos intangibles", true, "Activo"),

            // (+) Provisión para cuentas incobrables que no es salida real de efectivo
            new Cuenta("Estimación para cuentas incobrables", true, "Activo"),

            // (+) Pérdida contable que no representó salida de efectivo
            new Cuenta("Pérdida por venta de activo fijo", true, "Capital"),

            // (-) Utilidad que no representó entrada de efectivo, se resta
            new Cuenta("Utilidad por venta de activo fijo", false, "Capital"),

            // (-) Más cuentas por cobrar = menos efectivo disponible
            new Cuenta("Aumento en cuentas por cobrar", false, "Activo"),

            // (+) Menos cuentas por cobrar = se cobró en efectivo
            new Cuenta("Disminución en cuentas por cobrar", true, "Activo"),

            // (-) Más inventario = salida de efectivo para comprarlo
            new Cuenta("Aumento en inventarios", false, "Activo"),

            // (+) Menos inventario = se vendió y generó efectivo
            new Cuenta("Disminución en inventarios", true, "Activo"),

            // (-) Pago anticipado de gastos = salida de efectivo
            new Cuenta("Aumento en gastos pagados por anticipado", false, "Activo"),

            // (+) Uso de gastos prepagados = no se pagó en este periodo
            new Cuenta("Disminución en gastos pagados por anticipado", true, "Activo"),

            // (+) Más deuda con proveedores = conservamos efectivo
            new Cuenta("Aumento en proveedores", true, "Pasivo"),

            // (-) Menos deuda con proveedores = pagamos en efectivo
            new Cuenta("Disminución en proveedores", false, "Pasivo"),

            // (+) Más cuentas por pagar = conservamos efectivo
            new Cuenta("Aumento en cuentas por pagar", true, "Pasivo"),

            // (-) Menos cuentas por pagar = pagamos en efectivo
            new Cuenta("Disminución en cuentas por pagar", false, "Pasivo"),

            // (+) Más impuestos por pagar = aún no se pagaron en efectivo
            new Cuenta("Aumento en impuestos por pagar", true, "Pasivo"),

            // (-) Menos impuestos por pagar = se pagaron en efectivo
            new Cuenta("Disminución en impuestos por pagar", false, "Pasivo")
        };

        // MARK: - Actividades de Inversión
        // Compra y venta de activos de largo plazo e inversiones
        public static readonly List<Cuenta> ActividadesInversion = new()
        {
            // (-) Salida de efectivo por adquisición de terrenos
            new Cuenta("Compra de terrenos", false, "Activo"),

            // (+) Entrada de efectivo por venta de terrenos
            new Cuenta("Venta de terrenos", true, "Activo"),

            // (-) Salida de efectivo por adquisición de edificios
            new Cuenta("Compra de edificios", false, "Activo"),

            // (+) Entrada de efectivo por venta de edificios
            new Cuenta("Venta de edificios", true, "Activo"),

            // (-) Salida de efectivo por adquisición de maquinaria
            new Cuenta("Compra de maquinaria y equipo", false, "Activo"),

            // (+) Entrada de efectivo por venta de maquinaria
            new Cuenta("Venta de maquinaria y equipo", true, "Activo"),

            // (-) Salida de efectivo por adquisición de vehículos
            new Cuenta("Compra de equipo de transporte", false, "Activo"),

            // (+) Entrada de efectivo por venta de vehículos
            new Cuenta("Venta de equipo de transporte", true, "Activo"),

            // (-) Salida de efectivo por adquisición de mobiliario
            new Cuenta("Compra de mobiliario y equipo de oficina", false, "Activo"),

            // (+) Entrada de efectivo por venta de mobiliario
            new Cuenta("Venta de mobiliario y equipo de oficina", true, "Activo"),

            // (-) Salida de efectivo por compra de inversiones a corto plazo
            new Cuenta("Adquisición de inversiones temporales", false, "Activo"),

            // (+) Entrada de efectivo por venta de inversiones a corto plazo
            new Cuenta("Venta de inversiones temporales", true, "Activo"),

            // (-) Salida de efectivo por compra de inversiones a largo plazo
            new Cuenta("Adquisición de inversiones permanentes", false, "Activo"),

            // (+) Entrada de efectivo por venta de inversiones a largo plazo
            new Cuenta("Venta de inversiones permanentes", true, "Activo"),

            // (-) Salida de efectivo por préstamos dados a terceros
            new Cuenta("Préstamos otorgados", false, "Activo"),

            // (+) Entrada de efectivo por cobro de préstamos dados
            new Cuenta("Cobro de préstamos otorgados", true, "Activo")
        };

        // MARK: - Actividades de Financiamiento
        // Obtención y pago de recursos de accionistas y acreedores
        public static readonly List<Cuenta> ActividadesFinanciamiento = new()
        {
            // (+) Entrada de efectivo por aportación de los socios
            new Cuenta("Aportaciones de capital", true, "Capital"),

            // (-) Salida de efectivo por devolución de capital a socios
            new Cuenta("Reembolso de capital", false, "Capital"),

            // (+) Entrada de efectivo por préstamos recibidos del banco
            new Cuenta("Préstamos bancarios obtenidos", true, "Pasivo"),

            // (-) Salida de efectivo por pago de préstamos bancarios
            new Cuenta("Pago de préstamos bancarios", false, "Pasivo"),

            // (+) Entrada de efectivo por emisión de bonos u obligaciones
            new Cuenta("Emisión de obligaciones", true, "Pasivo"),

            // (-) Salida de efectivo por pago de bonos u obligaciones
            new Cuenta("Amortización de obligaciones", false, "Pasivo"),

            // (+) Entrada de efectivo por venta de acciones propias
            new Cuenta("Emisión de acciones", true, "Capital"),

            // (-) Salida de efectivo por compra de acciones propias
            new Cuenta("Recompra de acciones", false, "Capital"),

            // (-) Salida de efectivo por pago de utilidades a accionistas
            new Cuenta("Pago de dividendos", false, "Capital"),

            // (+) Entrada de efectivo por aportaciones para aumentar capital futuro
            new Cuenta("Aportaciones para futuros aumentos de capital", true, "Capital"),

            // (+) Entrada de efectivo por documentos a largo plazo firmados
            new Cuenta("Documentos por pagar a largo plazo obtenidos", true, "Pasivo"),

            // (-) Salida de efectivo por pago de documentos a largo plazo
            new Cuenta("Pago de documentos por pagar a largo plazo", false, "Pasivo"),

            // (+) Entrada de efectivo por contrato de arrendamiento financiero
            new Cuenta("Arrendamiento financiero", true, "Pasivo"),

            // (-) Salida de efectivo por pagos de arrendamiento financiero
            new Cuenta("Pago de arrendamiento financiero", false, "Pasivo")
        };
    }
}

