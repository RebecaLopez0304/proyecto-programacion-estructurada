using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones
{
    /*
    ===========================
        Acción Agregar Cuenta - Flujo de Efectivo
    ===========================
    */
    public static class AccionAgregarCuenta
    {
        public static void Ejecutar()
        {
            // Pedimos al usuario a qué actividad pertenece la nueva cuenta
            int actividad = MostrarMenuActividades();

            // Pedimos el nombre de la cuenta
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre de la nueva cuenta:");
            string nombreCuenta = SolicitarString("");

            // Pedimos el tipo de movimiento
            int tipoMovimientoOpcion = MostrarMenuTipoMovimiento();
            bool esDeudora = tipoMovimientoOpcion == 1; // Entrada [+] -> EsDeudora = true

            // Crear la nueva cuenta y marcarla como creada por el usuario
            Cuenta nuevaCuenta = new Cuenta(nombreCuenta, esDeudora)
            {
                EsCreadoPorUsuario = true
            };

            // Según la actividad elegida, agregamos la cuenta a la lista correspondiente
            switch (actividad)
            {
                case 1:
                    CuentasFlujoEfectivo.ActividadesOperacion.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Actividades de Operación", true, false);
                    break;
                case 2:
                    CuentasFlujoEfectivo.ActividadesInversion.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Actividades de Inversión", true, false);
                    break;
                case 3:
                    CuentasFlujoEfectivo.ActividadesFinanciamiento.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Actividades de Financiamiento", true, false);
                    break;
            }

            // Mostramos un resumen sencillo de la cuenta creada
            string naturalezaTexto = esDeudora ? "Entrada [+]" : "Salida [-]";
            Console.WriteLine($"Cuenta: {nombreCuenta}");
            Console.WriteLine($"Tipo de Movimiento: {naturalezaTexto}");

            // Pausa para que el usuario lea el mensaje
            EsperarTecla();
        }
    }
}
