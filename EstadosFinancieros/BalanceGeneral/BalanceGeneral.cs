using ProyectoProgramacion.Comunes;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Catalogos;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones.AccionesVerCuentas;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral;

/// <summary>
/// Módulo del Balance General. Coordina el menú y reparte el trabajo entre las acciones:
/// ver, agregar, eliminar, buscar, modificar y calcular cuentas.
/// </summary>
public static class BalanceGeneral
{
    #region Menú principal

    /// <summary>Muestra el menú del módulo hasta que el usuario elige volver (0).</summary>
    public static void Ejecutar()
    {
        bool volver = false;

        while (!volver)
        {
            switch (MostrarMenuPrincipal())
            {
                case 1: VerCuentas(); break;
                case 2: AccionAgregarCuenta.Ejecutar(); break;
                case 3: AccionesCuentas.EliminarCuenta(ObtenerCatalogo()); break;
                case 4: AccionesCuentas.BuscarCuenta(ObtenerCatalogo()); break;
                case 5: AccionesCuentas.ModificarCuenta(ObtenerCatalogo()); break;
                case 6: AccionCalcularBalanceGeneral.Ejecutar(); break;
                case 0: volver = true; break;
            }
        }
    }

    #endregion

    #region Catálogo de cuentas

    /// <summary>Devuelve todas las listas del Balance General junto al nombre de su grupo.</summary>
    public static List<(string grupo, List<Cuenta> lista)> ObtenerCatalogo() => new()
    {
        ("Activo Circulante", CuentasBalanceGeneral.ActivoCirculante),
        ("Activo Fijo", CuentasBalanceGeneral.ActivoFijo),
        ("Activo Intangible", CuentasBalanceGeneral.ActivoIntangible),
        ("Otros Activos", CuentasBalanceGeneral.OtrosActivos),
        ("Pasivo a Largo Plazo", CuentasBalanceGeneral.PasivoLargoPlazo),
        ("Pasivo a Corto Plazo", CuentasBalanceGeneral.PasivoCortoPlazo),
        ("Capital Contribuido", CuentasBalanceGeneral.CapitalContribuido),
        ("Capital Ganado", CuentasBalanceGeneral.CapitalGanado),
    };

    #endregion

    #region Ver cuentas

    /// <summary>Submenú para ver las cuentas de distintas formas (todas, generales o subclasificadas).</summary>
    private static void VerCuentas()
    {
        bool regresar = false;

        while (!regresar)
        {
            switch (MostrarMenuVerCuentas())
            {
                case 1: MostrarTodasCuentasBalanceGeneral(); break;
                case 2: MostrarCuentasGeneralesBalanceGeneral(); break;
                case 3: MostrarCuentasSubclasificadasBalanceGeneral(); break;
                case 0: regresar = true; break;
            }
        }
    }

    /// <summary>Imprime una sección con su título y las cuentas indicadas (naturaleza + nombre).</summary>
    public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas)
    {
        MostrarTituloSubrayado(titulo, true);

        foreach (Cuenta cuenta in listaDeCuentas)
        {
            string naturaleza = cuenta.EsDeudora ? "[ Deudora   ]" : "[ Acreedora ]";
            Console.WriteLine($"\t{naturaleza} \t{cuenta.Nombre} ");
        }
    }

    #endregion
}
