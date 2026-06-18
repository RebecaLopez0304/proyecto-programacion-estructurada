using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos
{
    /// <summary>
    /// Cuentas predefinidas del Flujo de Efectivo, agrupadas por actividad (Operación,
    /// Inversión, Financiamiento). El tercer parámetro indica el grupo del Balance
    /// General ("Activo", "Pasivo" o "Capital") al que pertenece la cuenta.
    /// </summary>
    public static class CuentasFlujoEfectivo
    {
        public static readonly List<Cuenta> ActividadesOperacion = new List<Cuenta>()
        {
            new CuentaDeudora("Utilidad o pérdida neta del ejercicio", "Capital"),
            new CuentaDeudora("Depreciación de activo fijo", "Activo"),
            new CuentaDeudora("Amortización de activos intangibles", "Activo"),
            new CuentaDeudora("Estimación para cuentas incobrables", "Activo"),
            new CuentaDeudora("Pérdida por venta de activo fijo", "Capital"),
            new CuentaAcreedora("Utilidad por venta de activo fijo", "Capital"),
            new CuentaAcreedora("Aumento en cuentas por cobrar", "Activo"),
            new CuentaDeudora("Disminución en cuentas por cobrar", "Activo"),
            new CuentaAcreedora("Aumento en inventarios", "Activo"),
            new CuentaDeudora("Disminución en inventarios", "Activo"),
            new CuentaAcreedora("Aumento en gastos pagados por anticipado", "Activo"),
            new CuentaDeudora("Disminución en gastos pagados por anticipado", "Activo"),
            new CuentaDeudora("Aumento en proveedores", "Pasivo"),
            new CuentaAcreedora("Disminución en proveedores", "Pasivo"),
            new CuentaDeudora("Aumento en cuentas por pagar", "Pasivo"),
            new CuentaAcreedora("Disminución en cuentas por pagar", "Pasivo"),
            new CuentaDeudora("Aumento en impuestos por pagar", "Pasivo"),
            new CuentaAcreedora("Disminución en impuestos por pagar", "Pasivo")
        };
        public static readonly List<Cuenta> ActividadesInversion = new List<Cuenta>()
        {
            new CuentaAcreedora("Compra de terrenos", "Activo"),
            new CuentaDeudora("Venta de terrenos", "Activo"),
            new CuentaAcreedora("Compra de edificios", "Activo"),
            new CuentaDeudora("Venta de edificios", "Activo"),
            new CuentaAcreedora("Compra de maquinaria y equipo", "Activo"),
            new CuentaDeudora("Venta de maquinaria y equipo", "Activo"),
            new CuentaAcreedora("Compra de equipo de transporte", "Activo"),
            new CuentaDeudora("Venta de equipo de transporte", "Activo"),
            new CuentaAcreedora("Compra de mobiliario y equipo de oficina", "Activo"),
            new CuentaDeudora("Venta de mobiliario y equipo de oficina", "Activo"),
            new CuentaAcreedora("Adquisición de inversiones temporales", "Activo"),
            new CuentaDeudora("Venta de inversiones temporales", "Activo"),
            new CuentaAcreedora("Adquisición de inversiones permanentes", "Activo"),
            new CuentaDeudora("Venta de inversiones permanentes", "Activo"),
            new CuentaAcreedora("Préstamos otorgados", "Activo"),
            new CuentaDeudora("Cobro de préstamos otorgados", "Activo")
        };
        public static readonly List<Cuenta> ActividadesFinanciamiento = new List<Cuenta>()
        {
            new CuentaDeudora("Aportaciones de capital", "Capital"),
            new CuentaAcreedora("Reembolso de capital", "Capital"),
            new CuentaDeudora("Préstamos bancarios obtenidos", "Pasivo"),
            new CuentaAcreedora("Pago de préstamos bancarios", "Pasivo"),
            new CuentaDeudora("Emisión de obligaciones", "Pasivo"),
            new CuentaAcreedora("Amortización de obligaciones", "Pasivo"),
            new CuentaDeudora("Emisión de acciones", "Capital"),
            new CuentaAcreedora("Recompra de acciones", "Capital"),
            new CuentaAcreedora("Pago de dividendos", "Capital"),
            new CuentaDeudora("Aportaciones para futuros aumentos de capital", "Capital"),
            new CuentaDeudora("Documentos por pagar a largo plazo obtenidos", "Pasivo"),
            new CuentaAcreedora("Pago de documentos por pagar a largo plazo", "Pasivo"),
            new CuentaDeudora("Arrendamiento financiero", "Pasivo"),
            new CuentaAcreedora("Pago de arrendamiento financiero", "Pasivo")
        };
    }
}
