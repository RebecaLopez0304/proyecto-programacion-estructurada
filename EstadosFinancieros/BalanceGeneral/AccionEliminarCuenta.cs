// Utilidades y menús comunes del proyecto
using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    public static class AccionEliminarCuenta
    {
        // Permite eliminar una cuenta personalizada creada por el usuario
        public static void Ejecutar()
        {
            MostrarTituloSubrayado("Eliminar Cuenta - Balance General", true, true);

            // Recolectamos todas las cuentas que fueron creadas por el usuario
            var todasCuentasUsuario = new List<(Cuenta cuenta, string categoria, List<Cuenta> listaOriginal)>();

            // Recorremos cada lista y agregamos solo las cuentas marcadas como creadas por el usuario
            foreach (var cuenta in CuentasBalanceGeneral.ActivoCirculante)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Activo Circulante", CuentasBalanceGeneral.ActivoCirculante));
            }

            foreach (var cuenta in CuentasBalanceGeneral.ActivoFijo)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Activo Fijo", CuentasBalanceGeneral.ActivoFijo));
            }

            foreach (var cuenta in CuentasBalanceGeneral.ActivoIntangible)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Activo Intangible", CuentasBalanceGeneral.ActivoIntangible));
            }

            foreach (var cuenta in CuentasBalanceGeneral.OtrosActivos)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Otros Activos", CuentasBalanceGeneral.OtrosActivos));
            }

            // Pasivos
            foreach (var cuenta in CuentasBalanceGeneral.PasivoLargoPlazo)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Pasivo a Largo Plazo", CuentasBalanceGeneral.PasivoLargoPlazo));
            }

            foreach (var cuenta in CuentasBalanceGeneral.PasivoCortoPlazo)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Pasivo a Corto Plazo", CuentasBalanceGeneral.PasivoCortoPlazo));
            }

            // Capital
            foreach (var cuenta in CuentasBalanceGeneral.CapitalContribuido)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Capital Contribuido", CuentasBalanceGeneral.CapitalContribuido));
            }

            foreach (var cuenta in CuentasBalanceGeneral.CapitalGanado)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Capital Ganado", CuentasBalanceGeneral.CapitalGanado));
            }

            // Si no hay cuentas personalizadas, avisamos y salimos
            if (todasCuentasUsuario.Count == 0)
            {
                MostrarMensajeAdvertencia("No has creado ninguna cuenta personalizada aun.", true, false);
                Console.WriteLine("\tUsa la opcion 'Agregar Cuenta' para crear tus propias cuentas.");
                EsperarTecla();
                return;
            }

            // Mostramos las cuentas agrupadas por categoría para que el usuario elija cuál eliminar
            MostrarTituloSubrayado("Cuentas creadas por ti (eliminables)", true, true);

            var cuentasPorCategoria = todasCuentasUsuario.GroupBy(x => x.categoria);
            int numeroGlobal = 1;
            var indiceCuentas = new Dictionary<int, (Cuenta cuenta, List<Cuenta> listaOriginal)>();

            foreach (var grupo in cuentasPorCategoria)
            {
                MostrarTituloSubrayado(grupo.Key, false, true);
                foreach (var item in grupo)
                {
                    string naturaleza = item.cuenta.EsDeudora ? "[Deudora  ]" : "[Acreedora]";
                    Console.WriteLine($"{numeroGlobal}. {naturaleza} {item.cuenta.Nombre}");
                    indiceCuentas[numeroGlobal] = (item.cuenta, item.listaOriginal);
                    numeroGlobal++;
                }
                Console.WriteLine();
            }

            // Pedimos al usuario que seleccione el número de la cuenta a eliminar
            MostrarLineaDivisora(true, true);
            Console.WriteLine($"Seleccione el numero de la cuenta a eliminar (1-{todasCuentasUsuario.Count}):");
            int seleccion = SolicitarEnteroConLimites(1, todasCuentasUsuario.Count);

            var cuentaSeleccionada = indiceCuentas[seleccion];

            // Confirmación antes de eliminar
            int confirmacion = MostrarMenuConfirmacion($"\n¿Esta seguro que desea eliminar la cuenta '{cuentaSeleccionada.cuenta.Nombre}'?");

            if (confirmacion == 1)
            {
                string nombreEliminado = cuentaSeleccionada.cuenta.Nombre;
                cuentaSeleccionada.listaOriginal.Remove(cuentaSeleccionada.cuenta);
                MostrarMensajeExito($"Cuenta '{nombreEliminado}' eliminada exitosamente.", true, false);
            }
            else
            {
                MostrarMensajeCancelacion("Operacion cancelada.", true, false);
            }

            // Pausa final
            EsperarTecla();
        }
    }
}
