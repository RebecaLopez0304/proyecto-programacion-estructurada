// Importa funcionalidades comunes del proyecto (por ejemplo, utilidades de consola)
using ProyectoProgramacion.Comunes;
// Importa métodos estáticos de Utilidades para usarlos directamente
using static ProyectoProgramacion.Comunes.Utilidades;
// Importa las acciones para ver cuentas del Balance General
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.AccionesVerCuentas;
// Importa los menús específicos del Balance General
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    /*
    ===========================
        Clase Balance General
    ===========================
    */
    public static class BalanceGeneral
    {
        // Punto de entrada para el módulo de Balance General
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
                        // Calcular el balance general con valores ingresados
                        AccionCalcularBalanceGeneral.Ejecutar();
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

        // Menú local para ver cuentas dentro del módulo Balance General
        private static void VerCuentas()
        {
            // Bandera para permanecer en el sub-menú hasta volver
            bool regresar = false;

            while (!regresar)
            {
                // Mostrar opciones y obtener elección
                int opcion = MostrarMenuVerCuentas();

                // Ejecutar la vista de cuentas correspondiente
                switch (opcion)
                {
                    case 1:
                        // Mostrar todas las cuentas agrupadas
                        MostrarTodasCuentasBalanceGeneral();
                        break;
                    case 2:
                        // Mostrar por secciones generales (Activos/Pasivos/Capital)
                        MostrarCuentasGeneralesBalanceGeneral();
                        break;
                    case 3:
                        // Mostrar por subclasificación más detallada
                        MostrarCuentasSubclasificadasBalanceGeneral();
                        break;
                    case 0:
                        // Volver al menú anterior
                        regresar = true;
                        break;
                }
            }
        }

        // Muestra una lista de cuentas con su 'naturaleza' (deudora/acreedora)
        public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas)
        {
            // Título con subrayado para separar secciones
            MostrarTituloSubrayado(titulo, true);

            // Para cada cuenta, mostramos si es Deudora (+) o Acreedora (-) y su nombre
            foreach (var cuenta in listaDeCuentas)
            {
                string naturaleza = cuenta.EsDeudora ? "[ Deudora   ]" : "[ Acreedora ]";
                Console.WriteLine($"\t{naturaleza} \t{cuenta.Nombre} ");
            }
        }
    }
}
