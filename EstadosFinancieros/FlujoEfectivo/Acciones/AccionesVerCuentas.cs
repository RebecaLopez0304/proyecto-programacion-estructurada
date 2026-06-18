using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos.CuentasFlujoEfectivo;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.FlujoEfectivo;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones;

/// <summary>Acciones para mostrar las cuentas del Flujo de Efectivo.</summary>
public static class AccionesVerCuentas
{
    #region Todas las cuentas

    /// <summary>Muestra todas las cuentas de las tres actividades.</summary>
    public static void MostrarTodasCuentasFlujoEfectivo()
    {
        MostrarLineaDivisoraConTexto("Todas las Cuentas - Flujo de Efectivo", true, true);
        MostrarSeccion("Actividades de Operación", ActividadesOperacion);
        MostrarSeccion("Actividades de Inversión", ActividadesInversion);
        MostrarSeccion("Actividades de Financiamiento", ActividadesFinanciamiento);
        EsperarTecla();
    }

    #endregion

    #region Por actividad

    /// <summary>Submenú para ver una actividad concreta.</summary>
    public static void MostrarCuentasPorActividad()
    {
        bool salir = false;

        while (!salir)
        {
            switch (MenuPorCategoriaFE())
            {
                case 1: MostrarSeccion("Actividades de Operación", ActividadesOperacion); EsperarTecla(); break;
                case 2: MostrarSeccion("Actividades de Inversión", ActividadesInversion); EsperarTecla(); break;
                case 3: MostrarSeccion("Actividades de Financiamiento", ActividadesFinanciamiento); EsperarTecla(); break;
                case 0: salir = true; break;
            }
        }
    }

    #endregion
}
