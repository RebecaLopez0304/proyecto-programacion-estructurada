using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones
{
    /*
    ===========================
        Acción Agregar Cuenta - Estado de Resultados
    ===========================
    */
    public static class AccionAgregarCuenta
    {
        // MARK: Accion agregar cuenta
        public static void Ejecutar()
        {

            int categoria = MostrarMenuCategorias("Agregar Cuenta - Estado de Resultados");
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre de la nueva cuenta:");
            string nombreCuenta = SolicitarString();

            int naturalezaOpcion = MostrarMenuNaturalezaCuenta();
            bool esDeudora = naturalezaOpcion == 1;

            // Crear la nueva cuenta y marcarla como creada por el usuario
            Cuenta nuevaCuenta = new Cuenta(nombreCuenta, esDeudora)
            {
                EsCreadoPorUsuario = true
            };

            // MARK: Agregar a la lista correspondiente
            switch (categoria)
            {
                case 1:
                    CuentasEstadoResultados.Ventas.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Ingresos", true, false);
                    break;
                case 2:
                    CuentasEstadoResultados.CostoDeVentas.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Costo de Ventas", true, false);
                    break;
                case 3:
                    CuentasEstadoResultados.GastoDeOperacion.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Gastos de Venta", true, true);
                    break;
                case 4:
                    CuentasEstadoResultados.GastosAdministracion.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Gastos de Administración", true, false);
                    break;
                case 5:
                    CuentasEstadoResultados.OtrosResultadosFinancieros.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Otros Resultados Financieros", true, false);
                    break;


            }
            string naturalezaTexto = esDeudora ? "Egreso (-)" : "Ingreso (+)";
            Console.WriteLine($"Cuenta: {nombreCuenta}");
            Console.WriteLine($"Naturaleza: {naturalezaTexto}");
        }
    }
}
