using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    public static class CuentasEstadoResultados
    {
        // INGRESOS (Naturaleza Acreedora - se restan en el cálculo porque aumentan la utilidad)
        public static readonly List<Cuenta> Ingresos = new()
        {
            new Cuenta("Ventas totales", false),
            new Cuenta("Devoluciones sobre ventas", true), // Cuenta complementaria de ingresos
            new Cuenta("Descuentos sobre ventas", true), // Cuenta complementaria de ingresos
            new Cuenta("Bonificaciones sobre ventas", true), // Cuenta complementaria de ingresos
            new Cuenta("Ingresos por servicios", false),
            new Cuenta("Ingresos financieros", false),
            new Cuenta("Otros ingresos", false)
        };

        // COSTO DE VENTAS (Naturaleza Deudora - se suman porque disminuyen la utilidad)
        public static readonly List<Cuenta> CostoVentas = new()
        {
            new Cuenta("Inventario inicial", true),
            new Cuenta("Compras", true),
            new Cuenta("Gastos sobre compra", true),
            new Cuenta("Devoluciones sobre compra", false), // Disminuye el costo
            new Cuenta("Descuentos sobre compra", false), // Disminuye el costo
            new Cuenta("Bonificaciones sobre compra", false), // Disminuye el costo
            new Cuenta("Inventario final", false), // Se resta del costo
            new Cuenta("Costo de producción", true),
            new Cuenta("Mano de obra directa", true),
            new Cuenta("Materia prima", true)
        };

        // GASTOS DE OPERACIÓN (Naturaleza Deudora - se suman porque disminuyen la utilidad)
        public static readonly List<Cuenta> GastosVenta = new()
        {
            new Cuenta("Sueldos de vendedores", true),
            new Cuenta("Comisiones de vendedores", true),
            new Cuenta("Prestaciones de vendedores", true),
            new Cuenta("Publicidad y propaganda", true),
            new Cuenta("Gastos de empaque y envío", true),
            new Cuenta("Depreciación de equipo de reparto", true),
            new Cuenta("Combustibles y lubricantes", true),
            new Cuenta("Mantenimiento de vehículos", true),
            new Cuenta("Viáticos", true),
            new Cuenta("Promociones y muestras", true)
        };

        public static readonly List<Cuenta> GastosAdministracion = new()
        {
            new Cuenta("Sueldos de personal administrativo", true),
            new Cuenta("Prestaciones administrativas", true),
            new Cuenta("Honorarios profesionales", true),
            new Cuenta("Gastos de papelería y útiles", true),
            new Cuenta("Servicios públicos", true),
            new Cuenta("Seguros y fianzas", true),
            new Cuenta("Arrendamientos", true),
            new Cuenta("Depreciación de equipo de oficina", true),
            new Cuenta("Depreciación de edificio", true),
            new Cuenta("Amortización de gastos", true),
            new Cuenta("Mantenimiento y reparaciones", true),
            new Cuenta("Gastos legales", true),
            new Cuenta("Capacitación de personal", true)
        };

        // GASTOS Y PRODUCTOS FINANCIEROS
        public static readonly List<Cuenta> GastosFinancieros = new()
        {
            new Cuenta("Intereses pagados", true),
            new Cuenta("Comisiones bancarias", true),
            new Cuenta("Pérdida en cambio de divisas", true),
            new Cuenta("Descuentos por pronto pago concedidos", true),
            new Cuenta("Gastos por emisión de obligaciones", true)
        };

        public static readonly List<Cuenta> ProductosFinancieros = new()
        {
            new Cuenta("Intereses cobrados", false),
            new Cuenta("Utilidad en cambio de divisas", false),
            new Cuenta("Descuentos por pronto pago obtenidos", false),
            new Cuenta("Dividendos cobrados", false),
            new Cuenta("Rendimientos de inversiones", false)
        };

        // OTROS GASTOS Y PRODUCTOS
        public static readonly List<Cuenta> OtrosGastos = new()
        {
            new Cuenta("Pérdida en venta de activo fijo", true),
            new Cuenta("Pérdida por caso fortuito", true),
            new Cuenta("Donaciones y donativos", true),
            new Cuenta("Multas y recargos", true),
            new Cuenta("Pérdidas extraordinarias", true)
        };

        public static readonly List<Cuenta> OtrosProductos = new()
        {
            new Cuenta("Utilidad en venta de activo fijo", false),
            new Cuenta("Comisiones cobradas", false),
            new Cuenta("Ingresos extraordinarios", false),
            new Cuenta("Utilidades por arrendamiento", false)
        };

        // IMPUESTOS (Naturaleza Deudora - se suman porque disminuyen la utilidad)
        public static readonly List<Cuenta> Impuestos = new()
        {
            new Cuenta("ISR (Impuesto sobre la renta)", true),
            new Cuenta("PTU (Participación de los trabajadores en las utilidades)", true)
        };
    }
}
