using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones
{
    /*
    ===========================
        Acción Eliminar Cuenta - Estado de Resultados
    ===========================
    */
    public static class AccionEliminarCuenta
    {
        public static void Ejecutar()
        {
            MostrarTituloSubrayado("Eliminar Cuenta - Estado de Resultados", true, true);

            // Recolectamos todas las cuentas que fueron creadas por el usuario
            var todasCuentasUsuario = new List<(Cuenta cuenta, string categoria, List<Cuenta> listaOriginal)>();

            // Ingresos / Ventas
            foreach (var cuenta in CuentasEstadoResultados.Ventas)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Ventas", CuentasEstadoResultados.Ventas));
            }

            // Costo de ventas
            foreach (var cuenta in CuentasEstadoResultados.CostoDeVentas)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Costo de Ventas", CuentasEstadoResultados.CostoDeVentas));
            }

            // Gastos de operación (venta)
            foreach (var cuenta in CuentasEstadoResultados.GastoDeOperacion)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Gastos de Operación", CuentasEstadoResultados.GastoDeOperacion));
            }

            // Gastos de administración
            foreach (var cuenta in CuentasEstadoResultados.GastosAdministracion)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Gastos de Administración", CuentasEstadoResultados.GastosAdministracion));
            }

            // Otros resultados financieros / gastos financieros
            foreach (var cuenta in CuentasEstadoResultados.OtrosResultadosFinancieros)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Otros Resultados Financieros", CuentasEstadoResultados.OtrosResultadosFinancieros));
            }
            // Si no hay cuentas personalizadas, avisamos y salimos
            if (todasCuentasUsuario.Count == 0)
            {
                MostrarMensajeAdvertencia("No hay cuentas personalizadas para eliminar.", true, true);
                EsperarTecla();
                return;
            }

            // mostrar las cuentas agrupadas por categoría para que el usuario elija cuál eliminar
            MostrarTituloSubrayado("Cuentas creadas por ti (eliminables)", true, true);

            var cuentasPorCategoria = todasCuentasUsuario.GroupBy(x => x.categoria);
            int numeroGlobal = 1;
            var indiceCuentas = new Dictionary<int, (Cuenta cuenta, List<Cuenta> listaOriginal)>();


            foreach (var grupo in cuentasPorCategoria)
            {
                MostrarTituloSubrayado(grupo.Key, false, true);
                foreach (var item in grupo)
                {
                    string naturaleza = item.cuenta.EsDeudora ? "[Egreso  ]" : "[Ingreso ]";
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


            MostrarMensajeAdvertencia("Esta funcionalidad aun no esta implementada.", true, true);
            EsperarTecla();
        }
    }
}
