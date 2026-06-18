using ProyectoProgramacion.Comunes;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Catalogos;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral;

/// <summary>
/// Módulo del Balance General. Aporta su configuración y su cálculo; el resto del menú
/// (ver, agregar, eliminar, buscar, modificar) lo resuelven las acciones compartidas.
/// </summary>
public static class BalanceGeneral
{
    #region Configuración

    /// <summary>Datos que distinguen a este estado financiero de los demás.</summary>
    public static ConfigCuentas Config
    {
        get
        {
            return new ConfigCuentas(
                nombre: "Balance General",
                catalogo: ObtenerCatalogo(),
                etiquetaPositiva: "Deudora",
                etiquetaNegativa: "Acreedora");
        }
    }

    /// <summary>Devuelve todas las listas del Balance General junto al nombre de su grupo.</summary>
    private static List<(string grupo, List<Cuenta> lista)> ObtenerCatalogo()
    {
        return new List<(string grupo, List<Cuenta> lista)>
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
    }

    #endregion

    #region Menú principal

    /// <summary>Muestra el menú del módulo hasta que el usuario elige volver (0).</summary>
    public static void Ejecutar()
    {
        bool volver = false;

        while (!volver)
        {
            int opcion = AccionesCuentas.MenuPrincipal(Config.Nombre);

            switch (opcion)
            {
                case 1:
                    AccionesCuentas.VerCuentas(Config);
                    break;

                case 2:
                    AccionesCuentas.AgregarCuenta(Config);
                    break;

                case 3:
                    AccionesCuentas.EliminarCuenta(Config);
                    break;

                case 4:
                    AccionesCuentas.BuscarCuenta(Config);
                    break;

                case 5:
                    AccionesCuentas.ModificarCuenta(Config);
                    break;

                case 6:
                    AccionCalcularBalanceGeneral.Ejecutar();
                    break;

                case 0:
                    volver = true;
                    break;
            }
        }
    }

    #endregion
}
