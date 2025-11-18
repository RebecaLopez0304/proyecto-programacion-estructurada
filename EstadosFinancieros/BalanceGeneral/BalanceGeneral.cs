using System;
using ProyectoProgramacion.Comunes;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.AccionesVerCuentas;

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
                int opcion = MostrarMenu();

                switch (opcion)
                {
                    case 1:
                        VerCuentas();
                        break;
                    case 2:
                        AgregarCuenta();
                        break;
                    case 3:
                        EliminarCuenta();
                        break;
                    case 4:
                        CalcularBalanceGeneral();
                        break;
                    case 0:
                        volver = true;
                        Console.WriteLine("\nVolviendo al Menu Principal...\n");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }
        }

        private static int MostrarMenu()
        {
            MostrarLineaDivisoraConTexto("Menu Balance General", true, true);
            MostrarTituloSubrayado("Seleccione una opcion (0-4):", false, true);
            Console.WriteLine("1. Ver Cuentas");
            Console.WriteLine("2. Agregar Cuenta");
            Console.WriteLine("3. Eliminar Cuenta");
            MostrarLineaDivisora(false, true);
            Console.WriteLine("4. Realizar calculo de Balance General");
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 4);
            return opcion;
        }

        private static void VerCuentas()
        {
            bool regresar = false;

            while (!regresar)
            {
                MostrarTituloSubrayado("Ver Cuentas - Balance General", true, true);
                Console.WriteLine("1. Ver todas las cuentas");
                Console.WriteLine("2. Ver cuentas generales (Activos, Pasivos, Capital)");
                Console.WriteLine("3. Ver cuentas subclasificadas");
                MostrarLineaDivisora(true, true);
                VolverAtras();

                int opcion = SolicitarEnteroConLimites(0, 3);

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

        private static void AgregarCuenta()
        {
            Console.WriteLine("\n=== Agregar Cuenta - Balance General ===");
            Console.WriteLine("Aqui se agregara una nueva cuenta al Balance General...");
            // TODO: Implementar logica para agregar cuenta
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void EliminarCuenta()
        {
            Console.WriteLine("\n=== Eliminar Cuenta - Balance General ===");
            Console.WriteLine("Aqui se eliminara una cuenta del Balance General...");
            // TODO: Implementar logica para eliminar cuenta
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void CalcularBalanceGeneral()
        {
            throw new NotImplementedException();
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
