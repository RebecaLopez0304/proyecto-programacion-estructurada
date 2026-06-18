using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Catalogos.CuentasBalanceGeneral;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.BalanceGeneral;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones;

/// <summary>Acciones para mostrar las cuentas del Balance General de distintas formas.</summary>
public static class AccionesVerCuentas
{
    #region Todas las cuentas

    /// <summary>Muestra todas las cuentas agrupadas en Activos, Pasivos y Capital.</summary>
    public static void MostrarTodasCuentasBalanceGeneral()
    {
        MostrarLineaDivisoraConTexto("ACTIVOS", true);
        MostrarSeccion("Activo circulante", ActivoCirculante);
        MostrarSeccion("Activo fijo", ActivoFijo);
        MostrarSeccion("Activo intangible", ActivoIntangible);
        MostrarSeccion("Otros activos", OtrosActivos);

        MostrarLineaDivisoraConTexto("PASIVOS", true);
        MostrarSeccion("Pasivo a largo plazo", PasivoLargoPlazo);
        MostrarSeccion("Pasivo a corto plazo", PasivoCortoPlazo);

        MostrarLineaDivisoraConTexto("CAPITAL", true);
        MostrarSeccion("Capital contribuido", CapitalContribuido);
        MostrarSeccion("Capital ganado", CapitalGanado);

        EsperarTecla();
    }

    #endregion

    #region Cuentas generales

    /// <summary>Submenú para ver Activos, Pasivos o Capital por separado.</summary>
    public static void MostrarCuentasGeneralesBalanceGeneral()
    {
        bool salir = false;

        while (!salir)
        {
            switch (MostrarMenuCuentasGenerales())
            {
                case 1:
                    MostrarTituloSubrayado("ACTIVOS", true, true);
                    MostrarSeccion("Activo circulante", ActivoCirculante);
                    MostrarSeccion("Activo fijo", ActivoFijo);
                    MostrarSeccion("Activo intangible", ActivoIntangible);
                    MostrarSeccion("Otros activos", OtrosActivos);
                    EsperarTecla();
                    break;
                case 2:
                    MostrarTituloSubrayado("PASIVOS", true, true);
                    MostrarSeccion("Pasivo a largo plazo", PasivoLargoPlazo);
                    MostrarSeccion("Pasivo a corto plazo", PasivoCortoPlazo);
                    EsperarTecla();
                    break;
                case 3:
                    MostrarTituloSubrayado("CAPITAL", true, true);
                    MostrarSeccion("Capital contribuido", CapitalContribuido);
                    MostrarSeccion("Capital ganado", CapitalGanado);
                    EsperarTecla();
                    break;
                case 0:
                    salir = true;
                    break;
            }
        }
    }

    #endregion

    #region Cuentas subclasificadas

    /// <summary>Submenú para ver una subclasificación concreta (las 8 categorías).</summary>
    public static void MostrarCuentasSubclasificadasBalanceGeneral()
    {
        bool volver = false;

        while (!volver)
        {
            switch (MostrarMenuCuentasSubclasificadas())
            {
                case 1: MostrarSeccion("Activo circulante", ActivoCirculante); EsperarTecla(); break;
                case 2: MostrarSeccion("Activo fijo", ActivoFijo); EsperarTecla(); break;
                case 3: MostrarSeccion("Activo intangible", ActivoIntangible); EsperarTecla(); break;
                case 4: MostrarSeccion("Otros activos", OtrosActivos); EsperarTecla(); break;
                case 5: MostrarSeccion("Pasivo a largo plazo", PasivoLargoPlazo); EsperarTecla(); break;
                case 6: MostrarSeccion("Pasivo a corto plazo", PasivoCortoPlazo); EsperarTecla(); break;
                case 7: MostrarSeccion("Capital contribuido", CapitalContribuido); EsperarTecla(); break;
                case 8: MostrarSeccion("Capital ganado", CapitalGanado); EsperarTecla(); break;
                case 0: volver = true; break;
            }
        }
    }

    #endregion
}
