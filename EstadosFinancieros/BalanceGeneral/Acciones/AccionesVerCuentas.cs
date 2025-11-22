using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Catalogos.CuentasBalanceGeneral;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.BalanceGeneral;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones
{
    public static class AccionesVerCuentas
    {
        // MARK: Mostrar todas las cuentas
        public static void MostrarTodasCuentasBalanceGeneral()
        {
            // Título general
            Console.WriteLine("\n--- Todas las Cuentas del Balance General ---\n");

            // ACTIVOS: mostramos cada sublista con su título
            MostrarLineaDivisoraConTexto("ACTIVOS", true);
            MostrarSeccion("Activo circulante", ActivoCirculante);
            MostrarSeccion("Activo fijo", ActivoFijo);
            MostrarSeccion("Activo intangible", ActivoIntangible);
            MostrarSeccion("Otros activos", OtrosActivos);

            // PASIVOS
            MostrarLineaDivisoraConTexto("PASIVOS", true);
            MostrarSeccion("Pasivo a largo plazo", PasivoLargoPlazo);
            MostrarSeccion("Pasivo a corto plazo", PasivoCortoPlazo);

            // CAPITAL
            MostrarLineaDivisoraConTexto("CAPITAL", true);
            MostrarSeccion("Capital ganado", CapitalGanado);
            MostrarSeccion("Capital contribuido", CapitalContribuido);

            // Pausa para que el usuario pueda leer todo
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        // MARK: Mostrar cuentas Activos - Pasivos - Capital
        public static void MostrarCuentasGeneralesBalanceGeneral()
        {
            bool salir = false;

            while (!salir)
            {
                int opcion = MostrarMenuCuentasGenerales();

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
                        // Mostrar las cuentas de capital (aportaciones y utilidades)
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

    
        // MARK: Mostrar cuentas subclasificadas
        public static void MostrarCuentasSubclasificadasBalanceGeneral()
        {
            bool volver = false;

            while (!volver)
            {
                int opcion = MostrarMenuCuentasSubclasificadas();

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
                        // Mostrar activos intangibles
                        MostrarSeccion("Activo intangible", ActivoIntangible);
                        Console.ReadKey();
                        break;
                    case 4:
                        // Mostrar otros activos
                        MostrarSeccion("Otros activos", OtrosActivos);
                        Console.ReadKey();
                        break;
                    case 5:
                        // Pasivos a largo plazo
                        MostrarSeccion("Pasivo a largo plazo", PasivoLargoPlazo);
                        Console.ReadKey();
                        break;
                    case 6:
                        // Pasivos a corto plazo
                        MostrarSeccion("Pasivo a corto plazo", PasivoCortoPlazo);
                        Console.ReadKey();
                        break;
                    case 7:
                        // Capital ganado
                        MostrarSeccion("Capital ganado", CapitalGanado);
                        Console.ReadKey();
                        break;
                    case 8:
                        // Capital contribuido
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