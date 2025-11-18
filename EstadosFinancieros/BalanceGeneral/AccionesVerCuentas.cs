using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.CuentasBalanceGeneral;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.BalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    public static class AccionesVerCuentas
    {
        public static void MostrarTodasCuentasBalanceGeneral()
        {
            Console.WriteLine("\n--- Todas las Cuentas del Balance General ---\n");

            MostrarLineaDivisoraConTexto("ACTIVOS", true);
            MostrarSeccion("Activo circulante", ActivoCirculante);
            MostrarSeccion("Activo fijo", ActivoFijo);
            MostrarSeccion("Activo intangible", ActivoIntangible);
            MostrarSeccion("Otros activos", OtrosActivos);

            MostrarLineaDivisoraConTexto("PASIVOS", true);
            MostrarSeccion("Pasivo a largo plazo", PasivoLargoPlazo);
            MostrarSeccion("Pasivo a corto plazo", PasivoCortoPlazo);

            MostrarLineaDivisoraConTexto("CAPITAL", true);
            MostrarSeccion("Capital ganado", CapitalGanado);
            MostrarSeccion("Capital contribuido", CapitalContribuido);

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        public static void MostrarCuentasGeneralesBalanceGeneral()
        {
            bool salir = false;

            while (!salir)
            {
                MostrarTituloSubrayado("Cuentas Generales del Balance General", true, true);

                Console.WriteLine("1. Activos");
                Console.WriteLine("2. Pasivos");
                Console.WriteLine("3. Capital");
                MostrarLineaDivisora(true, true);
                VolverAtras();

                int opcion = SolicitarEnteroConLimites(0, 3);

                switch (opcion)
                {
                    case 1:
                        MostrarTituloSubrayado("ACTIVOS", true, true);
                        MostrarSeccion("Activo circulante", ActivoCirculante);
                        MostrarSeccion("Activo fijo", ActivoFijo);
                        MostrarSeccion("Activo intangible", ActivoIntangible);
                        MostrarSeccion("Otros activos", OtrosActivos);
                        EsperarTecla();
                        break;

                    case 2:
                        MostrarTituloSubrayado("PASIVOS", true, true);
                        MostrarSeccion("Pasivo a largo plazo", PasivoLargoPlazo);
                        MostrarSeccion("Pasivo a corto plazo", PasivoCortoPlazo);
                        MostrarLineaDivisora(true, true);
                        EsperarTecla();
                        break;

                    case 3:
                        MostrarTituloSubrayado("CAPITAL", true, true);
                        MostrarSeccion("Capital ganado", CapitalGanado);
                        MostrarSeccion("Capital contribuido", CapitalContribuido);
                        MostrarLineaDivisora(true, true);
                        EsperarTecla();
                        break;

                    case 0:
                        salir = true;
                        break;
                }
            }
        }

        public static void MostrarCuentasSubclasificadasBalanceGeneral()
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
                VolverAtras();

                Console.Write("Seleccione la subclasificación que desea ver (0-8): ");
                int opcion = SolicitarEnteroConLimites(0, 8);

                switch (opcion)
                {
                    case 1:
                        MostrarSeccion("Activo circulante", ActivoCirculante);
                        Console.ReadKey();
                        break;
                    case 2:
                        MostrarSeccion("Activo fijo", ActivoFijo);
                        Console.ReadKey();
                        break;
                    case 3:
                        MostrarSeccion("Activo intangible", ActivoIntangible);
                        Console.ReadKey();
                        break;
                    case 4:
                        MostrarSeccion("Otros activos", OtrosActivos);
                        Console.ReadKey();
                        break;
                    case 5:
                        MostrarSeccion("Pasivo a largo plazo", PasivoLargoPlazo);
                        Console.ReadKey();
                        break;
                    case 6:
                        MostrarSeccion("Pasivo a corto plazo", PasivoCortoPlazo);
                        Console.ReadKey();
                        break;
                    case 7:
                        MostrarSeccion("Capital ganado", CapitalGanado);
                        Console.ReadKey();
                        break;
                    case 8:
                        MostrarSeccion("Capital contribuido", CapitalContribuido);
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

    }
}