using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus;

/// <summary>Menús (texto en pantalla + lectura de la opción) del módulo Estado de Resultados.</summary>
public static class MenusEstadoResultados
{
    #region Menús del módulo

    /// <summary>Menú principal del Estado de Resultados. Devuelve la opción elegida (0-6).</summary>
    public static int MostrarMenuPrincipal()
    {
        MostrarLineaDivisoraConTexto("Menu Estado de Resultados", true, true);
        MostrarTituloSubrayado("Seleccione una opcion:", false, true);
        Console.WriteLine("1. Ver Cuentas");
        Console.WriteLine("2. Agregar Cuenta");
        Console.WriteLine("3. Eliminar Cuenta");
        Console.WriteLine("4. Buscar Cuenta");
        Console.WriteLine("5. Modificar Cuenta");
        MostrarLineaDivisora(false, true);
        Console.WriteLine("6. Realizar calculo de Estado de Resultados");
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 6);
    }

    /// <summary>Submenú para elegir cómo ver las cuentas. Devuelve la opción elegida (0-2).</summary>
    public static int MostrarMenuCuentas()
    {
        MostrarTituloSubrayado("Ver Cuentas - Estado de Resultados", true, true);
        Console.WriteLine("1. Ver todas las cuentas");
        Console.WriteLine("2. Ver por categoria");
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 2);
    }

    /// <summary>Submenú para ver una categoría concreta. Devuelve la opción elegida (0-5).</summary>
    public static int MenuPorCategoriaER()
    {
        MostrarTituloSubrayado("Ver Cuentas por Categoria - Estado de Resultados", true, true);
        MostrarCategorias();
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 5);
    }

    #endregion

    #region Menús de selección de categoría

    /// <summary>Lista las 5 categorías del Estado de Resultados y devuelve la elegida (1-5).</summary>
    public static int MostrarMenuCategorias(string titulo)
    {
        MostrarTituloSubrayado(titulo, true, true);
        Console.WriteLine("Seleccione la categoria de cuenta:");
        MostrarCategorias();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(1, 5);
    }

    /// <summary>Igual que <see cref="MostrarMenuCategorias"/> pero con opción 0 para finalizar (0-5).</summary>
    public static int MostrarMenuCategoriasConSalida()
    {
        MostrarTituloSubrayado("Seleccione la categoria de cuenta", true, true);
        Console.WriteLine("Seleccione el tipo de cuenta que desea agregar al calculo:");
        MostrarCategorias();
        MostrarLineaDivisora(true, false);
        Console.WriteLine("0. Finalizar y calcular Estado de Resultados");
        MostrarLineaDivisora(false, true);

        return SolicitarEnteroConLimites(0, 5);
    }

    /// <summary>Imprime las 5 categorías. Reutilizado por los menús de arriba.</summary>
    private static void MostrarCategorias()
    {
        Console.WriteLine("1. Ventas");
        Console.WriteLine("2. Costo de Ventas");
        Console.WriteLine("3. Gastos de Operación");
        Console.WriteLine("4. Gastos de Administración");
        Console.WriteLine("5. Otros Resultados Financieros");
    }

    #endregion

    #region Menús de la acción Agregar

    /// <summary>Pregunta el tipo de cuenta nueva. Devuelve 1 (egreso) o 2 (ingreso).</summary>
    public static int MostrarMenuNaturalezaCuenta()
    {
        Console.WriteLine();
        Console.WriteLine("¿Qué tipo de cuenta es?");
        Console.WriteLine("1. Egreso (disminuye la utilidad - costos/gastos)");
        Console.WriteLine("2. Ingreso (aumenta la utilidad - ventas/productos)");

        return SolicitarEnteroConLimites(1, 2);
    }

    /// <summary>Pregunta si se desea agregar otra cuenta al cálculo. Devuelve 1 (sí) o 2 (no).</summary>
    public static int MostrarMenuContinuar()
    {
        Console.WriteLine();
        Console.WriteLine("¿Desea agregar otra cuenta?");
        Console.WriteLine("1. Si, agregar otra cuenta");
        Console.WriteLine("2. No, finalizar y calcular Estado de Resultados");

        return SolicitarEnteroConLimites(1, 2);
    }

    #endregion
}
