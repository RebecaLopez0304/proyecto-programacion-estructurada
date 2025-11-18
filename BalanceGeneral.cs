using System;

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
        Console.WriteLine("\n--- Menu Balance General ---");
        Console.WriteLine("Seleccione una opcion (0-4):");

        Utilidades.MostrarLineaDivisora();

        Console.WriteLine("1. Ver Cuentas");
        Console.WriteLine("2. Agregar Cuenta");
        Console.WriteLine("3. Eliminar Cuenta");

        Utilidades.MostrarLineaDivisora();

        Console.WriteLine("4. Realizar calculo de Balance General");

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
            Console.WriteLine("\n=== Ver Cuentas - Balance General ===");
            Console.WriteLine("1. Ver todas las cuentas");
            Console.WriteLine("2. Ver cuentas generales (Activos, Pasivos, Capital)");
            Console.WriteLine("3. Ver cuentas subclasificadas");
            Console.WriteLine("0. Volver al menú anterior");

            int opcion = Utilidades.SolicitarEnteroConLimites(0, 3);

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

    private static void MostrarTodasCuentasBalanceGeneral()
    {
        Console.WriteLine("\n--- Todas las Cuentas del Balance General ---\n");

        Console.WriteLine("========= ACTIVOS ==========");
        MostrarSeccion("Activo circulante", CuentasBalanceGeneral.ActivoCirculante);
        MostrarSeccion("Activo fijo", CuentasBalanceGeneral.ActivoFijo);
        MostrarSeccion("Activo intangible", CuentasBalanceGeneral.ActivoIntangible);
        MostrarSeccion("Otros activos", CuentasBalanceGeneral.OtrosActivos);

        Console.WriteLine("\n========= PASIVOS ==========");
        MostrarSeccion("Pasivo a largo plazo", CuentasBalanceGeneral.PasivoLargoPlazo);
        MostrarSeccion("Pasivo a corto plazo", CuentasBalanceGeneral.PasivoCortoPlazo);
        Console.WriteLine("\n========= CAPITAL ==========");
        MostrarSeccion("Capital ganado", CuentasBalanceGeneral.CapitalGanado);
        MostrarSeccion("Capital contribuido", CuentasBalanceGeneral.CapitalContribuido);

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    private static void MostrarCuentasGeneralesBalanceGeneral()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- Cuentas Generales del Balance General ---\n");

            Console.WriteLine("1. Activos");
            Console.WriteLine("2. Pasivos");
            Console.WriteLine("3. Capital");
            Console.WriteLine("0. Volver");

            int opcion = Utilidades.SolicitarEnteroConLimites(0, 3);

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("\n--- ACTIVOS ---");
                    MostrarSeccion("Activo circulante", CuentasBalanceGeneral.ActivoCirculante);
                    MostrarSeccion("Activo fijo", CuentasBalanceGeneral.ActivoFijo);
                    MostrarSeccion("Activo intangible", CuentasBalanceGeneral.ActivoIntangible);
                    MostrarSeccion("Otros activos", CuentasBalanceGeneral.OtrosActivos);
                    Console.ReadKey();
                    break;

                case 2:
                    Console.WriteLine("\n--- PASIVOS ---");
                    MostrarSeccion("Pasivo a largo plazo", CuentasBalanceGeneral.PasivoLargoPlazo);
                    MostrarSeccion("Pasivo a corto plazo", CuentasBalanceGeneral.PasivoCortoPlazo);
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("\n--- CAPITAL ---");
                    MostrarSeccion("Capital ganado", CuentasBalanceGeneral.CapitalGanado);
                    MostrarSeccion("Capital contribuido", CuentasBalanceGeneral.CapitalContribuido);
                    Console.ReadKey();
                    break;

                case 0:
                    salir = true;
                    break;
            }
        }
    }

    private static void MostrarCuentasSubclasificadasBalanceGeneral()
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("\n--- Cuentas Subclasificadas ---\n");

            Console.WriteLine("ACTIVOS");
            Console.WriteLine("  1. Activo circulante");
            Console.WriteLine("  2. Activo fijo");
            Console.WriteLine("  3. Activo intangible");
            Console.WriteLine("  4. Otros activos\n");

            Console.WriteLine("PASIVOS");
            Console.WriteLine("  5. Pasivo a largo plazo");
            Console.WriteLine("  6. Pasivo a corto plazo\n");

            Console.WriteLine("CAPITAL");
            Console.WriteLine("  7. Capital ganado");
            Console.WriteLine("  8. Capital contribuido\n");

            Console.WriteLine("  0. Volver\n");

            Console.Write("Seleccione la subclasificación que desea ver (0-8): ");
            int opcion = Utilidades.SolicitarEnteroConLimites(0, 8);

            switch (opcion)
            {
                case 1:
                    MostrarSeccion("Activo circulante", CuentasBalanceGeneral.ActivoCirculante);
                    Console.ReadKey();
                    break;
                case 2:
                    MostrarSeccion("Activo fijo", CuentasBalanceGeneral.ActivoFijo);
                    Console.ReadKey();
                    break;
                case 3:
                    MostrarSeccion("Activo intangible", CuentasBalanceGeneral.ActivoIntangible);
                    Console.ReadKey();
                    break;
                case 4:
                    MostrarSeccion("Otros activos", CuentasBalanceGeneral.OtrosActivos);
                    Console.ReadKey();
                    break;
                case 5:
                    MostrarSeccion("Pasivo a largo plazo", CuentasBalanceGeneral.PasivoLargoPlazo);
                    Console.ReadKey();
                    break;
                case 6:
                    MostrarSeccion("Pasivo a corto plazo", CuentasBalanceGeneral.PasivoCortoPlazo);
                    Console.ReadKey();
                    break;
                case 7:
                    MostrarSeccion("Capital ganado", CuentasBalanceGeneral.CapitalGanado);
                    Console.ReadKey();
                    break;
                case 8:
                    MostrarSeccion("Capital contribuido", CuentasBalanceGeneral.CapitalContribuido);
                    Console.ReadKey();
                    break;
                case 0:
                    volver = true;
                    break;
                default:
                    // no debería ocurrir por validación previa
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
            // Console.WriteLine($"\t{cuenta.Nombre}  ->  {cuenta.Valor}");
            Console.WriteLine($"\t{cuenta.Nombre}");
        }
    }
}


