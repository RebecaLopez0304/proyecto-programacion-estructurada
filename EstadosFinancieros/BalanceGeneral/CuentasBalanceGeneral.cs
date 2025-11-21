using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    // Aquí definimos las listas de cuentas que usa el Balance General
    // Cada lista representa una subclasificación y contiene objetos `Cuenta`
    public static class CuentasBalanceGeneral
    {
        // Activos: cosas que posee la empresa y que tienen valor
        public static List<Cuenta> ActivoCirculante = new()
        {
            // (+) Dinero en efectivo disponible en caja
            new Cuenta("Caja General", true),

            // (+) Efectivo destinado a gastos menores
            new Cuenta("Fondo fijo de caja chica", true),

            // (+) Efectivo reservado para oportunidades de inversión
            new Cuenta("Fondo de oportunidades", true),

            // (+) Dinero disponible en cuentas bancarias
            new Cuenta("Bancos", true),

            // (-) Provisión para cuentas que no se podrán cobrar, disminuye el valor de clientes
            new Cuenta("Estimacion por cuentas incobrables", false),

            // (+) Inversiones financieras a corto plazo (menos de 1 año)
            new Cuenta("Inversiones temporales", true),

            // (+) Productos disponibles para la venta
            new Cuenta("Inversiones de mercancia", true),

            // (+) Dinero que los clientes deben por ventas a crédito
            new Cuenta("Clientes", true),

            // (+) Pagarés o letras a favor de la empresa
            new Cuenta("Documentos por Cobrar", true),

            // (+) Personas o empresas que deben dinero por conceptos diferentes a ventas
            new Cuenta("Deudores", true),

            // (+) Préstamos o anticipos otorgados a empleados
            new Cuenta("Funcionarios y empleados", true),

            // (+) IVA pagado en compras que se puede recuperar
            new Cuenta("IVA acreditable", true),

            // (+) Impuestos pagados por anticipado
            new Cuenta("Anticipo de impuestos", true),

            // (+) Mercancía comprada pero aún no recibida
            new Cuenta("Mercancía en tránsito", true),

            // (+) Pagos adelantados a proveedores
            new Cuenta("Anticipo a proveedores", true),

            // (+) Valor de la reputación y clientela de la empresa
            new Cuenta("Credito mercantil", true),

            // (+) Material de oficina disponible
            new Cuenta("Papelería y útiles", true),

            // (+) Gastos de publicidad pagados por anticipado
            new Cuenta("Propaganda y publicidad", true),

            // (+) Material promocional disponible
            new Cuenta("Muestras médicas y literaturas", true),

            // (+) Seguros pagados por anticipado
            new Cuenta("Primas a seguros y fianzas", true),

            // (+) Alquileres pagados por adelantado
            new Cuenta("Rentas pagadas por anticipado", true),

            // (+) Intereses pagados antes del vencimiento
            new Cuenta("Intereses pagados por anticipado", true),

            // (+) Otros activos circulantes no clasificados
            new Cuenta("Otros", true),
        };

        // Activo fijo: bienes duraderos como terrenos y maquinaria
        public static List<Cuenta> ActivoFijo = new()
        {
            // (+) Propiedades de tierra de la empresa
            new Cuenta("Terrenos", true),

            // (+) Construcciones propiedad de la empresa
            new Cuenta("Edificios", true),

            // (-) Pérdida de valor acumulada del edificio por uso y tiempo, disminuye el valor del activo
            new Cuenta("depreciacion acumulada de edificio", false),

            // (+) Obras en construcción aún no terminadas
            new Cuenta("Construcciones en proceso", true),

            // (+) Equipos de producción de la empresa
            new Cuenta("Maquinaria", true),

            // (+) Muebles y equipos para oficinas
            new Cuenta("Mobiliario y equipos de oficina", true),

            // (+) Mobiliario en general del negocio
            new Cuenta("Muebles y enseres", true),

            // (+) Vehículos propiedad de la empresa
            new Cuenta("Equipo de transporte", true),

            // (+) Vehículos destinados a distribución
            new Cuenta("Equipo de entrega y reparto", true),
        };

        // Activos intangibles: valores no físicos como marcas o patentes
        public static List<Cuenta> ActivoIntangible = new()
        {
            // (+) Derechos legales sobre obras creativas
            new Cuenta("Derechos de autor", true),

            // (+) Derechos exclusivos sobre invenciones
            new Cuenta("Patentes", true),

            // (+) Derechos sobre signos distintivos
            new Cuenta("Marcas registradas", true),

            // (+) Derechos sobre el nombre de la empresa
            new Cuenta("Nombres comerciales", true),

            // (+) Plusvalía o goodwill de la empresa
            new Cuenta("Crédito comercial", true),

            // (+) Gastos realizados antes de iniciar operaciones
            new Cuenta("Gastos pre operativos", true),

            // (+) Diferencia entre valor nominal y precio de venta de bonos
            new Cuenta("Descuentos en emisiones de obligaciones", true),

            // (+) Costos de emisión de acciones o bonos
            new Cuenta("Gastos en colocación de valores", true),

            // (+) Costos legales de formar la empresa
            new Cuenta("Gastos de constitución", true),

            // (+) Gastos de establecer la estructura organizacional
            new Cuenta("Gastos de organización e institución", true),

            // (-) Disminución acumulada del valor de gastos diferidos por el paso del tiempo
            new Cuenta("amortización de gastos de organización e institución", false),

            // (+) Costos de adaptar instalaciones para operación
            new Cuenta("Gastos de instalación", true),

            // (+) Suministros de oficina
            new Cuenta("Papelería y útiles", true),

            // (+) Gastos publicitarios pagados por anticipado
            new Cuenta("Propaganda y publicidad", true),

            // (+) Seguros pagados por adelantado
            new Cuenta("Primas de seguros y fianzas", true),

            // (+) Material promocional y educativo
            new Cuenta("Muestras médicas y literatura", true),

            // (+) Alquileres pagados antes de su vencimiento
            new Cuenta("Rentas pagadas por anticipado", true),

            // (+) Intereses pagados antes de devengarse
            new Cuenta("Intereses pagados por anticipado", true),
        };

        // Otros activos: elementos que no encajan en las categorías anteriores
        public static List<Cuenta> OtrosActivos = new()
        {
            // (+) Reserva para pago de bonos u obligaciones
            new Cuenta("Fondo de amortizaciones de obligaciones", true),

            // (+) Dinero dado como garantía de cumplimiento
            new Cuenta("Depósito en garantía", true),

            // (+) Inversiones a largo plazo en desarrollo
            new Cuenta("Inversiones en proceso", true),

            // (+) Propiedades sin uso operativo actual
            new Cuenta("Terrenos no utilizados", true),

            // (+) Equipo fuera de operación
            new Cuenta("Maquinaria no utilizada", true),
        };

        // PASIVOS: obligaciones y deudas de la empresa
        public static List<Cuenta> PasivoLargoPlazo = new()
        {
            // (-) Deudas garantizadas con hipoteca, vencimiento mayor a 1 año
            new Cuenta("Acreedores hipotecarios", false),

            // (-) Préstamos bancarios a largo plazo
            new Cuenta("Acreedores bancarios", false),

            // (-) Pagarés con vencimiento mayor a 1 año
            new Cuenta("Documentos por pagar a largo plazo", false),

            // (-) Bonos emitidos por la empresa
            new Cuenta("Obligaciones a circulación", false),

            // (-) Títulos de deuda a largo plazo emitidos
            new Cuenta("Bonos por pagar", false),
        };

        public static List<Cuenta> PasivoCortoPlazo = new()
        {
            // (-) Deudas con proveedores por compras a crédito
            new Cuenta("Proveedores", false),

            // (-) Obligaciones de pago a corto plazo
            new Cuenta("cuentas por pagar", false),

            // (-) Pagarés con vencimiento menor a 1 año
            new Cuenta("Documentos por pagar", false),

            // (-) Deudas con terceros por conceptos distintos a compras
            new Cuenta("Acreedores diversos", false),

            // (-) Préstamos bancarios a corto plazo
            new Cuenta("Acreedores bancarios", false),

            // (-) Pagos recibidos antes de entregar productos/servicios
            new Cuenta("Anticipo de clientes", false),

            // (-) Utilidades declaradas pendientes de pago a accionistas
            new Cuenta("Dividendos por pagar", false),

            // (-) IVA cobrado en ventas pendiente de enterar al fisco
            new Cuenta("IVA por pagar", false),

            // (-) ISR pendiente de pago
            new Cuenta("Impuestos sobre la renta por pagar", false),

            // (-) Retenciones fiscales pendientes de enterar
            new Cuenta("Impuestos y derechos retenidos por enterar", false),

            // (-) Intereses devengados pendientes de pago
            new Cuenta("Intereses por pagar", false),

            // (-) Gastos devengados aún no pagados
            new Cuenta("Gastos acumulados por pagar", false),

            // (-) Ingresos recibidos antes de prestar el servicio
            new Cuenta("Ingresos cobrados por anticipado", false),

            // (-) Alquileres cobrados antes de su vencimiento
            new Cuenta("Rentas cobradas por anticipado", false),

            // (-) Intereses cobrados antes de devengarse
            new Cuenta("Intereses cobrados por anticipado", false),
        };

        // CAPITAL: aportaciones de dueños y utilidades acumuladas
        public static List<Cuenta> CapitalContribuido = new()
        {
            // (-) Aportaciones de los socios o accionistas
            new Cuenta("Capital social", false),

            // (-) Recursos aportados pendientes de formalizar como capital
            new Cuenta("Aportaciones para futuros aumentos de capital", false),

            // (-) Excedente sobre valor nominal en venta de acciones
            new Cuenta("Prima en ventas de acciones", false),

            // (-) Bienes recibidos gratuitamente
            new Cuenta("Donacione", false),
        };

        public static List<Cuenta> CapitalGanado = new()
        {
            // (-) Ganancias acumuladas no distribuidas
            new Cuenta("Utilidades retenidas", false),

            // (-) Utilidades apartadas por disposición legal
            new Cuenta("Reserva legal", false),

            // (+) Pérdidas no compensadas que disminuyen el capital contable
            new Cuenta("Pérdidas acumuladas", true),
        };
    }
}
