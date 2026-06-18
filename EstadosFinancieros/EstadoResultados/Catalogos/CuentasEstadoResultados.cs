using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos
{
    /// <summary>
    /// Cuentas predefinidas del Estado de Resultados, agrupadas por categoría de ingreso
    /// o egreso. Cada cuenta es <c>CuentaDeudora</c> o <c>CuentaAcreedora</c>.
    /// </summary>
    public static class CuentasEstadoResultados
    {
        public static readonly List<Cuenta> Ventas = new List<Cuenta>()
        {
            new CuentaAcreedora("Ventas totales"),
            new CuentaDeudora("Devoluciones sobre ventas"),
            new CuentaDeudora("Descuentos sobre ventas"),
            new CuentaDeudora("Bonificaciones sobre ventas"),
            new CuentaAcreedora("Ingresos por servicios"),
            new CuentaAcreedora("Ingresos financieros"),
            new CuentaAcreedora("Otros ingresos")
        };
        public static readonly List<Cuenta> CostoDeVentas = new List<Cuenta>()
        {
            new CuentaDeudora("Inventario inicial"),
            new CuentaDeudora("Compras"),
            new CuentaDeudora("Gastos sobre compra"),
            new CuentaAcreedora("Devoluciones sobre compra"),
            new CuentaAcreedora("Descuentos sobre compra"),
            new CuentaAcreedora("Bonificaciones sobre compra"),
            new CuentaAcreedora("Inventario final"),
            new CuentaDeudora("Costo de producción"),
            new CuentaDeudora("Mano de obra directa"),
            new CuentaDeudora("Materia prima")
        };
        public static readonly List<Cuenta> GastoDeOperacion = new List<Cuenta>()
        {
            new CuentaDeudora("Sueldos de vendedores"),
            new CuentaDeudora("Comisiones de vendedores"),
            new CuentaDeudora("Prestaciones de vendedores"),
            new CuentaDeudora("Publicidad y propaganda"),
            new CuentaDeudora("Gastos de empaque y envío"),
            new CuentaDeudora("Depreciación de equipo de reparto"),
            new CuentaDeudora("Combustibles y lubricantes"),
            new CuentaDeudora("Mantenimiento de vehículos"),
            new CuentaDeudora("Viáticos"),
            new CuentaDeudora("Promociones y muestras")
        };
        public static readonly List<Cuenta> GastosAdministracion = new List<Cuenta>()
        {
            new CuentaDeudora("Sueldos de personal administrativo"),
            new CuentaDeudora("Prestaciones administrativas"),
            new CuentaDeudora("Honorarios profesionales"),
            new CuentaDeudora("Gastos de papelería y útiles"),
            new CuentaDeudora("Servicios públicos"),
            new CuentaDeudora("Seguros y fianzas"),
            new CuentaDeudora("Arrendamientos"),
            new CuentaDeudora("Depreciación de equipo de oficina"),
            new CuentaDeudora("Depreciación de edificio"),
            new CuentaDeudora("Amortización de gastos"),
            new CuentaDeudora("Mantenimiento y reparaciones"),
            new CuentaDeudora("Gastos legales"),
            new CuentaDeudora("Capacitación de personal")
        };
        public static readonly List<Cuenta> OtrosResultadosFinancieros = new List<Cuenta>()
        {
            new CuentaDeudora("Intereses pagados"),
            new CuentaDeudora("Comisiones bancarias"),
            new CuentaDeudora("Pérdida en cambio de divisas"),
            new CuentaDeudora("Descuentos por pronto pago concedidos"),
            new CuentaDeudora("Gastos por emisión de obligaciones")
        };
    }
}
