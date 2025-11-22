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
        // MARK: - Método Principal

        public static void Ejecutar()
        {
            // MARK: Solicitud de Datos de la Cuenta

            // Pedimos al usuario a qué actividad pertenece la nueva cuenta
            int actividad = MostrarMenuActividades();

            // Pedimos el nombre de la cuenta
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre de la nueva cuenta:");
            string nombreCuenta = SolicitarString();

            // Pedimos el tipo de movimiento
            int tipoMovimientoOpcion = MostrarMenuTipoMovimiento();
            bool esDeudora = tipoMovimientoOpcion == 1; // Entrada [+] -> EsDeudora = true

            // Pedimos el grupo del Balance General
            Console.WriteLine();
            Console.WriteLine("¿A qué grupo del Balance General pertenece esta cuenta?");
            Console.WriteLine("1. Activo");
            Console.WriteLine("2. Pasivo");
            Console.WriteLine("3. Capital Contable");
            int grupoOpcion = SolicitarEnteroConLimites(1, 3);

            string tipoGrupoBalance = grupoOpcion switch
            {
                1 => "Activo",
                2 => "Pasivo",
                3 => "Capital",
                _ => ""
            };

            // MARK: Creación y Almacenamiento de Cuenta

            // Crear la nueva cuenta y marcarla como creada por el usuario
            Cuenta nuevaCuenta = new Cuenta(nombreCuenta, esDeudora, tipoGrupoBalance)
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
            Console.WriteLine($"Grupo Balance General: {tipoGrupoBalance}");

            // Pausa para que el usuario lea el mensaje
            EsperarTecla();
        }
    }
}
