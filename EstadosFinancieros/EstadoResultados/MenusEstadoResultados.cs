using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    /*
    ===========================
        Menus del Estado de Resultados
    ===========================
    */
    public static class MenusEstadoResultados
    {
        // TODO: Implementar todos los métodos de menú necesarios

        // Ejemplo de firma de método:
        public static int MostrarMenuPrincipal()
        {
            MostrarLineaDivisoraConTexto("Estado de Resultados", true, true);
            Console.WriteLine("1. Ver Cuentas");
            Console.WriteLine("2. Agregar Cuenta");
            Console.WriteLine("3. Eliminar Cuenta");
            Console.WriteLine("4. Calcular Estado de Resultados");
            MostrarLineaDivisora(true, true);
            Console.WriteLine("0. Volver");
            return SolicitarEnteroConLimites(0, 4);
        }


        // MostrarCuentasGeneralesEstadoResultados 
        public static int MostrarMenuCuentas()
        {
            MostrarTituloSubrayado("Ver Cuentas - Estado de Resultados - Cuentas", true, true);
            Console.WriteLine("1. Mostrar todas las cuentas");
            Console.WriteLine("2. Mostrar por categoría");
            VolverAtras();

            int opcion = SolicitarEnteroConLimites(0, 2);
            return opcion;
        }


        public static int MenuPorCategoriaER()
        {
            MostrarTituloSubrayado("Ver Cuentas - Estado de Resultados - Cuentas", true, true);
            Console.WriteLine("1. Ventas");
            Console.WriteLine("2. Costo de Ventas");
            Console.WriteLine("3. Gastos de Operación");
            Console.WriteLine("4. Gastos de Administración");
            Console.WriteLine("5. Otros Resultados Financieros");
            VolverAtras();

            int opcion = SolicitarEnteroConLimites(0, 5);
            return opcion;
        }

        public static int MostrarMenuCategorias(string titulo)
        {
            MostrarTituloSubrayado(titulo, true, true);
            Console.WriteLine("Seleccione la categoria de cuenta:");
            Console.WriteLine("1. Ingresos");
            Console.WriteLine("2. Costo de Ventas");
            Console.WriteLine("3. Gastos de operación");
            Console.WriteLine("4. Gastos de Administración");
            Console.WriteLine("5. Otros Resultados Financieros");

            int categoria = SolicitarEnteroConLimites(1, 5);
            return categoria;
        }

        public static int MostrarMenuCategoriasConSalida()
        {
            MostrarTituloSubrayado("Seleccione la categoria de cuenta (0 para terminar)", true, true);

            Console.WriteLine("0. Terminar selección");
            Console.WriteLine("1. Ingresos");
            Console.WriteLine("2. Costo de Ventas");
            Console.WriteLine("3. Gastos de operación");
            Console.WriteLine("4. Gastos de Administración");
            Console.WriteLine("5. Otros Resultados Financieros");

            int categoria = SolicitarEnteroConLimites(0, 5);
            return categoria;
        }

        public static int MostrarMenuNaturalezaCuenta()
        {
            Console.WriteLine();
            Console.WriteLine("¿Qué tipo de cuenta es?");
            Console.WriteLine("1. Egreso (disminuye la utilidad - costos/gastos)");
            Console.WriteLine("2. Ingreso (aumenta la utilidad - ventas/productos)");
            int naturalezaOpcion = SolicitarEnteroConLimites(1, 2);
            return naturalezaOpcion;
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
            Console.WriteLine("2. No, calcular Balance General");
            int opcion = SolicitarEnteroConLimites(1, 2);
            return opcion;
        }

        public static int MostrarMenuCuentasGenerales()
        {
            MostrarTituloSubrayado("Cuentas Generales del Balance General", true, true);
            Console.WriteLine("1. Activos");
            Console.WriteLine("2. Pasivos");
            Console.WriteLine("3. Capital");
            MostrarLineaDivisora(true, true);
            VolverAtras();

            int opcion = SolicitarEnteroConLimites(0, 3);
            return opcion;
        }



    }
}
