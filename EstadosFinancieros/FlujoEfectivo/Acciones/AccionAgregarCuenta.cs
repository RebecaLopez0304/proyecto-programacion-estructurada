using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.FlujoEfectivo;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones;

/// <summary>Acción para que el usuario agregue una cuenta nueva a una actividad del Flujo de Efectivo.</summary>
public static class AccionAgregarCuenta
{
    public static void Ejecutar()
    {
        // La actividad (1-3) coincide en orden con ObtenerCatalogo(), por eso usamos [actividad - 1].
        int actividad = MostrarMenuActividades();

        Console.WriteLine("\nIngrese el nombre de la nueva cuenta:");
        string nombre = SolicitarString();

        bool esEntrada = MostrarMenuTipoMovimiento() == 1; // Entrada (deudora) / Salida (acreedora)

        // En Flujo de Efectivo cada cuenta también indica a qué grupo del Balance General pertenece.
        Console.WriteLine("\n¿A qué grupo del Balance General pertenece esta cuenta?");
        Console.WriteLine("1. Activo");
        Console.WriteLine("2. Pasivo");
        Console.WriteLine("3. Capital Contable");
        string tipoGrupoBalance = SolicitarEnteroConLimites(1, 3) switch
        {
            1 => "Activo",
            2 => "Pasivo",
            _ => "Capital",
        };

        var (grupo, lista) = ObtenerCatalogo()[actividad - 1];

        Cuenta nueva = Cuenta.Crear(nombre, esEntrada, tipoGrupoBalance);
        nueva.EsCreadoPorUsuario = true;
        lista.Add(nueva);

        MostrarMensajeExito($"Cuenta '{nombre}' agregada exitosamente a {grupo}.", true, false);
        Console.WriteLine($"Tipo de Movimiento: {(esEntrada ? "Entrada [+]" : "Salida [-]")}");
        Console.WriteLine($"Grupo Balance General: {tipoGrupoBalance}");
        EsperarTecla();
    }
}
