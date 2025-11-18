public static class CuentasBalanceGeneral
{
    // Activos
    public static readonly List<Cuenta> ActivoCirculante = new()
    {
        new Cuenta("Caja General"),
        new Cuenta("Fondo fijo de caja chica"),
        new Cuenta("Fondo de oportunidades"),
        new Cuenta("Bancos"),
        new Cuenta("Estimacion por cuentas incobrables"), // Puede ser negativo si las estimaciones superan el saldo de cuentas por cobrar (provisión mayor que el saldo)
        new Cuenta("Inversiones temporales"),
        new Cuenta("Inversiones de mercancia"),
        new Cuenta("Clientes"),
        new Cuenta("Documentos por Cobrar"),
        new Cuenta("Deudores"),
        new Cuenta("Funcionarios y empleados"),
        new Cuenta("IVA acreditable"),
        new Cuenta("Anticipo de impuestos"),
        new Cuenta("Mercancía en tránsito"),
        new Cuenta("Anticipo a proveedores"),
        new Cuenta("Credito mercantil"),
        new Cuenta("Papelería y útiles"),
        new Cuenta("Propaganda y publicidad"),
        new Cuenta("Muestras médicas y literaturas"),
        new Cuenta("Primas a seguros y fianzas"),
        new Cuenta("Rentas pagadas por anticipado"),
        new Cuenta("Intereses pagados por anticipado"),
        new Cuenta("Otros")
    };

    public static readonly List<Cuenta> ActivoFijo = new()
    {
        new Cuenta("Terrenos"),
        new Cuenta("Edificios"),
        new Cuenta("depreciacion acumulada de edificio"), // Siempre se refleja como negativo, representa la pérdida de valor del edificio
        new Cuenta("Construcciones en proceso"),
        new Cuenta("Maquinaria"),
        new Cuenta("Mobiliario y equipos de oficina"),
        new Cuenta("Muebles y enseres"),
        new Cuenta("Equipo de transporte"),
        new Cuenta("Equipo de entrega y reparto")
    };

    public static readonly List<Cuenta> ActivoIntangible = new()
    {
        new Cuenta("Derechos de autor"),
        new Cuenta("Patentes"),
        new Cuenta("Marcas registradas"),
        new Cuenta("Nombres comerciales"),
        new Cuenta("Crédito comercial"),
        new Cuenta("Gastos pre operativos"),
        new Cuenta("Descuentos en emisiones de obligaciones"),
        new Cuenta("Gastos en colocación de valores"),
        new Cuenta("Gastos de constitución"),
        new Cuenta("Gastos de organización e institución"),
        new Cuenta("amortización de gastos de organización e institución"), // Se refleja como negativo, representa la disminución del valor de los gastos diferidos
        new Cuenta("Gastos de instalación"),
        new Cuenta("Papelería y útiles"),
        new Cuenta("Propaganda y publicidad"),
        new Cuenta("Primas de seguros y fianzas"),
        new Cuenta("Muestras médicas y literatura"),
        new Cuenta("Rentas pagadas por anticipado"),
        new Cuenta("Intereses pagados por anticipado")
    };

    public static readonly List<Cuenta> OtrosActivos = new()
    {
        new Cuenta("Fondo de amortizaciones de obligaciones"),
        new Cuenta("Depósito en garantía"),
        new Cuenta("Inversiones en proceso"),
        new Cuenta("Terrenos no utilizados"),
        new Cuenta("Maquinaria no utilizada"),



    };

    // PASIVOS
    public static readonly List<Cuenta> PasivoLargoPlazo = new()
    {
         new Cuenta("Acreedores hipotecarios"),
         new Cuenta("Acreedores bancarios"),
         new Cuenta("Documentos por pagar a largo plazo"),
         new Cuenta("Obligaciones a circulación"),
         new Cuenta("Bonos por pagar"),

    };

    public static readonly List<Cuenta> PasivoCortoPlazo = new()
    {
        new Cuenta("Proveedores"),
        new Cuenta("cuentas por pagar"),
        new Cuenta("Documentos por pagar"),
        new Cuenta("Acreedores diversos"),
        new Cuenta("Acreedores bancarios"),
        new Cuenta("Anticipo de clientes"),
        new Cuenta("Dividendos por pagar"),
        new Cuenta("IVA por pagar"),
        new Cuenta("Impuestos sobre la renta por pagar"),
        new Cuenta("Impuestos y derechos retenidos por enterar"),
        new Cuenta("Intereses por pagar"),
        new Cuenta("Gastos acumulados por pagar"),
        new Cuenta("Ingresos cobrados por anticipado"),
        new Cuenta("Rentas cobradas por anticipado"),
        new Cuenta("Intereses cobrados por anticipado")
    };

    // CAPITAL
    public static readonly List<Cuenta> CapitalContribuido = new()
    {
        new Cuenta("Capital social"),
        new Cuenta("Aportaciones para futuros aumentos de capital"),
        new Cuenta("Prima en ventas de acciones"),
        new Cuenta("Donacione"),
    };

    public static readonly List<Cuenta> CapitalGanado = new()
    {
        new Cuenta("Utilidades retenidas"),
        new Cuenta("Reserva legal"),
        new Cuenta("Pérdidas acumuladas"), // Se refleja como negativo cuando existen pérdidas acumuladas en el capital ganado
    };
}
