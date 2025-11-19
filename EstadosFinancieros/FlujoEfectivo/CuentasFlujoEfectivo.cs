using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo
{
    /*
    ===========================
        Cuentas del Flujo de Efectivo
    ===========================
    
    TODO: Cambiar las listas de 'readonly' a modificables para permitir agregar/eliminar cuentas.
    Ejemplo: public static List<Cuenta> ActividadesOperacion = new()
    
    IMPORTANTE: Las cuentas del sistema deben inicializarse con EsCreadoPorUsuario = false
    para que no puedan ser eliminadas por el usuario.
    
    Naturaleza en Flujo de Efectivo:
    - EsDeudora = true [+]: ENTRADA de efectivo (aumenta el efectivo)
    - EsDeudora = false [-]: SALIDA de efectivo (disminuye el efectivo)
    
    Actividades:
    1. Operación: Actividades principales del negocio (ventas, compras, pagos)
    2. Inversión: Compra/venta de activos fijos e inversiones
    3. Financiamiento: Préstamos, aportaciones de capital, dividendos
    */
    public static class CuentasFlujoEfectivo
    {
        // TODO: Cambiar de 'readonly' a modificable
        // TODO: Todas las cuentas deben tener EsCreadoPorUsuario = false en su inicialización
        public static readonly List<Cuenta> ActividadesOperacion = new()
        {
            new Cuenta("Utilidad o pérdida neta del ejercicio", true),
            new Cuenta("Depreciación de activo fijo", true), // Se suma (no es salida de efectivo)
            new Cuenta("Amortización de activos intangibles", true), // Se suma
            new Cuenta("Estimación para cuentas incobrables", true), // Se suma
            new Cuenta("Pérdida por venta de activo fijo", true), // Se suma
            new Cuenta("Utilidad por venta de activo fijo", false), // Se resta
            new Cuenta("Aumento en cuentas por cobrar", false), // Se resta (disminuye efectivo)
            new Cuenta("Disminución en cuentas por cobrar", true), // Se suma (aumenta efectivo)
            new Cuenta("Aumento en inventarios", false), // Se resta
            new Cuenta("Disminución en inventarios", true), // Se suma
            new Cuenta("Aumento en gastos pagados por anticipado", false), // Se resta
            new Cuenta("Disminución en gastos pagados por anticipado", true), // Se suma
            new Cuenta("Aumento en proveedores", true), // Se suma (aumenta efectivo)
            new Cuenta("Disminución en proveedores", false), // Se resta
            new Cuenta("Aumento en cuentas por pagar", true), // Se suma
            new Cuenta("Disminución en cuentas por pagar", false), // Se resta
            new Cuenta("Aumento en impuestos por pagar", true), // Se suma
            new Cuenta("Disminución en impuestos por pagar", false) // Se resta
        };

        // ACTIVIDADES DE INVERSIÓN
        public static readonly List<Cuenta> ActividadesInversion = new()
        {
            new Cuenta("Compra de terrenos", false), // Salida de efectivo (se resta)
            new Cuenta("Venta de terrenos", true), // Entrada de efectivo (se suma)
            new Cuenta("Compra de edificios", false),
            new Cuenta("Venta de edificios", true),
            new Cuenta("Compra de maquinaria y equipo", false),
            new Cuenta("Venta de maquinaria y equipo", true),
            new Cuenta("Compra de equipo de transporte", false),
            new Cuenta("Venta de equipo de transporte", true),
            new Cuenta("Compra de mobiliario y equipo de oficina", false),
            new Cuenta("Venta de mobiliario y equipo de oficina", true),
            new Cuenta("Adquisición de inversiones temporales", false),
            new Cuenta("Venta de inversiones temporales", true),
            new Cuenta("Adquisición de inversiones permanentes", false),
            new Cuenta("Venta de inversiones permanentes", true),
            new Cuenta("Préstamos otorgados", false),
            new Cuenta("Cobro de préstamos otorgados", true)
        };

        // ACTIVIDADES DE FINANCIAMIENTO
        public static readonly List<Cuenta> ActividadesFinanciamiento = new()
        {
            new Cuenta("Aportaciones de capital", true), // Entrada de efectivo
            new Cuenta("Reembolso de capital", false), // Salida de efectivo
            new Cuenta("Préstamos bancarios obtenidos", true),
            new Cuenta("Pago de préstamos bancarios", false),
            new Cuenta("Emisión de obligaciones", true),
            new Cuenta("Amortización de obligaciones", false),
            new Cuenta("Emisión de acciones", true),
            new Cuenta("Recompra de acciones", false),
            new Cuenta("Pago de dividendos", false),
            new Cuenta("Aportaciones para futuros aumentos de capital", true),
            new Cuenta("Documentos por pagar a largo plazo obtenidos", true),
            new Cuenta("Pago de documentos por pagar a largo plazo", false),
            new Cuenta("Arrendamiento financiero", true),
            new Cuenta("Pago de arrendamiento financiero", false)
        };
    }
}
