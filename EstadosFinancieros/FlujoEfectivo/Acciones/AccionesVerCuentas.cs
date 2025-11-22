using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos.CuentasFlujoEfectivo;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.FlujoEfectivo;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones
{
    /*
    ===========================
        Acciones para Ver Cuentas - Flujo de Efectivo
    ===========================
    */
    public static class AccionesVerCuentas
    {
        // MARK: - Visualización de Todas las Cuentas

        public static void MostrarTodasCuentasFlujoEfectivo()
        {
            MostrarLineaDivisoraConTexto("Todas las Cuentas - Flujo de Efectivo", true, true);
            MostrarSeccion("Actividades Operación", ActividadesOperacion);
            MostrarSeccion("Actividades Inversión", ActividadesInversion);
            MostrarSeccion("Actividades Financiamiento", ActividadesFinanciamiento);
            EsperarTecla();
        }

        // MARK: - Visualización de Cuentas por Actividad

        public static void MostrarCuentasPorActividad()
        {
            bool salir = false;

            while (!salir)
            {
                int opcion = MostrarMenuActividades();

                switch (opcion)
                {
                    case 1:
                        MostrarSeccion("Actividades de Operación", ActividadesOperacion);
                        EsperarTecla();
                        break;

                    case 2:
                        MostrarSeccion("Actividades de Inversión", ActividadesInversion);
                        EsperarTecla();
                        break;

                    case 3:
                        MostrarSeccion("Actividades de Financiamiento", ActividadesFinanciamiento);
                        EsperarTecla();
                        break;

                    case 0:
                        salir = true;
                        break;

                    default:
                        MostrarMensajeError("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
