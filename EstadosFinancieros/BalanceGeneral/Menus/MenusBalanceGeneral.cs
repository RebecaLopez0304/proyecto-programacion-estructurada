using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus
{
    public static class MenusBalanceGeneral
    {
        // MARK: Menú Principal
        public static int MostrarMenuPrincipal()
        {
            MostrarLineaDivisoraConTexto("Menu Balance General", true, true);
            MostrarTituloSubrayado("Seleccione una opcion (0-4):", false, true);
            Console.WriteLine("1. Ver Cuentas");
            Console.WriteLine("2. Agregar Cuenta");
            Console.WriteLine("3. Eliminar Cuenta");
            MostrarLineaDivisora(false, true);
            Console.WriteLine("4. Realizar calculo de Balance General");
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 4);
            return opcion;
        }

        // MARK: Menú Ver Cuentas
        public static int MostrarMenuVerCuentas()
        {
            MostrarTituloSubrayado("Ver Cuentas - Balance General", true, true);
            Console.WriteLine("1. Ver todas las cuentas");
            Console.WriteLine("2. Ver cuentas generales (Activos, Pasivos, Capital)");
            Console.WriteLine("3. Ver cuentas subclasificadas");
            MostrarLineaDivisora(true, true);
            VolverAtras();

            int opcion = SolicitarEnteroConLimites(0, 3);
            return opcion;
        }

        // MARK: Menú Categorías
        public static int MostrarMenuCategorias(string titulo)
        {
            MostrarTituloSubrayado(titulo, true, true);
            Console.WriteLine("Seleccione la categoria principal:");
            MostrarLineaDivisora(true, false);

            MostrarTituloSubrayado("Activos", false, true);
            Console.WriteLine("1. Activo Circulante");
            Console.WriteLine("2. Activo Fijo");
            Console.WriteLine("3. Activo Intangible");
            Console.WriteLine("4. Otros Activos");

            MostrarTituloSubrayado("Pasivos", false, true);
            Console.WriteLine("5. Pasivo a Largo Plazo");
            Console.WriteLine("6. Pasivo a Corto Plazo");

            MostrarTituloSubrayado("Capital", false, true);
            Console.WriteLine("7. Capital Contribuido");
            Console.WriteLine("8. Capital Ganado");
            MostrarLineaDivisora(true, true);

            int categoria = SolicitarEnteroConLimites(1, 8);
            return categoria;
        }

        // MARK: Menú Categorías con Salida
        public static int MostrarMenuCategoriasConSalida()
        {
            MostrarTituloSubrayado("Seleccione la categoria de cuenta", true, true);
            Console.WriteLine("Seleccione el tipo de cuenta que desea agregar al calculo:");
            MostrarLineaDivisora(true, false);

            MostrarTituloSubrayado("ACTIVOS", false, true);
            Console.WriteLine("1. Activo Circulante");
            Console.WriteLine("2. Activo Fijo");
            Console.WriteLine("3. Activo Intangible");
            Console.WriteLine("4. Otros Activos");

            MostrarTituloSubrayado("PASIVOS", false, true);
            Console.WriteLine("5. Pasivo a Largo Plazo");
            Console.WriteLine("6. Pasivo a Corto Plazo");

            MostrarTituloSubrayado("CAPITAL", false, true);
            Console.WriteLine("7. Capital Contribuido");
            Console.WriteLine("8. Capital Ganado");

            MostrarLineaDivisora(true, false);
            Console.WriteLine("0. Finalizar y calcular Balance General");
            MostrarLineaDivisora(false, true);

            int categoria = SolicitarEnteroConLimites(0, 8);
            return categoria;
        }

        // MARK: Menú Naturaleza de Cuenta
        public static int MostrarMenuNaturalezaCuenta()
        {
            Console.WriteLine();
            Console.WriteLine("¿La cuenta es de naturaleza Deudora?");
            Console.WriteLine("1. Si (Deudora - aumenta con cargos/debitos)");
            Console.WriteLine("2. No (Acreedora - aumenta con abonos/creditos)");
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
            Console.WriteLine("2. No, calcular Balance General");
            int opcion = SolicitarEnteroConLimites(1, 2);
            return opcion;
        }

        // MARK: Menú Cuentas Generales
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

        // MARK: Menú Cuentas Subclasificadas
        public static int MostrarMenuCuentasSubclasificadas()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("--- Cuentas Subclasificadas ---");
            Console.WriteLine();

            Console.WriteLine("ACTIVOS");
            Console.WriteLine("  1. Activo circulante");
            Console.WriteLine("  2. Activo fijo");
            Console.WriteLine("  3. Activo intangible");
            Console.WriteLine("  4. Otros activos");
            Console.WriteLine();

            Console.WriteLine("PASIVOS");
            Console.WriteLine("  5. Pasivo a largo plazo");
            Console.WriteLine("  6. Pasivo a corto plazo");
            Console.WriteLine();

            Console.WriteLine("CAPITAL");
            Console.WriteLine("  7. Capital ganado");
            Console.WriteLine("  8. Capital contribuido");
            Console.WriteLine();
            VolverAtras();

            Console.Write("Seleccione la subclasificacion que desea ver (0-8): ");
            int opcion = SolicitarEnteroConLimites(0, 8);
            return opcion;
        }
    }
}
