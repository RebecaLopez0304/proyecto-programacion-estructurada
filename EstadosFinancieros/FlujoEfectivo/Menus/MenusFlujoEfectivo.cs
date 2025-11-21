using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus
{
    /*
    ===========================
        Menus del Flujo de Efectivo
    ===========================
    
    TODO: Crear todas las funciones de menú necesarias siguiendo el patrón de MenusBalanceGeneral.cs
    
    Funciones requeridas (como mínimo):
    1. MostrarMenuPrincipal() - Menú principal del módulo
    2. MostrarMenuVerCuentas() - Opciones para ver cuentas
    3. MostrarMenuActividades() - Seleccionar actividad (Operación/Inversión/Financiamiento)
    4. MostrarMenuActividadesConSalida() - Igual que anterior pero con opción "0. Terminar"
    5. MostrarMenuTipoMovimiento() - Seleccionar si es entrada [+] o salida [-] de efectivo
    6. MostrarMenuConfirmacion(string mensaje) - Confirmar acción
    7. MostrarMenuContinuar() - ¿Desea agregar otra cuenta?
    
    Actividades del Flujo de Efectivo:
    1. Actividades de Operación (operaciones normales del negocio)
    2. Actividades de Inversión (compra/venta de activos fijos)
    3. Actividades de Financiamiento (préstamos y capital)
    
    IMPORTANTE: Todas las funciones deben ser públicas y estáticas
    */
    public static class MenusFlujoEfectivo
    {
        // TODO: Implementar todos los métodos de menú necesarios
        
        // Ejemplo de firma de método:
        // public static int MostrarMenuPrincipal()
        // {
        //     MostrarLineaDivisoraConTexto("Flujo de Efectivo", true, true);
        //     Console.WriteLine("1. Ver Cuentas");
        //     Console.WriteLine("2. Agregar Cuenta");
        //     Console.WriteLine("3. Eliminar Cuenta");
        //     Console.WriteLine("4. Calcular Flujo de Efectivo");
        //     MostrarLineaDivisora(true, true);
        //     Console.WriteLine("0. Volver");
        //     return SolicitarEnteroConLimites(0, 4);
        // }
    }
}
