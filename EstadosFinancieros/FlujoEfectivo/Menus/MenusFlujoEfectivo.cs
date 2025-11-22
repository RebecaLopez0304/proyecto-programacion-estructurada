using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus
{
    /*
    ===========================
        Menus del Flujo de Efectivo
    ===========================
    IMPORTANTE: Todas las funciones deben ser públicas y estáticas
    */
    public static class MenusFlujoEfectivo
    {
         public static int MostrarMenuPrincipal()
         {
             MostrarLineaDivisoraConTexto("Flujo de Efectivo", true, true);
             Console.WriteLine("1. Ver Cuentas");
             Console.WriteLine("2. Agregar Cuenta");
             Console.WriteLine("3. Eliminar Cuenta");
             Console.WriteLine("4. Calcular Flujo de Efectivo");
             MostrarLineaDivisora(true, true);
             Console.WriteLine("0. Volver");
             return SolicitarEnteroConLimites(0, 4);
         }

        public static int MostrarMenuVerCuentas()
         {
             MostrarTituloSubrayado("Ver Cuentas - Flujo de Efectivo", true, true);
             Console.WriteLine("1. Ver todas las cuentas");
             Console.WriteLine("2. Ver por actividad");
             VolverAtras();

             int opcion = SolicitarEnteroConLimites(0, 2);
             return opcion;
         }
         public static int MenuPorCategoriaFE()
        {
            MostrarTituloSubrayado("Ver Cuentas - flujo de efectivo - Cuentas", true, true);
            Console.WriteLine("1. Gastos de Operación");
            Console.WriteLine("2. Gastos de Inversión");
            Console.WriteLine("3. Gastos de Financiamiento");
            VolverAtras();

            int opcion = SolicitarEnteroConLimites(0, 5);
            return opcion;
        }
        public static int MostrarMenuActividades()
        {
            MostrarTituloSubrayado("Seleccione la actividad del flujo de efectivo:", true, true);
            Console.WriteLine("1. Actividades de Operación");
            Console.WriteLine("2. Actividades de Inversión");
            Console.WriteLine("3. Actividades de Financiamiento");
            VolverAtras();

            int opcion = SolicitarEnteroConLimites(0, 3);
            return opcion;
        }
        public static int MostrarMenuActividadesConSalida()
        {
            MostrarTituloSubrayado("Seleccione la actividad del flujo de efectivo (0 para terminar):", true, true);
            Console.WriteLine("0. Terminar selección");
            Console.WriteLine("1. Actividades de Operación");
            Console.WriteLine("2. Actividades de Inversión");
            Console.WriteLine("3. Actividades de Financiamiento");

            int opcion = SolicitarEnteroConLimites(0, 3);
            return opcion;
        }
        public static int MostrarMenuTipoMovimiento()
        {
            MostrarTituloSubrayado("Seleccione el tipo de movimiento:", true, true);
            Console.WriteLine("1. Entrada de efectivo [+]");
            Console.WriteLine("2. Salida de efectivo [-]");

            int opcion = SolicitarEnteroConLimites(1, 2);
            return opcion;
        }
        public static int MostrarMenuConfirmacion(string mensaje)
        {
            Console.WriteLine($"{mensaje}");
            Console.WriteLine("1. Si, eliminar");
            Console.WriteLine("2. No, cancelar");
            int confirmacion = SolicitarEnteroConLimites(1, 2);
            return confirmacion;
        }
        public static int MostrarMenuContinuar()
        {
            Console.WriteLine();
            Console.WriteLine("¿Desea agregar otra cuenta?");
            Console.WriteLine("1. Si, agregar otra cuenta");
            Console.WriteLine("2. No, calcular Flujo de Efectivo");
            int opcion = SolicitarEnteroConLimites(1, 2);
            return opcion;
        }


    }
}
