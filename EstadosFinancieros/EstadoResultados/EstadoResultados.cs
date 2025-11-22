using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones.AccionesVerCuentas;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    /*
    ===========================
        Clase Estado de Resultados
    ===========================
    */
    public static class EstadoResultados
    {
        public static void Ejecutar()
        {
            bool volver = false;

            while (!volver)
            {
                int opcion = MostrarMenuPrincipal();

                switch (opcion)
                {
                    case 1:
                        VerCuentas();
                        break;
                    case 2:
                        AccionAgregarCuenta.Ejecutar();
                        break;
                    case 3:
                        AccionEliminarCuenta.Ejecutar();
                        break;
                    case 4:
                        AccionCalcularEstadoResultados.Ejecutar();
                        break;
                    case 0:
                        volver = true;
                        Console.WriteLine("\n\n");
                        break;
                    default:
                        MostrarMensajeError("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }
            MostrarMensajeAdvertencia("El modulo de Estado de Resultados aun no esta implementado.", true, true);
            MostrarMensajeAdvertencia("Debe seguir la misma estructura que Balance General.", true, false);
            EsperarTecla();
        }

        // MARK: Ver Cuentas
        private static void VerCuentas()
        {
            bool regresar = false;

            while (!regresar)
            {
                int opcion = MostrarMenuCuentas();

                switch (opcion)
                {
                    case 1:
                        MostrarTodoER();
                        break;
                    case 2:
                        MostrarPorCategoriaER();
                        break;
                    case 0:
                        regresar = true;
                        break;
                }
            }
        }

        // MARK: Mostrar Sección
        public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas, bool v)//
        {
            MostrarTituloSubrayado(titulo, true);

            foreach (var cuenta in listaDeCuentas)
            {
                string naturaleza = cuenta.EsDeudora ? "[ Egreso    ]" : "[ Ingreso   ]";
                Console.WriteLine($"\t{naturaleza} \t{cuenta.Nombre} ");
            }
        }

    }
}
