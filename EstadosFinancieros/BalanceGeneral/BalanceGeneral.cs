using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.AccionesVerCuentas;
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
                        AccionCalcularBalanceGeneral.Ejecutar();
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
        }

        private static void VerCuentas()
        {
            bool regresar = false;

            while (!regresar)
            {
                int opcion = MostrarMenuVerCuentas();

                switch (opcion)
                {
                    case 1:
                        MostrarTodasCuentasBalanceGeneral();
                        break;
                    case 2:
                        MostrarCuentasGeneralesBalanceGeneral();
                        break;
                    case 3:
                        MostrarCuentasSubclasificadasBalanceGeneral();
                        break;
                    case 0:
                        regresar = true;
                        break;
                }
            }
        }

        public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas)
        {
            MostrarTituloSubrayado(titulo, true);

            foreach (var cuenta in listaDeCuentas)
            {
                string naturaleza = cuenta.EsDeudora ? "[ Deudora   ]" : "[ Acreedora ]";
                Console.WriteLine($"\t{naturaleza} \t{cuenta.Nombre} ");
            }
        }
    }
}
