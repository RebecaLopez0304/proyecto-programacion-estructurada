using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos.CuentasEstadoResultados;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.EstadoResultados;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones;

/// <summary>Acciones para mostrar las cuentas del Estado de Resultados.</summary>
public static class AccionesVerCuentas
{
    #region Todas las cuentas

    /// <summary>Muestra todas las cuentas de todas las categorías.</summary>
    public static void MostrarTodoER()
    {
        MostrarLineaDivisoraConTexto("Todas las Cuentas - Estado de Resultados", true, false);

        MostrarSeccion("Ventas", Ventas);
        MostrarSeccion("Costos de ventas", CostoDeVentas);
        MostrarSeccion("Gastos de operación", GastoDeOperacion);
        MostrarSeccion("Gastos de administración", GastosAdministracion);
        MostrarSeccion("Gastos y productos financieros", OtrosResultadosFinancieros);

        EsperarTecla();
    }

    #endregion

    #region Por categoría

    /// <summary>Submenú para ver una categoría concreta.</summary>
    public static void MostrarPorCategoriaER()
    {
        bool salir = false;

        while (!salir)
        {
            switch (MenuPorCategoriaER())
            {
                case 1: MostrarSeccion("Ventas", Ventas); EsperarTecla(); break;
                case 2: MostrarSeccion("Costos de ventas", CostoDeVentas); EsperarTecla(); break;
                case 3: MostrarSeccion("Gastos de operación", GastoDeOperacion); EsperarTecla(); break;
                case 4: MostrarSeccion("Gastos de administración", GastosAdministracion); EsperarTecla(); break;
                case 5: MostrarSeccion("Gastos y productos financieros", OtrosResultadosFinancieros); EsperarTecla(); break;
                case 0: salir = true; break;
            }
        }
    }

    #endregion
}
