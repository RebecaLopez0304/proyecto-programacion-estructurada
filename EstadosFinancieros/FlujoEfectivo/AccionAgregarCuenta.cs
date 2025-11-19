using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.MenusFlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo
{
    /*
    ===========================
        Acción Agregar Cuenta - Flujo de Efectivo
    ===========================
    
    TODO: Implementar la lógica para agregar nuevas cuentas al Flujo de Efectivo
    Seguir el patrón de AccionAgregarCuenta.cs del Balance General
    
    Flujo requerido:
    1. Mostrar menú de actividades (MenusFlujoEfectivo.MostrarMenuActividades())
    2. Solicitar nombre de la cuenta
    3. Solicitar tipo de movimiento (Entrada [+] / Salida [-]) usando MostrarMenuTipoMovimiento()
    4. Crear nueva instancia de Cuenta con EsCreadoPorUsuario = true
       - Si es ENTRADA: EsDeudora = true
       - Si es SALIDA: EsDeudora = false
    5. Agregar a la lista correspondiente según la actividad seleccionada
    6. Mostrar mensaje de éxito con MostrarMensajeExito()
    
    Actividades disponibles (3):
    1. Actividades de Operación -> CuentasFlujoEfectivo.ActividadesOperacion
    2. Actividades de Inversión -> CuentasFlujoEfectivo.ActividadesInversion
    3. Actividades de Financiamiento -> CuentasFlujoEfectivo.ActividadesFinanciamiento
    
    IMPORTANTE: 
    - Marcar SIEMPRE la cuenta como EsCreadoPorUsuario = true
    - En Flujo de Efectivo: EsDeudora = true significa ENTRADA [+]
    - En Flujo de Efectivo: EsDeudora = false significa SALIDA [-]
    */
    public static class AccionAgregarCuenta
    {
        public static void Ejecutar()
        {
            // TODO: Implementar toda la lógica de agregar cuenta
            // Seguir el patrón exacto de Balance General
            
            MostrarMensajeAdvertencia("Esta funcionalidad aun no esta implementada.", true, true);
            EsperarTecla();
        }
    }
}
