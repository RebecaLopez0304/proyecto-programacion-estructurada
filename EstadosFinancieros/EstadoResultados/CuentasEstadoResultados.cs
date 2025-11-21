using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    /*
    ===========================
        Cuentas del Estado de Resultados
    ===========================
    */
    public static class CuentasEstadoResultados
    {
        // TODO: Cambiar de 'readonly' a modificable
        // TODO: Todas las cuentas deben tener EsCreadoPorUsuario = false en su inicialización
        public static readonly List<Cuenta> Ventas = new()
        {
            new Cuenta("Ventas totales", false),
            new Cuenta("Devoluciones sobre ventas", true), // Cuenta complementaria de ingresos
            new Cuenta("Descuentos sobre ventas", true), // Cuenta complementaria de ingresos
            new Cuenta("Bonificaciones sobre ventas", true), // Cuenta complementaria de ingresos
            new Cuenta("Ingresos por servicios", false),
            new Cuenta("Ingresos financieros", false),
            new Cuenta("Otros ingresos", false)
        };

        // COSTO DE VENTAS (Egresos - se suman porque disminuyen la utilidad)
        public static readonly List<Cuenta> CostoDeVentas = new()
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

        // GASTOS DE OPERACIÓN (Egresos - se suman porque disminuyen la utilidad)
        public static readonly List<Cuenta> GastoDeOperacion = new()
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
        public static readonly List<Cuenta> OtrosResultadosFinancieros = new()
        {
            new Cuenta("Intereses pagados", true),
            new Cuenta("Comisiones bancarias", true),
            new Cuenta("Pérdida en cambio de divisas", true),
            new Cuenta("Descuentos por pronto pago concedidos", true),
            new Cuenta("Gastos por emisión de obligaciones", true)
        };

    }
}
