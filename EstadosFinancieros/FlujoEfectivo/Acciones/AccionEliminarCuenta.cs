using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos;

namespace ProyectoProgramacion
{
    
    //===========================
   //     Acción Eliminar Cuenta - Flujo de Efectivo
    //===========================
    public static class AccionEliminarCuenta
    {
        public static void Ejecutar()
        {
            MostrarTituloSubrayado("Eliminar Cuenta - Flujo de Efectivo", true, true);
            
            // recolectamos todas las cuentas que fueron creadas por el usuario
            var todasCuentasUsuario = new List<(Cuenta cuenta, string actividad, List<Cuenta> listaOriginal)>();

            // Recorremos cada lista y agregamos solo las cuentas marcadas como creadas por el usuario
            foreach (var cuenta in CuentasFlujoEfectivo.ActividadesOperacion)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Actividades de Operación", CuentasFlujoEfectivo.ActividadesOperacion));
            }
            foreach (var cuenta in CuentasFlujoEfectivo.ActividadesInversion)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Actividades de Inversión", CuentasFlujoEfectivo.ActividadesInversion));
            }
            foreach (var cuenta in CuentasFlujoEfectivo.ActividadesFinanciamiento)
            {
                if (cuenta.EsCreadoPorUsuario)
                    todasCuentasUsuario.Add((cuenta, "Actividades de Financiamiento", CuentasFlujoEfectivo.ActividadesFinanciamiento));
            } 
            // Si no hay cuentas de usuario, mostrar mensaje y salir
            if (todasCuentasUsuario.Count == 0)
            {
                MostrarMensajeAdvertencia("No hay cuentas creadas por el usuario para eliminar.", true, false);
                Console.WriteLine("\tUsa la opcion 'Agregar Cuenta' para crear tus propias cuentas.");
                 EsperarTecla();
                return;
            }
           // Mostramos las cuentas agrupadas por categoría para que el usuario elija cuál eliminar
          
            var cuentasPorCategoria = todasCuentasUsuario.GroupBy(x => x.actividad);
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
