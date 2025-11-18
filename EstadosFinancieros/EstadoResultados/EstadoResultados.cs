using System;
using ProyectoProgramacion.Comunes;

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
                        CalcularEstadoResultados();
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
            Console.WriteLine("\n--- Menu Estado de Resultados ---");
            Console.WriteLine("Seleccione una opcion (0-4):");

            Utilidades.MostrarLineaDivisora();

            Console.WriteLine("1. Ver Cuentas");
            Console.WriteLine("2. Agregar Cuenta");
            Console.WriteLine("3. Eliminar Cuenta");

            Utilidades.MostrarLineaDivisora();

            Console.WriteLine("4. Realizar calculo de Estado de Resultados");

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
                Console.WriteLine("\n=== Ver Cuentas - Estado de Resultados ===");
                Console.WriteLine("1. Ver todas las cuentas");
                Console.WriteLine("2. Ver cuentas por categoría");
                Console.WriteLine("0. Volver al menú anterior");

                int opcion = Utilidades.SolicitarEnteroConLimites(0, 2);

                switch (opcion)
                {
                    case 1:
                        MostrarTodasCuentasEstadoResultados();
                        break;
                    case 2:
                        MostrarCuentasPorCategoria();
                        break;
                    case 0:
                        regresar = true;
                        break;
                }
            }
        }

        private static void AgregarCuenta()
        {
            Console.WriteLine("\n=== Agregar Cuenta - Estado de Resultados ===");
            Console.WriteLine("Aqui se agregara una nueva cuenta al Estado de Resultados...");
            // TODO: Implementar logica para agregar cuenta
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void EliminarCuenta()
        {
            Console.WriteLine("\n=== Eliminar Cuenta - Estado de Resultados ===");
            Console.WriteLine("Aqui se eliminara una cuenta del Estado de Resultados...");
            // TODO: Implementar logica para eliminar cuenta
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void CalcularEstadoResultados()
        {
            Console.WriteLine("\n=== Calcular Estado de Resultados ===");
            Console.WriteLine("Aqui se realizara el calculo del Estado de Resultados...");
            // TODO: Implementar logica para calcular
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarTodasCuentasEstadoResultados()
        {
            Console.WriteLine("\n--- Todas las Cuentas del Estado de Resultados ---\n");

            Console.WriteLine("========= INGRESOS ==========");
            MostrarSeccion("Ingresos", CuentasEstadoResultados.Ingresos);

            Console.WriteLine("\n========= COSTO DE VENTAS ==========");
            MostrarSeccion("Costo de Ventas", CuentasEstadoResultados.CostoVentas);

            Console.WriteLine("\n========= GASTOS DE OPERACIÓN ==========");
            MostrarSeccion("Gastos de Venta", CuentasEstadoResultados.GastosVenta);
            MostrarSeccion("Gastos de Administración", CuentasEstadoResultados.GastosAdministracion);

            Console.WriteLine("\n========= GASTOS Y PRODUCTOS FINANCIEROS ==========");
            MostrarSeccion("Gastos Financieros", CuentasEstadoResultados.GastosFinancieros);
            MostrarSeccion("Productos Financieros", CuentasEstadoResultados.ProductosFinancieros);

            Console.WriteLine("\n========= OTROS GASTOS Y PRODUCTOS ==========");
            MostrarSeccion("Otros Gastos", CuentasEstadoResultados.OtrosGastos);
            MostrarSeccion("Otros Productos", CuentasEstadoResultados.OtrosProductos);

            Console.WriteLine("\n========= IMPUESTOS ==========");
            MostrarSeccion("Impuestos", CuentasEstadoResultados.Impuestos);

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarCuentasPorCategoria()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("\n--- Categorías del Estado de Resultados ---\n");

                Console.WriteLine("1. Ingresos");
                Console.WriteLine("2. Costo de Ventas");
                Console.WriteLine("3. Gastos de Venta");
                Console.WriteLine("4. Gastos de Administración");
                Console.WriteLine("5. Gastos Financieros");
                Console.WriteLine("6. Productos Financieros");
                Console.WriteLine("7. Otros Gastos");
                Console.WriteLine("8. Otros Productos");
                Console.WriteLine("9. Impuestos");
                Console.WriteLine("0. Volver\n");

                int opcion = Utilidades.SolicitarEnteroConLimites(0, 9);

                switch (opcion)
                {
                    case 1:
                        MostrarSeccion("Ingresos", CuentasEstadoResultados.Ingresos);
                        Console.ReadKey();
                        break;
                    case 2:
                        MostrarSeccion("Costo de Ventas", CuentasEstadoResultados.CostoVentas);
                        Console.ReadKey();
                        break;
                    case 3:
                        MostrarSeccion("Gastos de Venta", CuentasEstadoResultados.GastosVenta);
                        Console.ReadKey();
                        break;
                    case 4:
                        MostrarSeccion("Gastos de Administración", CuentasEstadoResultados.GastosAdministracion);
                        Console.ReadKey();
                        break;
                    case 5:
                        MostrarSeccion("Gastos Financieros", CuentasEstadoResultados.GastosFinancieros);
                        Console.ReadKey();
                        break;
                    case 6:
                        MostrarSeccion("Productos Financieros", CuentasEstadoResultados.ProductosFinancieros);
                        Console.ReadKey();
                        break;
                    case 7:
                        MostrarSeccion("Otros Gastos", CuentasEstadoResultados.OtrosGastos);
                        Console.ReadKey();
                        break;
                    case 8:
                        MostrarSeccion("Otros Productos", CuentasEstadoResultados.OtrosProductos);
                        Console.ReadKey();
                        break;
                    case 9:
                        MostrarSeccion("Impuestos", CuentasEstadoResultados.Impuestos);
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
