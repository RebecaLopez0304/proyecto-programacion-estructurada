using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus;

/// <summary>Menús (texto en pantalla + lectura de la opción) del módulo Flujo de Efectivo.</summary>
public static class MenusFlujoEfectivo
{
    #region Menús del módulo

    /// <summary>Menú principal del Flujo de Efectivo. Devuelve la opción elegida (0-6).</summary>
    public static int MostrarMenuPrincipal()
    {
        MostrarLineaDivisoraConTexto("Menu Flujo de Efectivo", true, true);
        MostrarTituloSubrayado("Seleccione una opcion:", false, true);
        Console.WriteLine("1. Ver Cuentas");
        Console.WriteLine("2. Agregar Cuenta");
        Console.WriteLine("3. Eliminar Cuenta");
        Console.WriteLine("4. Buscar Cuenta");
        Console.WriteLine("5. Modificar Cuenta");
        MostrarLineaDivisora(false, true);
        Console.WriteLine("6. Realizar calculo de Flujo de Efectivo");
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 6);
    }

    /// <summary>Submenú para elegir cómo ver las cuentas. Devuelve la opción elegida (0-2).</summary>
    public static int MostrarMenuVerCuentas()
    {
        MostrarTituloSubrayado("Ver Cuentas - Flujo de Efectivo", true, true);
        Console.WriteLine("1. Ver todas las cuentas");
        Console.WriteLine("2. Ver por actividad");
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 2);
    }

    /// <summary>Submenú para ver una actividad concreta. Devuelve la opción elegida (0-3).</summary>
    public static int MenuPorCategoriaFE()
    {
        MostrarTituloSubrayado("Ver Cuentas por Actividad - Flujo de Efectivo", true, true);
        MostrarActividades();
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 3);
    }

    #endregion

    #region Menús de selección de actividad

    /// <summary>Lista las 3 actividades y devuelve la elegida (1-3).</summary>
    public static int MostrarMenuActividades()
    {
        MostrarTituloSubrayado("Seleccione la actividad del flujo de efectivo", true, true);
        MostrarActividades();
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(1, 3);
    }

    /// <summary>Igual que <see cref="MostrarMenuActividades"/> pero con opción 0 para finalizar (0-3).</summary>
    public static int MostrarMenuActividadesConSalida()
    {
        MostrarTituloSubrayado("Seleccione la actividad del flujo de efectivo", true, true);
        Console.WriteLine("Seleccione el tipo de actividad que desea agregar al calculo:");
        MostrarActividades();
        MostrarLineaDivisora(true, false);
        Console.WriteLine("0. Finalizar y calcular Flujo de Efectivo");
        MostrarLineaDivisora(false, true);

        return SolicitarEnteroConLimites(0, 3);
    }

    /// <summary>Imprime las 3 actividades. Reutilizado por los menús de arriba.</summary>
    private static void MostrarActividades()
    {
        Console.WriteLine("1. Actividades de Operación");
        Console.WriteLine("2. Actividades de Inversión");
        Console.WriteLine("3. Actividades de Financiamiento");
    }

    #endregion

    #region Menús de la acción Agregar

    /// <summary>Pregunta el tipo de movimiento. Devuelve 1 (entrada) o 2 (salida).</summary>
    public static int MostrarMenuTipoMovimiento()
    {
        Console.WriteLine();
        Console.WriteLine("¿El movimiento es una Entrada de efectivo?");
        Console.WriteLine("1. Si (Entrada - aumenta efectivo)");
        Console.WriteLine("2. No (Salida - disminuye efectivo)");

        return SolicitarEnteroConLimites(1, 2);
    }

    /// <summary>Pregunta si se desea agregar otra cuenta al cálculo. Devuelve 1 (sí) o 2 (no).</summary>
    public static int MostrarMenuContinuar()
    {
        Console.WriteLine();
        Console.WriteLine("¿Desea agregar otra cuenta?");
        Console.WriteLine("1. Si, agregar otra cuenta");
        Console.WriteLine("2. No, finalizar y calcular Flujo de Efectivo");

        return SolicitarEnteroConLimites(1, 2);
    }

    #endregion
}
