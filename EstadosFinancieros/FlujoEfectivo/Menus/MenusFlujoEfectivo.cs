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
        // MARK: Menú Principal
        public static int MostrarMenuPrincipal()
        {
            MostrarLineaDivisoraConTexto("Menu Flujo de Efectivo", true, true);
            MostrarTituloSubrayado("Seleccione una opcion:", false, true);
            Console.WriteLine("1. Ver Cuentas");
            Console.WriteLine("2. Agregar Cuenta");
            Console.WriteLine("3. Eliminar Cuenta");
            MostrarLineaDivisora(false, true);
            Console.WriteLine("4. Realizar calculo de Flujo de Efectivo");
            MostrarLineaDivisora(false, true);
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 4);
            return opcion;
        }

        // MARK: Menú Ver Cuentas
        public static int MostrarMenuVerCuentas()
        {
            MostrarTituloSubrayado("Ver Cuentas - Flujo de Efectivo", true, true);
            Console.WriteLine("1. Ver todas las cuentas");
            Console.WriteLine("2. Ver por actividad");
            MostrarLineaDivisora(false, true);
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 2);
            return opcion;
        }
        // MARK: Menú Por Actividad
        public static int MenuPorCategoriaFE()
        {
            MostrarTituloSubrayado("Ver Cuentas - Flujo de Efectivo - Por Actividad", true, true);
            Console.WriteLine("1. Actividades de Operación");
            Console.WriteLine("2. Actividades de Inversión");
            Console.WriteLine("3. Actividades de Financiamiento");
            MostrarLineaDivisora(false, true);
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 3);
            return opcion;
        }
        // MARK: Menú Actividades
        public static int MostrarMenuActividades()
        {
            MostrarTituloSubrayado("Seleccione la actividad del flujo de efectivo", true, true);
            Console.WriteLine("1. Actividades de Operación");
            Console.WriteLine("2. Actividades de Inversión");
            Console.WriteLine("3. Actividades de Financiamiento");
            MostrarLineaDivisora(false, true);
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 3);
            return opcion;
        }
        public static int MostrarMenuActividadesConSalida()
        {
            MostrarTituloSubrayado("Seleccione la actividad del flujo de efectivo", true, true);
            Console.WriteLine("Seleccione el tipo de actividad que desea agregar al calculo:");
            MostrarLineaDivisora(true, false);
            Console.WriteLine("1. Actividades de Operación");
            Console.WriteLine("2. Actividades de Inversión");
            Console.WriteLine("3. Actividades de Financiamiento");
            MostrarLineaDivisora(true, false);
            Console.WriteLine("0. Finalizar y calcular Flujo de Efectivo");
            MostrarLineaDivisora(false, true);

            int opcion = SolicitarEnteroConLimites(0, 3);
            return opcion;
        }

        // MARK: Menú Tipo de Movimiento
        public static int MostrarMenuTipoMovimiento()
        {
            Console.WriteLine();
            Console.WriteLine("¿El movimiento es una Entrada de efectivo?");
            Console.WriteLine("1. Si (Entrada - aumenta efectivo)");
            Console.WriteLine("2. No (Salida - disminuye efectivo)");
            int opcion = SolicitarEnteroConLimites(1, 2);
            return opcion;
        }

        // MARK: Menú Confirmación
        public static int MostrarMenuConfirmacion(string mensaje)
        {
            Console.WriteLine($"{mensaje}");
            Console.WriteLine("1. Si, eliminar");
            Console.WriteLine("2. No, cancelar");
            int confirmacion = SolicitarEnteroConLimites(1, 2);
            return confirmacion;
        }

        // MARK: Menú Continuar
        public static int MostrarMenuContinuar()
        {
            Console.WriteLine();
            Console.WriteLine("¿Desea agregar otra cuenta?");
            Console.WriteLine("1. Si, agregar otra cuenta");
            Console.WriteLine("2. No, finalizar y calcular Flujo de Efectivo");
            int opcion = SolicitarEnteroConLimites(1, 2);
            return opcion;
        }


    }
}
