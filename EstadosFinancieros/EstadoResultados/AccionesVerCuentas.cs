using System.Security.Cryptography.X509Certificates;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.CuentasEstadoResultados;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.EstadoResultados;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.MenusEstadoResultados;
namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    /*
    ===========================
        Acciones para Ver Cuentas - Estado de Resultados
    ===========================
    
    


    TODO: Implementar métodos para visualizar las cuentas del Estado de Resultados
    Seguir el patrón de AccionesVerCuentas.cs del Balance General
    
    Métodos requeridos:
    1. MostrarTodasCuentasEstadoResultados() - Mostrar todas las categorías con sus cuentas
    2. MostrarCuentasGeneralesEstadoResultados() - Vista general (Ingresos, Costos, Gastos, Impuestos)
    3. MostrarCuentasSubclasificadasEstadoResultados() - Vista detallada por cada categoría
    
    Categorías a mostrar:
    - Ingresos
    - Costo de Ventas
    - Gastos de Venta
    - Gastos de Administración
    - Gastos Financieros
    - Productos Financieros
    - Otros Gastos
    - Otros Productos
    - Impuestos
    
    IMPORTANTE: Usar EstadoResultados.MostrarSeccion() para mostrar cada lista de cuentas
    */
    public static class AccionesVerCuentas
    {
        public static void MostrarTodoER()
        {
            MostrarLineaDivisoraConTexto("Todas las Cuentas - Estado de Resultados", true, false);

            // MostrarLineaDivisoraConTexto("INGRESOS", true);
            MostrarSeccion("Ventas", Ventas, true);
            MostrarSeccion("Costos de ventas", CostoDeVentas, true);
            MostrarSeccion("Gastos de operación", GastoDeOperacion, true);
            MostrarSeccion("Gastos de administración", GastosAdministracion, true);
            MostrarSeccion("Gastos y productos financieros", OtrosResultadosFinancieros, true);

            EsperarTecla();
        }

        public static void MostrarPorCategoriaER()
        {
            bool salir = false;
            while (!salir)
            {
                int opcion = MenuPorCategoriaER();

                switch (opcion)
                {
                    case 1:
                        MostrarSeccion("Ventas", Ventas, true);
                        EsperarTecla();
                        break;

                    case 2:
                        MostrarSeccion("Costos de ventas", CostoDeVentas, true);
                        EsperarTecla();
                        break;

                    case 3:
                        MostrarSeccion("Gastos de operación", GastoDeOperacion, true);
                        EsperarTecla();
                        break;

                    case 4:
                        MostrarSeccion("Gastos de administración", GastosAdministracion, true);
                        EsperarTecla();
                        break;

                    case 5:
                        MostrarSeccion("Gastos y productos financieros", OtrosResultadosFinancieros, true);
                        EsperarTecla();
                        break;

                    case 0:
                        salir = true;
                        break;

                    default:
                        MostrarMensajeError("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
