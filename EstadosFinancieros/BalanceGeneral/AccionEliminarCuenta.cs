using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    public static class AccionEliminarCuenta
    {
        public static void Ejecutar()
        {
            MostrarTituloSubrayado("Eliminar Cuenta - Balance General", true, true);

            // Recopilar todas las cuentas creadas por el usuario de todas las categorías
            var todasCuentasUsuario = new List<(Cuenta cuenta, string categoria, List<Cuenta> listaOriginal)>();

            // Activos
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


            // Verificar si hay cuentas creadas por el usuario
            if (todasCuentasUsuario.Count == 0)
            {
                MostrarMensajeAdvertencia("No has creado ninguna cuenta personalizada aun.", true, false);
                Console.WriteLine("\tUsa la opcion 'Agregar Cuenta' para crear tus propias cuentas.");
                EsperarTecla();
                return;
            }

            // Mostrar todas las cuentas creadas por el usuario, agrupadas por categoría
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

            MostrarLineaDivisora(true, true);
            Console.WriteLine($"Seleccione el numero de la cuenta a eliminar (1-{todasCuentasUsuario.Count}):");
            int seleccion = SolicitarEnteroConLimites(1, todasCuentasUsuario.Count);

            var cuentaSeleccionada = indiceCuentas[seleccion];

            // Confirmación
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

            EsperarTecla();
        }
    }
}
