using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones
{
    /*
    ===========================
        Acción Eliminar Cuenta - Flujo de Efectivo
    ===========================
    
    TODO: Implementar la lógica para eliminar cuentas creadas por el usuario
    Seguir el patrón de AccionEliminarCuenta.cs del Balance General
    
    Flujo requerido:
    1. Recopilar todas las cuentas con EsCreadoPorUsuario == true de las 3 actividades
    2. Guardar en lista de tuplas: (cuenta, actividad, listaOriginal)
    3. Si no hay cuentas de usuario, mostrar MostrarMensajeAdvertencia() y salir
    4. Agrupar cuentas por actividad usando LINQ GroupBy
    5. Mostrar todas las cuentas numeradas globalmente
    6. Solicitar selección de cuenta a eliminar
    7. Mostrar confirmación con MostrarMenuConfirmacion()
    8. Si confirma: eliminar de la lista original y mostrar MostrarMensajeExito()
    9. Si cancela: mostrar MostrarMensajeCancelacion()
    
    Actividades a revisar (3):
    1. CuentasFlujoEfectivo.ActividadesOperacion
    2. CuentasFlujoEfectivo.ActividadesInversion
    3. CuentasFlujoEfectivo.ActividadesFinanciamiento
    
    IMPORTANTE:
    - SOLO eliminar cuentas con EsCreadoPorUsuario == true
    - Usar LINQ para agrupar y filtrar
    - Usar Dictionary<int, (Cuenta, List<Cuenta>)> para mapear números a cuentas
    - Mostrar [+] para entradas y [-] para salidas
    */
    public static class AccionEliminarCuenta
    {
        public static void Ejecutar()
        {
            // TODO: Implementar toda la lógica de eliminar cuenta
            // Seguir el patrón exacto de Balance General
            
            MostrarMensajeAdvertencia("Esta funcionalidad aun no esta implementada.", true, true);
            EsperarTecla();
        }
    }
}
