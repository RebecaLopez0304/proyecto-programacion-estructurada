using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Catalogos
{
    /// <summary>
    /// Cuentas predefinidas del Balance General, agrupadas por subclasificación.
    /// Cada cuenta es <c>CuentaDeudora</c> o <c>CuentaAcreedora</c>; el usuario puede
    /// agregar o eliminar cuentas de estas listas en tiempo de ejecución.
    /// </summary>
    public static class CuentasBalanceGeneral
    {
        public static List<Cuenta> ActivoCirculante = new List<Cuenta>()
        {
            new CuentaDeudora("Caja General"),
            new CuentaDeudora("Fondo fijo de caja chica"),
            new CuentaDeudora("Fondo de oportunidades"),
            new CuentaDeudora("Bancos"),
            new CuentaAcreedora("Estimacion por cuentas incobrables"),
            new CuentaDeudora("Inversiones temporales"),
            new CuentaDeudora("Inversiones de mercancia"),
            new CuentaDeudora("Clientes"),
            new CuentaDeudora("Documentos por Cobrar"),
            new CuentaDeudora("Deudores"),
            new CuentaDeudora("Funcionarios y empleados"),
            new CuentaDeudora("IVA acreditable"),
            new CuentaDeudora("Anticipo de impuestos"),
            new CuentaDeudora("Mercancía en tránsito"),
            new CuentaDeudora("Anticipo a proveedores"),
            new CuentaDeudora("Credito mercantil"),
            new CuentaDeudora("Papelería y útiles"),
            new CuentaDeudora("Propaganda y publicidad"),
            new CuentaDeudora("Muestras médicas y literaturas"),
            new CuentaDeudora("Primas a seguros y fianzas"),
            new CuentaDeudora("Rentas pagadas por anticipado"),
            new CuentaDeudora("Intereses pagados por anticipado"),
            new CuentaDeudora("Otros"),
        };
        public static List<Cuenta> ActivoFijo = new List<Cuenta>()
        {
            new CuentaDeudora("Terrenos"),
            new CuentaDeudora("Edificios"),
            new CuentaAcreedora("depreciacion acumulada de edificio"),
            new CuentaDeudora("Construcciones en proceso"),
            new CuentaDeudora("Maquinaria y equipo"),
            new CuentaAcreedora("depreciacion acumulada de maquinaria y equipo obras en proceso"),
            new CuentaDeudora("Mobiliario y equipos de oficina"),
            new CuentaAcreedora("depreciacion acumulada de mobiliario y equipo de oficina,"),
            new CuentaDeudora("Muebles y enseres"),
            new CuentaDeudora("Equipo de transporte"),
            new CuentaAcreedora("depreciacion acumulada de equipo de transporte"),
            new CuentaDeudora("Equipo de entrega y reparto"),
            new CuentaDeudora("Equipo de computo"),
            new CuentaAcreedora("depreciacion acumulada de equipo de computo"),
        };
        public static List<Cuenta> ActivoIntangible = new List<Cuenta>()
        {
            new CuentaDeudora("Derechos de autor"),
            new CuentaDeudora("Patentes"),
            new CuentaDeudora("Marcas registradas"),
            new CuentaDeudora("Nombres comerciales"),
            new CuentaDeudora("Crédito comercial"),
            new CuentaDeudora("Gastos pre operativos"),
            new CuentaDeudora("Descuentos en emisiones de obligaciones"),
            new CuentaDeudora("Gastos en colocación de valores"),
            new CuentaDeudora("Gastos de constitución"),
            new CuentaDeudora("Gastos de organización e institución"),
            new CuentaAcreedora("amortización de gastos de organización e institución"),
            new CuentaDeudora("Gastos de instalación"),
            new CuentaDeudora("Papelería y útiles"),
            new CuentaDeudora("Propaganda y publicidad"),
            new CuentaDeudora("Primas de seguros y fianzas"),
            new CuentaDeudora("franquicias"),
            new CuentaDeudora("Intereses pagados por anticipado"),
        };
        public static List<Cuenta> OtrosActivos = new List<Cuenta>()
        {
            new CuentaDeudora("Fondo de amortizaciones de obligaciones"),
            new CuentaDeudora("Depósito en garantía"),
            new CuentaDeudora("Inversiones en proceso"),
            new CuentaDeudora("Terrenos no utilizados"),
            new CuentaDeudora("Maquinaria no utilizada"),
            new CuentaDeudora("Rentas pagadas por anticipado")
        };
        public static List<Cuenta> PasivoLargoPlazo = new List<Cuenta>()
        {
            new CuentaAcreedora("Acreedores hipotecarios"),
            new CuentaAcreedora("Acreedores bancarios"),
            new CuentaAcreedora("Documentos por pagar a largo plazo"),
            new CuentaAcreedora("Obligaciones a circulación"),
            new CuentaAcreedora("Bonos por pagar"),
            new CuentaAcreedora("Acreedores diversos a largo plazo"),
            new CuentaAcreedora("Hipotecas por pagar"),
            new CuentaAcreedora("Obligaciones por pagar"),
        };
        public static List<Cuenta> PasivoCortoPlazo = new List<Cuenta>()
        {
            new CuentaAcreedora("Proveedores"),
            new CuentaAcreedora("cuentas por pagar"),
            new CuentaAcreedora("Documentos por pagar"),
            new CuentaAcreedora("Acreedores diversos"),
            new CuentaAcreedora("Acreedores bancarios"),
            new CuentaAcreedora("Anticipo de clientes"),
            new CuentaAcreedora("Dividendos por pagar"),
            new CuentaAcreedora("IVA por pagar"),
            new CuentaAcreedora("Impuestos sobre la renta por pagar"),
            new CuentaAcreedora("Impuestos y derechos retenidos por enterar"),
            new CuentaAcreedora("Intereses por pagar"),
            new CuentaAcreedora("Gastos acumulados por pagar"),
            new CuentaAcreedora("Ingresos cobrados por anticipado"),
            new CuentaAcreedora("Rentas cobradas por anticipado"),
            new CuentaAcreedora("Intereses cobrados por anticipado"),
        };
        public static List<Cuenta> CapitalContribuido = new List<Cuenta>()
        {
            new CuentaAcreedora("Capital social"),
            new CuentaAcreedora("Aportaciones para futuros aumentos de capital"),
            new CuentaAcreedora("Prima en ventas de acciones"),
            new CuentaAcreedora("Donacione"),
        };
        public static List<Cuenta> CapitalGanado = new List<Cuenta>()
        {
            new CuentaAcreedora("Utilidades retenidas"),
            new CuentaAcreedora("Reserva legal"),
            new CuentaDeudora("Pérdidas acumuladas"),
            new CuentaDeudora("Utilidad de ejercicio"),
            new CuentaAcreedora("Perdida del ejercicio"),
            new CuentaAcreedora("Resultado de ejercicio anteriores"),
            new CuentaAcreedora("Reservas"),
        };
    }
}
