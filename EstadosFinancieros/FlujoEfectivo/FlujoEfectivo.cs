using ProyectoProgramacion.Comunes;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo;

/// <summary>
/// Módulo del Flujo de Efectivo. Coordina el menú y reparte el trabajo entre las acciones:
/// ver, agregar, eliminar, buscar, modificar y calcular cuentas.
/// </summary>
public static class FlujoEfectivo
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
                case 6: AccionCalcularFlujoEfectivo.Ejecutar(); break;
                case 0: volver = true; break;
            }
        }
    }

    #endregion

    #region Catálogo de cuentas

    /// <summary>Devuelve todas las listas del Flujo de Efectivo junto al nombre de su actividad.</summary>
    public static List<(string grupo, List<Cuenta> lista)> ObtenerCatalogo() => new()
    {
        ("Actividades de Operación", CuentasFlujoEfectivo.ActividadesOperacion),
        ("Actividades de Inversión", CuentasFlujoEfectivo.ActividadesInversion),
        ("Actividades de Financiamiento", CuentasFlujoEfectivo.ActividadesFinanciamiento),
    };

    #endregion

    #region Ver cuentas

    /// <summary>Submenú para ver las cuentas (todas o por actividad).</summary>
    private static void VerCuentas()
    {
        bool volver = false;

        while (!volver)
        {
            switch (MostrarMenuVerCuentas())
            {
                case 1: AccionesVerCuentas.MostrarTodasCuentasFlujoEfectivo(); break;
                case 2: AccionesVerCuentas.MostrarCuentasPorActividad(); break;
                case 0: volver = true; break;
            }
        }
    }

    /// <summary>Imprime una sección con su título y las cuentas indicadas (entrada/salida + nombre).</summary>
    public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas)
    {
        MostrarTituloSubrayado(titulo, true);

        foreach (Cuenta cuenta in listaDeCuentas)
        {
            string naturaleza = cuenta.EsDeudora ? "[ Entrada   ]" : "[ Salida    ]";
            Console.WriteLine($"\t{naturaleza} \t{cuenta.Nombre} ");
        }
    }

    #endregion
}
