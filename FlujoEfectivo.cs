using System;

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
        Console.WriteLine("Seleccione una opcion (0-3):");
        Console.WriteLine("1. Ver Cuentas");
        Console.WriteLine("2. Agregar Cuenta");
        Console.WriteLine("3. Eliminar Cuenta");
        Console.WriteLine();
        Console.WriteLine("0. Volver al Menu Principal");

        int opcion = Utilidades.SolicitarEnteroConLimites(0, 3);
        return opcion;
    }

    private static void VerCuentas()
    {
        Console.WriteLine("\n=== Ver Cuentas - Flujo de Efectivo ===");
        Console.WriteLine("Aqui se mostraran las cuentas del Flujo de Efectivo...");
        // TODO: Implementar logica para ver cuentas
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
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
}
