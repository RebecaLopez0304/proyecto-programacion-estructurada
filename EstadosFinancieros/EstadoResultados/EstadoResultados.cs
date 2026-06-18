using ProyectoProgramacion.Comunes;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados;

/// <summary>
/// Módulo del Estado de Resultados. Aporta su configuración y su cálculo; el resto del
/// menú (ver, agregar, eliminar, buscar, modificar) lo resuelven las acciones compartidas.
/// </summary>
public static class EstadoResultados
{
    #region Configuración

    /// <summary>Datos que distinguen a este estado financiero de los demás.</summary>
    public static ConfigCuentas Config
    {
        get
        {
            return new ConfigCuentas(
                nombre: "Estado de Resultados",
                catalogo: ObtenerCatalogo(),
                etiquetaPositiva: "Egreso",
                etiquetaNegativa: "Ingreso");
        }
    }

    /// <summary>Devuelve todas las listas del Estado de Resultados junto al nombre de su grupo.</summary>
    private static List<(string grupo, List<Cuenta> lista)> ObtenerCatalogo()
    {
        return new List<(string grupo, List<Cuenta> lista)>
        {
            ("Ventas", CuentasEstadoResultados.Ventas),
            ("Costo de Ventas", CuentasEstadoResultados.CostoDeVentas),
            ("Gastos de Operación", CuentasEstadoResultados.GastoDeOperacion),
            ("Gastos de Administración", CuentasEstadoResultados.GastosAdministracion),
            ("Otros Resultados Financieros", CuentasEstadoResultados.OtrosResultadosFinancieros),
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
                    AccionCalcularEstadoResultados.Ejecutar();
                    break;

                case 0:
                    volver = true;
                    break;
            }
        }
    }

    #endregion
}
