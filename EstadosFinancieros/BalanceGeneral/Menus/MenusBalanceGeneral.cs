using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus;

/// <summary>Menús (texto en pantalla + lectura de la opción) del módulo Balance General.</summary>
public static class MenusBalanceGeneral
{
    #region Menús del módulo

    /// <summary>Menú principal del Balance General. Devuelve la opción elegida (0-6).</summary>
    public static int MostrarMenuPrincipal()
    {
        MostrarLineaDivisoraConTexto("Menu Balance General", true, true);
        MostrarTituloSubrayado("Seleccione una opcion:", false, true);
        Console.WriteLine("1. Ver Cuentas");
        Console.WriteLine("2. Agregar Cuenta");
        Console.WriteLine("3. Eliminar Cuenta");
        Console.WriteLine("4. Buscar Cuenta");
        Console.WriteLine("5. Modificar Cuenta");
        MostrarLineaDivisora(false, true);
        Console.WriteLine("6. Realizar calculo de Balance General");
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 6);
    }

    /// <summary>Submenú para elegir cómo ver las cuentas. Devuelve la opción elegida (0-3).</summary>
    public static int MostrarMenuVerCuentas()
    {
        MostrarTituloSubrayado("Ver Cuentas - Balance General", true, true);
        Console.WriteLine("1. Ver todas las cuentas");
        Console.WriteLine("2. Ver cuentas generales (Activos, Pasivos, Capital)");
        Console.WriteLine("3. Ver cuentas subclasificadas");
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 3);
    }

    #endregion

    #region Menús de selección de categoría

    /// <summary>Lista las 8 categorías del Balance General y devuelve la elegida (1-8).</summary>
    public static int MostrarMenuCategorias(string titulo)
    {
        MostrarTituloSubrayado(titulo, true, true);
        Console.WriteLine("Seleccione la categoria de cuenta:");
        MostrarCategorias();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(1, 8);
    }

    /// <summary>Igual que <see cref="MostrarMenuCategorias"/> pero con opción 0 para finalizar (0-8).</summary>
    public static int MostrarMenuCategoriasConSalida()
    {
        MostrarTituloSubrayado("Seleccione la categoria de cuenta", true, true);
        Console.WriteLine("Seleccione el tipo de cuenta que desea agregar al calculo:");
        MostrarCategorias();
        MostrarLineaDivisora(true, false);
        Console.WriteLine("0. Finalizar y calcular Balance General");
        MostrarLineaDivisora(false, true);

        return SolicitarEnteroConLimites(0, 8);
    }

    /// <summary>Imprime las 8 categorías (Activos, Pasivos, Capital). Reutilizado por los menús de arriba.</summary>
    private static void MostrarCategorias()
    {
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
    }

    /// <summary>Submenú de cuentas generales (Activos/Pasivos/Capital). Devuelve la opción (0-3).</summary>
    public static int MostrarMenuCuentasGenerales()
    {
        MostrarTituloSubrayado("Cuentas Generales del Balance General", true, true);
        Console.WriteLine("1. Activos");
        Console.WriteLine("2. Pasivos");
        Console.WriteLine("3. Capital");
        MostrarLineaDivisora(true, true);
        VolverAtras();

        return SolicitarEnteroConLimites(0, 3);
    }

    /// <summary>Submenú de subclasificaciones del Balance General. Devuelve la opción (0-8).</summary>
    public static int MostrarMenuCuentasSubclasificadas()
    {
        MostrarTituloSubrayado("Cuentas Subclasificadas", true, true);
        MostrarCategorias();
        MostrarLineaDivisora(true, true);
        VolverAtras();

        return SolicitarEnteroConLimites(0, 8);
    }

    #endregion

    #region Menús de la acción Agregar

    /// <summary>Pregunta la naturaleza de la cuenta nueva. Devuelve 1 (deudora) o 2 (acreedora).</summary>
    public static int MostrarMenuNaturalezaCuenta()
    {
        Console.WriteLine();
        Console.WriteLine("¿La cuenta es de naturaleza Deudora?");
        Console.WriteLine("1. Si (Deudora - aumenta con cargos/debitos)");
        Console.WriteLine("2. No (Acreedora - aumenta con abonos/creditos)");

        return SolicitarEnteroConLimites(1, 2);
    }

    /// <summary>Pregunta si se desea agregar otra cuenta al cálculo. Devuelve 1 (sí) o 2 (no).</summary>
    public static int MostrarMenuContinuar()
    {
        Console.WriteLine();
        Console.WriteLine("¿Desea agregar otra cuenta?");
        Console.WriteLine("1. Si, agregar otra cuenta");
        Console.WriteLine("2. No, finalizar y calcular Balance General");

        return SolicitarEnteroConLimites(1, 2);
    }

    #endregion
}
