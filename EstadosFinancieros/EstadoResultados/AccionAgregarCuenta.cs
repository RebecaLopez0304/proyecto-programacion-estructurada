using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.MenusEstadoResultados;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    /*
    ===========================
        Acción Agregar Cuenta - Estado de Resultados
    ===========================
    
    TODO: Implementar la lógica para agregar nuevas cuentas al Estado de Resultados
    Seguir el patrón de AccionAgregarCuenta.cs del Balance General
    
    Flujo requerido:
    1. Mostrar menú de categorías (MenusEstadoResultados.MostrarMenuCategorias())
    2. Solicitar nombre de la cuenta
    3. Solicitar naturaleza (Deudora/Acreedora) usando MostrarMenuNaturalezaCuenta()
    4. Crear nueva instancia de Cuenta con EsCreadoPorUsuario = true
    5. Agregar a la lista correspondiente según la categoría seleccionada
    6. Mostrar mensaje de éxito con MostrarMensajeExito()
    
    Categorías disponibles (9):
    1. Ingresos -> CuentasEstadoResultados.Ingresos
    2. Costo de Ventas -> CuentasEstadoResultados.CostoVentas
    3. Gastos de Venta -> CuentasEstadoResultados.GastosVenta
    4. Gastos de Administración -> CuentasEstadoResultados.GastosAdministracion
    5. Gastos Financieros -> CuentasEstadoResultados.GastosFinancieros
    6. Productos Financieros -> CuentasEstadoResultados.ProductosFinancieros
    7. Otros Gastos -> CuentasEstadoResultados.OtrosGastos
    8. Otros Productos -> CuentasEstadoResultados.OtrosProductos
    9. Impuestos -> CuentasEstadoResultados.Impuestos
    
    IMPORTANTE: 
    - Marcar SIEMPRE la cuenta como EsCreadoPorUsuario = true
    - Usar switch expression para seleccionar la lista correcta
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
