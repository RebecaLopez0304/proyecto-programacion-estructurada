using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    public static class AccionAgregarCuenta
    {
        public static void Ejecutar()
        {
            int categoria = MostrarMenuCategorias("Agregar Cuenta - Balance General");

            // Solicitar nombre de la cuenta
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre de la nueva cuenta:");
            string nombreCuenta = SolicitarString("");

            // Solicitar naturaleza de la cuenta
            int naturalezaOpcion = MostrarMenuNaturalezaCuenta();
            bool esDeudora = naturalezaOpcion == 1;

            // Crear la nueva cuenta y marcarla como creada por el usuario
            Cuenta nuevaCuenta = new Cuenta(nombreCuenta, esDeudora)
            {
                EsCreadoPorUsuario = true
            };

            // Agregar a la lista correspondiente
            switch (categoria)
            {
                case 1:
                    CuentasBalanceGeneral.ActivoCirculante.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Activo Circulante", true, false);
                    break;
                case 2:
                    CuentasBalanceGeneral.ActivoFijo.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Activo Fijo", true, false);
                    break;
                case 3:
                    CuentasBalanceGeneral.ActivoIntangible.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Activo Intangible", true, false);
                    break;
                case 4:
                    CuentasBalanceGeneral.OtrosActivos.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Otros Activos", true, false);
                    break;
                case 5:
                    CuentasBalanceGeneral.PasivoLargoPlazo.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Pasivo a Largo Plazo", true, false);
                    break;
                case 6:
                    CuentasBalanceGeneral.PasivoCortoPlazo.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Pasivo a Corto Plazo", true, false);
                    break;
                case 7:
                    CuentasBalanceGeneral.CapitalContribuido.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Capital Contribuido", true, false);
                    break;
                case 8:
                    CuentasBalanceGeneral.CapitalGanado.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Capital Ganado", true, false);
                    break;
            }

            string naturalezaTexto = esDeudora ? "Deudora (+)" : "Acreedora (-)";
            Console.WriteLine($"Cuenta: {nombreCuenta}");
            Console.WriteLine($"Naturaleza: {naturalezaTexto}");

            EsperarTecla();
        }
    }
}
