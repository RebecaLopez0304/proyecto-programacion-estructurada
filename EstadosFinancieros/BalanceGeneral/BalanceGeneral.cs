using ProyectoProgramacion.Comunes;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones.AccionesVerCuentas;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    /*
    ===========================
        Clase Balance General
    ===========================
    */
    public static class BalanceGeneral
    {
        // MARK: Inicio Balance general
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

        // MARK: Ver cuentas
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

        // MARK: Mostrar seccion por cuenta
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
