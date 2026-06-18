using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.EstadoResultados;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones;

/// <summary>Acción para que el usuario agregue una cuenta nueva a una categoría del Estado de Resultados.</summary>
public static class AccionAgregarCuenta
{
    public static void Ejecutar()
    {
        // La categoría (1-5) coincide en orden con ObtenerCatalogo(), por eso usamos [categoria - 1].
        int categoria = MostrarMenuCategorias("Agregar Cuenta - Estado de Resultados");

        Console.WriteLine("\nIngrese el nombre de la nueva cuenta:");
        string nombre = SolicitarString();

        bool esDeudora = MostrarMenuNaturalezaCuenta() == 1; // 1 = Egreso (deudora), 2 = Ingreso (acreedora)

        var (grupo, lista) = ObtenerCatalogo()[categoria - 1];

        Cuenta nueva = Cuenta.Crear(nombre, esDeudora);
        nueva.EsCreadoPorUsuario = true;
        lista.Add(nueva);

        MostrarMensajeExito($"Cuenta '{nombre}' agregada exitosamente a {grupo}.", true, false);
        Console.WriteLine($"Naturaleza: {(esDeudora ? "Egreso (-)" : "Ingreso (+)")}");
        EsperarTecla();
    }
}
