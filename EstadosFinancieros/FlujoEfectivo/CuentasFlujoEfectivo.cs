using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo
{
    public static class CuentasFlujoEfectivo
    {
        // ACTIVIDADES DE OPERACIÓN
        public static readonly List<Cuenta> ActividadesOperacion = new()
        {
            new Cuenta("Utilidad o pérdida neta del ejercicio"),
            new Cuenta("Depreciación de activo fijo"),
            new Cuenta("Amortización de activos intangibles"),
            new Cuenta("Estimación para cuentas incobrables"),
            new Cuenta("Pérdida por venta de activo fijo"),
            new Cuenta("Utilidad por venta de activo fijo"),
            new Cuenta("Aumento en cuentas por cobrar"),
            new Cuenta("Disminución en cuentas por cobrar"),
            new Cuenta("Aumento en inventarios"),
            new Cuenta("Disminución en inventarios"),
            new Cuenta("Aumento en gastos pagados por anticipado"),
            new Cuenta("Disminución en gastos pagados por anticipado"),
            new Cuenta("Aumento en proveedores"),
            new Cuenta("Disminución en proveedores"),
            new Cuenta("Aumento en cuentas por pagar"),
            new Cuenta("Disminución en cuentas por pagar"),
            new Cuenta("Aumento en impuestos por pagar"),
            new Cuenta("Disminución en impuestos por pagar")
        };

        // ACTIVIDADES DE INVERSIÓN
        public static readonly List<Cuenta> ActividadesInversion = new()
        {
            new Cuenta("Compra de terrenos"),
            new Cuenta("Venta de terrenos"),
            new Cuenta("Compra de edificios"),
            new Cuenta("Venta de edificios"),
            new Cuenta("Compra de maquinaria y equipo"),
            new Cuenta("Venta de maquinaria y equipo"),
            new Cuenta("Compra de equipo de transporte"),
            new Cuenta("Venta de equipo de transporte"),
            new Cuenta("Compra de mobiliario y equipo de oficina"),
            new Cuenta("Venta de mobiliario y equipo de oficina"),
            new Cuenta("Adquisición de inversiones temporales"),
            new Cuenta("Venta de inversiones temporales"),
            new Cuenta("Adquisición de inversiones permanentes"),
            new Cuenta("Venta de inversiones permanentes"),
            new Cuenta("Préstamos otorgados"),
            new Cuenta("Cobro de préstamos otorgados")
        };

        // ACTIVIDADES DE FINANCIAMIENTO
        public static readonly List<Cuenta> ActividadesFinanciamiento = new()
        {
            new Cuenta("Aportaciones de capital"),
            new Cuenta("Reembolso de capital"),
            new Cuenta("Préstamos bancarios obtenidos"),
            new Cuenta("Pago de préstamos bancarios"),
            new Cuenta("Emisión de obligaciones"),
            new Cuenta("Amortización de obligaciones"),
            new Cuenta("Emisión de acciones"),
            new Cuenta("Recompra de acciones"),
            new Cuenta("Pago de dividendos"),
            new Cuenta("Aportaciones para futuros aumentos de capital"),
            new Cuenta("Documentos por pagar a largo plazo obtenidos"),
            new Cuenta("Pago de documentos por pagar a largo plazo"),
            new Cuenta("Arrendamiento financiero"),
            new Cuenta("Pago de arrendamiento financiero")
        };
    }
}
