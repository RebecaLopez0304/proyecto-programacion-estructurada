using ProyectoProgramacion.Comunes;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones.AccionesVerCuentas;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados;

/// <summary>
/// Módulo del Estado de Resultados. Coordina el menú y reparte el trabajo entre las
/// acciones: ver, agregar, eliminar, buscar, modificar y calcular cuentas.
/// </summary>
public static class EstadoResultados
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
                case 6: AccionCalcularEstadoResultados.Ejecutar(); break;
                case 0: volver = true; break;
            }
        }
    }

    #endregion

    #region Catálogo de cuentas

    /// <summary>Devuelve todas las listas del Estado de Resultados junto al nombre de su grupo.</summary>
    public static List<(string grupo, List<Cuenta> lista)> ObtenerCatalogo() => new()
    {
        ("Ventas", CuentasEstadoResultados.Ventas),
        ("Costo de Ventas", CuentasEstadoResultados.CostoDeVentas),
        ("Gastos de Operación", CuentasEstadoResultados.GastoDeOperacion),
        ("Gastos de Administración", CuentasEstadoResultados.GastosAdministracion),
        ("Otros Resultados Financieros", CuentasEstadoResultados.OtrosResultadosFinancieros),
    };

    #endregion

    #region Ver cuentas

    /// <summary>Submenú para ver las cuentas (todas o por categoría).</summary>
    private static void VerCuentas()
    {
        bool regresar = false;

        while (!regresar)
        {
            switch (MostrarMenuCuentas())
            {
                case 1: MostrarTodoER(); break;
                case 2: MostrarPorCategoriaER(); break;
                case 0: regresar = true; break;
            }
        }
    }

    /// <summary>Imprime una sección con su título y las cuentas indicadas (ingreso/egreso + nombre).</summary>
    public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas)
    {
        MostrarTituloSubrayado(titulo, true);

        foreach (Cuenta cuenta in listaDeCuentas)
        {
            string naturaleza = cuenta.EsDeudora ? "[ Egreso    ]" : "[ Ingreso   ]";
            Console.WriteLine($"\t{naturaleza} \t{cuenta.Nombre} ");
        }
    }

    #endregion
}
