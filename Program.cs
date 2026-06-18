using static ProyectoProgramacion.Comunes.Utilidades;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo;

namespace ProyectoProgramacion;

/// <summary>
/// Punto de entrada del programa. Muestra el menú principal y dirige al usuario hacia
/// cada estado financiero: Balance General, Estado de Resultados y Flujo de Efectivo.
/// </summary>
internal class Program
{
    private static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            int opcion = MostrarMenuPrincipal();

            switch (opcion)
            {
                case 1:
                    BalanceGeneral.Ejecutar();
                    break;

                case 2:
                    EstadoResultados.Ejecutar();
                    break;

                case 3:
                    FlujoEfectivo.Ejecutar();
                    break;

                case 0:
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }
        }
    }

    /// <summary>Muestra el menú principal y devuelve la opción elegida (0-3).</summary>
    private static int MostrarMenuPrincipal()
    {
        MostrarLineaDivisoraConTexto("Menu Principal", true, true);
        MostrarTituloSubrayado("Seleccione una opcion (0-3):");

        Console.WriteLine("1. Balance General");
        Console.WriteLine("2. Estado de Resultados");
        Console.WriteLine("3. Flujo de Efectivo");

        MostrarLineaDivisora(true);
        Console.WriteLine("0. Salir");

        return SolicitarEnteroConLimites(0, 3);
    }
}
