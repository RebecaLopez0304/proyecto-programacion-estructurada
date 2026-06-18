using ProyectoProgramacion.Comunes;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo;

/// <summary>
/// Módulo del Flujo de Efectivo. Aporta su configuración y su cálculo; el resto del menú
/// (ver, agregar, eliminar, buscar, modificar) lo resuelven las acciones compartidas.
/// </summary>
public static class FlujoEfectivo
{
    #region Configuración

    /// <summary>Datos que distinguen a este estado financiero de los demás.</summary>
    public static ConfigCuentas Config
    {
        get
        {
            return new ConfigCuentas(
                nombre: "Flujo de Efectivo",
                catalogo: ObtenerCatalogo(),
                etiquetaPositiva: "Entrada",
                etiquetaNegativa: "Salida",
                pedirGrupoBalance: true);
        }
    }

    /// <summary>Devuelve todas las listas del Flujo de Efectivo junto al nombre de su actividad.</summary>
    private static List<(string grupo, List<Cuenta> lista)> ObtenerCatalogo()
    {
        return new List<(string grupo, List<Cuenta> lista)>
        {
            ("Actividades de Operación", CuentasFlujoEfectivo.ActividadesOperacion),
            ("Actividades de Inversión", CuentasFlujoEfectivo.ActividadesInversion),
            ("Actividades de Financiamiento", CuentasFlujoEfectivo.ActividadesFinanciamiento),
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
                    AccionCalcularFlujoEfectivo.Ejecutar();
                    break;

                case 0:
                    volver = true;
                    break;
            }
        }
    }

    #endregion
}
