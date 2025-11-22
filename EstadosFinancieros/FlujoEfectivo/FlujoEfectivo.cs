using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo
{

    //===========================
    //     Clase Flujo de Efectivo
    //===========================

    public static class FlujoEfectivo
    {
        public static void Ejecutar()
        {
            // Bandera para mantener el menú hasta que el usuario pida salir
            bool volver = false;

            // Bucle principal del módulo: muestra el menú repetidamente
            while (!volver)
            {
                // Pide la opción al usuario
                int opcion = MostrarMenuPrincipal();

                // Ejecuta la acción según la opción elegida
                switch (opcion)
                {
                    case 1:
                        // Ver listas de cuentas
                        VerCuentas();
                        break;
                    case 2:
                        // Agregar una cuenta nueva
                        AccionAgregarCuenta.Ejecutar();
                        break;
                    case 3:
                        // Eliminar una cuenta creada por el usuario
                        AccionEliminarCuenta.Ejecutar();
                        break;
                    case 4:
                        // Calcular el flujo de efectivo
                        AccionCalcularFlujoEfectivo.Ejecutar();
                        break;
                    case 0:
                        // Salir del módulo
                        volver = true;
                        Console.WriteLine("\n\n");
                        break;
                    default:
                        // Opción inválida: aviso simple
                        MostrarMensajeError("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }


        }
        private static void VerCuentas()
        {
            bool volver = false;
            while (!volver)
            {
                int opcion = MostrarMenuVerCuentas();

                switch (opcion)
                {
                    case 1:
                        AccionesVerCuentas.MostrarTodasCuentasFlujoEfectivo();
                        break;
                    case 2:
                        AccionesVerCuentas.MostrarCuentasPorActividad();
                        break;
                    case 0:
                        volver = true;
                        break;
                    default:
                        MostrarMensajeError("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }
        }

        public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas)
        {
            MostrarTituloSubrayado(titulo, true);

            foreach (var cuenta in listaDeCuentas)
            {
                string naturaleza = cuenta.EsDeudora ? "[ Entrada   ]" : "[ Salida    ]";
                Console.WriteLine($"\t{naturaleza} \t{cuenta.Nombre} ");
            }
        }
    }
}
