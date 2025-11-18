using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    public static class CuentasEstadoResultados
    {
        // INGRESOS
        public static readonly List<Cuenta> Ingresos = new()
        {
            new Cuenta("Ventas totales"),
            new Cuenta("Devoluciones sobre ventas"),
            new Cuenta("Descuentos sobre ventas"),
            new Cuenta("Bonificaciones sobre ventas"),
            new Cuenta("Ingresos por servicios"),
            new Cuenta("Ingresos financieros"),
            new Cuenta("Otros ingresos")
        };

        // COSTO DE VENTAS
        public static readonly List<Cuenta> CostoVentas = new()
        {
            new Cuenta("Inventario inicial"),
            new Cuenta("Compras"),
            new Cuenta("Gastos sobre compra"),
            new Cuenta("Devoluciones sobre compra"),
            new Cuenta("Descuentos sobre compra"),
            new Cuenta("Bonificaciones sobre compra"),
            new Cuenta("Inventario final"),
            new Cuenta("Costo de producción"),
            new Cuenta("Mano de obra directa"),
            new Cuenta("Materia prima")
        };

        // GASTOS DE OPERACIÓN
        public static readonly List<Cuenta> GastosVenta = new()
        {
            new Cuenta("Sueldos de vendedores"),
            new Cuenta("Comisiones de vendedores"),
            new Cuenta("Prestaciones de vendedores"),
            new Cuenta("Publicidad y propaganda"),
            new Cuenta("Gastos de empaque y envío"),
            new Cuenta("Depreciación de equipo de reparto"),
            new Cuenta("Combustibles y lubricantes"),
            new Cuenta("Mantenimiento de vehículos"),
            new Cuenta("Viáticos"),
            new Cuenta("Promociones y muestras")
        };

        public static readonly List<Cuenta> GastosAdministracion = new()
        {
            new Cuenta("Sueldos de personal administrativo"),
            new Cuenta("Prestaciones administrativas"),
            new Cuenta("Honorarios profesionales"),
            new Cuenta("Gastos de papelería y útiles"),
            new Cuenta("Servicios públicos"),
            new Cuenta("Seguros y fianzas"),
            new Cuenta("Arrendamientos"),
            new Cuenta("Depreciación de equipo de oficina"),
            new Cuenta("Depreciación de edificio"),
            new Cuenta("Amortización de gastos"),
            new Cuenta("Mantenimiento y reparaciones"),
            new Cuenta("Gastos legales"),
            new Cuenta("Capacitación de personal")
        };

        // GASTOS Y PRODUCTOS FINANCIEROS
        public static readonly List<Cuenta> GastosFinancieros = new()
        {
            new Cuenta("Intereses pagados"),
            new Cuenta("Comisiones bancarias"),
            new Cuenta("Pérdida en cambio de divisas"),
            new Cuenta("Descuentos por pronto pago concedidos"),
            new Cuenta("Gastos por emisión de obligaciones")
        };

        public static readonly List<Cuenta> ProductosFinancieros = new()
        {
            new Cuenta("Intereses cobrados"),
            new Cuenta("Utilidad en cambio de divisas"),
            new Cuenta("Descuentos por pronto pago obtenidos"),
            new Cuenta("Dividendos cobrados"),
            new Cuenta("Rendimientos de inversiones")
        };

        // OTROS GASTOS Y PRODUCTOS
        public static readonly List<Cuenta> OtrosGastos = new()
        {
            new Cuenta("Pérdida en venta de activo fijo"),
            new Cuenta("Pérdida por caso fortuito"),
            new Cuenta("Donaciones y donativos"),
            new Cuenta("Multas y recargos"),
            new Cuenta("Pérdidas extraordinarias")
        };

        public static readonly List<Cuenta> OtrosProductos = new()
        {
            new Cuenta("Utilidad en venta de activo fijo"),
            new Cuenta("Comisiones cobradas"),
            new Cuenta("Ingresos extraordinarios"),
            new Cuenta("Utilidades por arrendamiento")
        };

        // IMPUESTOS
        public static readonly List<Cuenta> Impuestos = new()
        {
            new Cuenta("ISR (Impuesto sobre la renta)"),
            new Cuenta("PTU (Participación de los trabajadores en las utilidades)")
        };
    }
}
