using System;
using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo
{
    /*
    ===========================
        Clase Flujo de Efectivo
    ===========================
    */
    public static class FlujoEfectivo
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
                        CalcularFlujoEfectivo();
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
            Console.WriteLine("\n--- Menu Flujo de Efectivo ---");
            Console.WriteLine("Seleccione una opcion (0-4):");

            Utilidades.MostrarLineaDivisora();

            Console.WriteLine("1. Ver Cuentas");
            Console.WriteLine("2. Agregar Cuenta");
            Console.WriteLine("3. Eliminar Cuenta");

            Utilidades.MostrarLineaDivisora();

            Console.WriteLine("4. Realizar calculo de Flujo de Efectivo");

            Utilidades.MostrarLineaDivisora();

            Console.WriteLine("0. Volver al Menu Principal");

            int opcion = Utilidades.SolicitarEnteroConLimites(0, 4);
            return opcion;
        }

        private static void VerCuentas()
        {
            bool regresar = false;

            while (!regresar)
            {
                Console.WriteLine("\n=== Ver Cuentas - Flujo de Efectivo ===");
                Console.WriteLine("1. Ver todas las cuentas");
                Console.WriteLine("2. Ver cuentas por actividad");
                Console.WriteLine("0. Volver al menú anterior");

                int opcion = Utilidades.SolicitarEnteroConLimites(0, 2);

                switch (opcion)
                {
                    case 1:
                        MostrarTodasCuentasFlujoEfectivo();
                        break;
                    case 2:
                        MostrarCuentasPorActividad();
                        break;
                    case 0:
                        regresar = true;
                        break;
                }
            }
        }

        private static void AgregarCuenta()
        {
            Console.WriteLine("\n=== Agregar Cuenta - Flujo de Efectivo ===");
            Console.WriteLine("Aqui se agregara una nueva cuenta al Flujo de Efectivo...");
            // TODO: Implementar logica para agregar cuenta
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void EliminarCuenta()
        {
            Console.WriteLine("\n=== Eliminar Cuenta - Flujo de Efectivo ===");
            Console.WriteLine("Aqui se eliminara una cuenta del Flujo de Efectivo...");
            // TODO: Implementar logica para eliminar cuenta
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void CalcularFlujoEfectivo()
        {
            Console.WriteLine("\n=== Calcular Flujo de Efectivo ===");
            Console.WriteLine("Aqui se realizara el calculo del Flujo de Efectivo...");
            // TODO: Implementar logica para calcular
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarTodasCuentasFlujoEfectivo()
        {
            Console.WriteLine("\n--- Todas las Cuentas del Flujo de Efectivo ---\n");

            Console.WriteLine("========= ACTIVIDADES DE OPERACIÓN ==========");
            MostrarSeccion("Actividades de Operación", CuentasFlujoEfectivo.ActividadesOperacion);

            Console.WriteLine("\n========= ACTIVIDADES DE INVERSIÓN ==========");
            MostrarSeccion("Actividades de Inversión", CuentasFlujoEfectivo.ActividadesInversion);

            Console.WriteLine("\n========= ACTIVIDADES DE FINANCIAMIENTO ==========");
            MostrarSeccion("Actividades de Financiamiento", CuentasFlujoEfectivo.ActividadesFinanciamiento);

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarCuentasPorActividad()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("\n--- Actividades del Flujo de Efectivo ---\n");

                Console.WriteLine("1. Actividades de Operación");
                Console.WriteLine("2. Actividades de Inversión");
                Console.WriteLine("3. Actividades de Financiamiento");
                Console.WriteLine("0. Volver\n");

                int opcion = Utilidades.SolicitarEnteroConLimites(0, 3);

                switch (opcion)
                {
                    case 1:
                        MostrarSeccion("Actividades de Operación", CuentasFlujoEfectivo.ActividadesOperacion);
                        Console.ReadKey();
                        break;
                    case 2:
                        MostrarSeccion("Actividades de Inversión", CuentasFlujoEfectivo.ActividadesInversion);
                        Console.ReadKey();
                        break;
                    case 3:
                        MostrarSeccion("Actividades de Financiamiento", CuentasFlujoEfectivo.ActividadesFinanciamiento);
                        Console.ReadKey();
                        break;
                    case 0:
                        volver = true;
                        break;
                }
            }
        }

        private static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas)
        {
            Console.WriteLine($"\n{titulo}");
            Console.WriteLine(new string('-', titulo.Length));

            foreach (var cuenta in listaDeCuentas)
            {
                Console.WriteLine($"\t{cuenta.Nombre}");
            }
        }
    }
}
