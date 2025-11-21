using System.Security.Cryptography.X509Certificates;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos.CuentasEstadoResultados;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.EstadoResultados;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;
namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones
{
    /*
    ===========================
        Acciones para Ver Cuentas - Estado de Resultados
    ===========================
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
