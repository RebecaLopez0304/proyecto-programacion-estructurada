using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.BalanceGeneral;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus.MenusBalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones;

/// <summary>Acción para que el usuario agregue una cuenta nueva a una categoría del Balance General.</summary>
public static class AccionAgregarCuenta
{
    public static void Ejecutar()
    {
        // La categoría (1-8) coincide en orden con ObtenerCatalogo(), por eso usamos [categoria - 1].
        int categoria = MostrarMenuCategorias("Agregar Cuenta - Balance General");

        Console.WriteLine("\nIngrese el nombre de la nueva cuenta:");
        string nombre = SolicitarString();

        bool esDeudora = MostrarMenuNaturalezaCuenta() == 1;

        var (grupo, lista) = ObtenerCatalogo()[categoria - 1];

        Cuenta nueva = Cuenta.Crear(nombre, esDeudora);
        nueva.EsCreadoPorUsuario = true;
        lista.Add(nueva);

        MostrarMensajeExito($"Cuenta '{nombre}' agregada exitosamente a {grupo}.", true, false);
        Console.WriteLine($"Naturaleza: {(esDeudora ? "Deudora (+)" : "Acreedora (-)")}");
        EsperarTecla();
    }
}
