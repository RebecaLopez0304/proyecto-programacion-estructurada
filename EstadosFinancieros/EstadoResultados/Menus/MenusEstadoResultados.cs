using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus
{
    /*
    ===========================
        Menus del Estado de Resultados
    ===========================
    IMPORTANTE: Todas las funciones deben ser públicas y estáticas
    */
    public static class MenusEstadoResultados
    {
        // MARK: Menú Principal
        public static int MostrarMenuPrincipal()
        {
            MostrarLineaDivisoraConTexto("Menu Estado de Resultados", true, true);
            MostrarTituloSubrayado("Seleccione una opcion:", false, true);
            Console.WriteLine("1. Ver Cuentas");
            Console.WriteLine("2. Agregar Cuenta");
            Console.WriteLine("3. Eliminar Cuenta");
            MostrarLineaDivisora(false, true);
            Console.WriteLine("4. Realizar calculo de Estado de Resultados");
            MostrarLineaDivisora(false, true);
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 4);
            return opcion;
        }

        // MARK: Menú Ver Cuentas
        public static int MostrarMenuCuentas()
        {
            MostrarTituloSubrayado("Ver Cuentas - Estado de Resultados", true, true);
            Console.WriteLine("1. Ver todas las cuentas");
            Console.WriteLine("2. Ver por categoria");
            MostrarLineaDivisora(false, true);
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 2);
            return opcion;
        }

        // MARK: Menú Por Categoría
        public static int MenuPorCategoriaER()
        {
            MostrarTituloSubrayado("Ver Cuentas - Estado de Resultados - Por Categoria", true, true);
            Console.WriteLine("1. Ventas");
            Console.WriteLine("2. Costo de Ventas");
            Console.WriteLine("3. Gastos de Operación");
            Console.WriteLine("4. Gastos de Administración");
            Console.WriteLine("5. Otros Resultados Financieros");
            MostrarLineaDivisora(false, true);
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 5);
            return opcion;
        }

        // MARK: Menú Categorías
        public static int MostrarMenuCategorias(string titulo)
        {
            MostrarTituloSubrayado(titulo, true, true);
            Console.WriteLine("Seleccione la categoria de cuenta:");
            MostrarLineaDivisora(true, false);
            Console.WriteLine("1. Ventas");
            Console.WriteLine("2. Costo de Ventas");
            Console.WriteLine("3. Gastos de Operación");
            Console.WriteLine("4. Gastos de Administración");
            Console.WriteLine("5. Otros Resultados Financieros");
            MostrarLineaDivisora(true, true);

            int categoria = SolicitarEnteroConLimites(1, 5);
            return categoria;
        }

        // MARK: Menú Categorías con Salida
        public static int MostrarMenuCategoriasConSalida()
        {
            MostrarTituloSubrayado("Seleccione la categoria de cuenta", true, true);
            Console.WriteLine("Seleccione el tipo de cuenta que desea agregar al calculo:");
            MostrarLineaDivisora(true, false);
            Console.WriteLine("1. Ventas");
            Console.WriteLine("2. Costo de Ventas");
            Console.WriteLine("3. Gastos de Operación");
            Console.WriteLine("4. Gastos de Administración");
            Console.WriteLine("5. Otros Resultados Financieros");
            MostrarLineaDivisora(true, false);
            Console.WriteLine("0. Finalizar y calcular Estado de Resultados");
            MostrarLineaDivisora(false, true);

            int categoria = SolicitarEnteroConLimites(0, 5);
            return categoria;
        }

        // MARK: Menú Naturaleza de Cuenta
        public static int MostrarMenuNaturalezaCuenta()
        {
            Console.WriteLine();
            Console.WriteLine("¿Qué tipo de cuenta es?");
            Console.WriteLine("1. Egreso (disminuye la utilidad - costos/gastos)");
            Console.WriteLine("2. Ingreso (aumenta la utilidad - ventas/productos)");
            int naturalezaOpcion = SolicitarEnteroConLimites(1, 2);
            return naturalezaOpcion;
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
            Console.WriteLine("2. No, finalizar y calcular Estado de Resultados");
            int opcion = SolicitarEnteroConLimites(1, 2);
            return opcion;
        }
    }
}
