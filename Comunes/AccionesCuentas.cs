using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.Comunes;

/// <summary>
/// Acciones sobre cuentas que comparten los tres estados financieros: buscar, modificar
/// y eliminar. Se escriben una sola vez aquí en lugar de repetirlas en cada módulo.
/// Cada módulo entrega su "catálogo": la lista de pares (grupo, cuentas de ese grupo).
/// </summary>
public static class AccionesCuentas
{
    #region Buscar

    /// <summary>Busca cuentas cuyo nombre contenga el texto indicado y las muestra en pantalla.</summary>
    public static void BuscarCuenta(List<(string grupo, List<Cuenta> lista)> catalogo)
    {
        MostrarTituloSubrayado("Buscar Cuenta", true, true);
        Console.Write("Escriba el nombre (o parte) de la cuenta a buscar: ");
        string texto = SolicitarString().ToLower();

        int encontradas = 0;
        foreach (var (grupo, lista) in catalogo)
        {
            foreach (Cuenta cuenta in lista)
            {
                if (cuenta.Nombre.ToLower().Contains(texto))
                {
                    Console.WriteLine($"  {Etiqueta(cuenta)} {cuenta.Nombre}   ({grupo})");
                    encontradas++;
                }
            }
        }

        if (encontradas == 0)
            MostrarMensajeAdvertencia($"No se encontraron cuentas que contengan '{texto}'.", true, false);
        else
            MostrarMensajeExito($"Se encontraron {encontradas} cuenta(s).", true, false);

        EsperarTecla();
    }

    #endregion

    #region Modificar

    /// <summary>Permite renombrar una de las cuentas creadas por el usuario.</summary>
    public static void ModificarCuenta(List<(string grupo, List<Cuenta> lista)> catalogo)
    {
        MostrarTituloSubrayado("Modificar Cuenta", true, true);

        List<Cuenta> cuentasUsuario = ObtenerCuentasDelUsuario(catalogo, out _);
        if (!HayCuentasDelUsuario(cuentasUsuario)) return;

        MostrarListaNumerada(cuentasUsuario);
        Console.WriteLine($"\nSeleccione la cuenta a modificar (1-{cuentasUsuario.Count}):");
        Cuenta seleccionada = cuentasUsuario[SolicitarEnteroConLimites(1, cuentasUsuario.Count) - 1];

        Console.WriteLine($"\nNombre actual: {seleccionada.Nombre}");
        Console.WriteLine("Ingrese el nuevo nombre de la cuenta:");
        seleccionada.Nombre = SolicitarString();

        MostrarMensajeExito($"Cuenta modificada. Nuevo nombre: {seleccionada.Nombre}", true, false);
        EsperarTecla();
    }

    #endregion

    #region Eliminar

    /// <summary>Permite eliminar una de las cuentas creadas por el usuario, con confirmación.</summary>
    public static void EliminarCuenta(List<(string grupo, List<Cuenta> lista)> catalogo)
    {
        MostrarTituloSubrayado("Eliminar Cuenta", true, true);

        List<Cuenta> cuentasUsuario = ObtenerCuentasDelUsuario(catalogo, out var listaDeCadaCuenta);
        if (!HayCuentasDelUsuario(cuentasUsuario)) return;

        MostrarListaNumerada(cuentasUsuario);
        Console.WriteLine($"\nSeleccione la cuenta a eliminar (1-{cuentasUsuario.Count}):");
        int indice = SolicitarEnteroConLimites(1, cuentasUsuario.Count) - 1;
        Cuenta seleccionada = cuentasUsuario[indice];

        Console.WriteLine($"\n¿Esta seguro que desea eliminar la cuenta '{seleccionada.Nombre}'?");
        Console.WriteLine("1. Si, eliminar");
        Console.WriteLine("2. No, cancelar");

        if (SolicitarEnteroConLimites(1, 2) == 1)
        {
            listaDeCadaCuenta[indice].Remove(seleccionada);
            MostrarMensajeExito($"Cuenta '{seleccionada.Nombre}' eliminada exitosamente.", true, false);
        }
        else
        {
            MostrarMensajeCancelacion("Operacion cancelada.", true, false);
        }

        EsperarTecla();
    }

    #endregion

    #region Apoyo

    /// <summary>Etiqueta de naturaleza para mostrar antes del nombre, ej. "[Deudora  ]".</summary>
    private static string Etiqueta(Cuenta cuenta) => cuenta.EsDeudora ? "[Deudora  ]" : "[Acreedora]";

    /// <summary>
    /// Recolecta las cuentas creadas por el usuario. En <paramref name="listaDeCadaCuenta"/>
    /// devuelve, en el mismo orden, la lista original a la que pertenece cada cuenta
    /// (necesario para poder eliminarla).
    /// </summary>
    private static List<Cuenta> ObtenerCuentasDelUsuario(
        List<(string grupo, List<Cuenta> lista)> catalogo, out List<List<Cuenta>> listaDeCadaCuenta)
    {
        var cuentas = new List<Cuenta>();
        listaDeCadaCuenta = new List<List<Cuenta>>();

        foreach (var (_, lista) in catalogo)
        {
            foreach (Cuenta cuenta in lista)
            {
                if (cuenta.EsCreadoPorUsuario)
                {
                    cuentas.Add(cuenta);
                    listaDeCadaCuenta.Add(lista);
                }
            }
        }

        return cuentas;
    }

    /// <summary>Avisa y devuelve false si el usuario no ha creado ninguna cuenta.</summary>
    private static bool HayCuentasDelUsuario(List<Cuenta> cuentasUsuario)
    {
        if (cuentasUsuario.Count > 0) return true;

        MostrarMensajeAdvertencia("No has creado ninguna cuenta personalizada.", true, false);
        Console.WriteLine("\tUsa la opcion 'Agregar Cuenta' para crear tus propias cuentas.");
        EsperarTecla();
        return false;
    }

    /// <summary>Imprime las cuentas numeradas (1, 2, 3...) con su etiqueta de naturaleza.</summary>
    private static void MostrarListaNumerada(List<Cuenta> cuentas)
    {
        for (int i = 0; i < cuentas.Count; i++)
            Console.WriteLine($"{i + 1}. {Etiqueta(cuentas[i])} {cuentas[i].Nombre}");
    }

    #endregion
}
