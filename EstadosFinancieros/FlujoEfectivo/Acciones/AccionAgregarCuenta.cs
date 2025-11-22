using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos; // Agrega esta línea para acceder a CuentasFlujoEfectivo

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones
{
    
   // ===========================
     //   Acción Agregar Cuenta - Flujo de Efectivo
    //===========================
    public static class AccionAgregarCuenta
    {
        public static void Ejecutar()
        {
            int actividad = MostrarMenuActividades();
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre de la nueva cuenta:");
            string nombreCuenta = SolicitarString("");

            int tipoMovimientoOpcion = MostrarMenuTipoMovimiento();
            bool esDeudora = tipoMovimientoOpcion == 1; // Entrada [+] -> EsDeudora = true

            // Crear la nueva cuenta y marcarla como creada por el usuario
            Cuenta nuevaCuenta = new Cuenta(nombreCuenta, esDeudora)
            {
                EsCreadoPorUsuario = true
            };
            
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

            string naturalezaTexto = esDeudora ? "Entrada [+]" : "Salida [-]";
            Console.WriteLine($"Cuenta: {nombreCuenta}");
            Console.WriteLine($"Tipo de Movimiento: {naturalezaTexto}");
        }

        
    }
}
