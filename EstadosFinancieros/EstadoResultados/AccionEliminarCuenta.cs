using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.MenusEstadoResultados;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    /*
    ===========================
        Acción Eliminar Cuenta - Estado de Resultados
    ===========================
    
    TODO: Implementar la lógica para eliminar cuentas creadas por el usuario
    Seguir el patrón de AccionEliminarCuenta.cs del Balance General
    
    Flujo requerido:
    1. Recopilar todas las cuentas con EsCreadoPorUsuario == true de las 9 categorías
    2. Guardar en lista de tuplas: (cuenta, categoría, listaOriginal)
    3. Si no hay cuentas de usuario, mostrar MostrarMensajeAdvertencia() y salir
    4. Agrupar cuentas por categoría usando LINQ GroupBy
    5. Mostrar todas las cuentas numeradas globalmente
    6. Solicitar selección de cuenta a eliminar
    7. Mostrar confirmación con MostrarMenuConfirmacion()
    8. Si confirma: eliminar de la lista original y mostrar MostrarMensajeExito()
    9. Si cancela: mostrar MostrarMensajeCancelacion()
    
    Categorías a revisar (9):
    1. CuentasEstadoResultados.Ingresos
    2. CuentasEstadoResultados.CostoVentas
    3. CuentasEstadoResultados.GastosVenta
    4. CuentasEstadoResultados.GastosAdministracion
    5. CuentasEstadoResultados.GastosFinancieros
    6. CuentasEstadoResultados.ProductosFinancieros
    7. CuentasEstadoResultados.OtrosGastos
    8. CuentasEstadoResultados.OtrosProductos
    9. CuentasEstadoResultados.Impuestos
    
    IMPORTANTE:
    - SOLO eliminar cuentas con EsCreadoPorUsuario == true
    - Usar LINQ para agrupar y filtrar
    - Usar Dictionary<int, (Cuenta, List<Cuenta>)> para mapear números a cuentas
    */
    public static class AccionEliminarCuenta
    {
        public static void Ejecutar()
        {
            // TODO: Implementar toda la lógica de eliminar cuenta
            // Seguir el patrón exacto de Balance General

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


            MostrarMensajeAdvertencia("Esta funcionalidad aun no esta implementada.", true, true);
            EsperarTecla();
        }
    }
}
