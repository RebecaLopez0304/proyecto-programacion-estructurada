using static ProyectoProgramacion.Comunes.Utilidades;

namespace ProyectoProgramacion.Comunes;

/// <summary>
/// Acciones y menús sobre cuentas que comparten los tres estados financieros. Todo lo
/// común vive aquí una sola vez; cada módulo solo aporta su <see cref="ConfigCuentas"/>.
/// </summary>
public static class AccionesCuentas
{
    #region Menú principal del módulo

    /// <summary>Menú principal de un estado financiero. Devuelve la opción elegida (0-6).</summary>
    public static int MenuPrincipal(string nombre)
    {
        MostrarLineaDivisoraConTexto($"Menu {nombre}", true, true);
        MostrarTituloSubrayado("Seleccione una opcion:", false, true);
        Console.WriteLine("1. Ver Cuentas");
        Console.WriteLine("2. Agregar Cuenta");
        Console.WriteLine("3. Eliminar Cuenta");
        Console.WriteLine("4. Buscar Cuenta");
        Console.WriteLine("5. Modificar Cuenta");
        MostrarLineaDivisora(false, true);
        Console.WriteLine($"6. Realizar calculo de {nombre}");
        MostrarLineaDivisora(false, true);
        VolverAtras();
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(0, 6);
    }

    #endregion

    #region Ver cuentas

    /// <summary>Submenú para ver todas las cuentas o las de un grupo concreto.</summary>
    public static void VerCuentas(ConfigCuentas config)
    {
        bool volver = false;

        while (!volver)
        {
            MostrarTituloSubrayado($"Ver Cuentas - {config.Nombre}", true, true);
            Console.WriteLine("1. Ver todas las cuentas");
            Console.WriteLine("2. Ver cuentas de un grupo");
            MostrarLineaDivisora(false, true);
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 2);

            switch (opcion)
            {
                case 1:
                    foreach (var (grupo, lista) in config.Catalogo)
                    {
                        MostrarSeccion(grupo, lista, config);
                    }
                    EsperarTecla();
                    break;

                case 2:
                    int indice = ElegirGrupo(config);
                    var (nombreGrupo, cuentas) = config.Catalogo[indice - 1];
                    MostrarSeccion(nombreGrupo, cuentas, config);
                    EsperarTecla();
                    break;

                case 0:
                    volver = true;
                    break;
            }
        }
    }

    /// <summary>Imprime un grupo con su título y sus cuentas (naturaleza + nombre).</summary>
    public static void MostrarSeccion(string titulo, List<Cuenta> cuentas, ConfigCuentas config)
    {
        MostrarTituloSubrayado(titulo, true);

        foreach (Cuenta cuenta in cuentas)
        {
            Console.WriteLine($"\t{config.Etiqueta(cuenta)} \t{cuenta.Nombre}");
        }
    }

    #endregion

    #region Agregar

    /// <summary>Crea una cuenta nueva (deudora o acreedora) y la agrega al grupo elegido.</summary>
    public static void AgregarCuenta(ConfigCuentas config)
    {
        int indice = ElegirGrupo(config);

        Console.WriteLine("\nIngrese el nombre de la nueva cuenta:");
        string nombre = SolicitarString();

        bool esPositiva = ElegirNaturaleza(config);

        string tipoGrupoBalance;
        if (config.PedirGrupoBalance)
        {
            tipoGrupoBalance = PedirGrupoBalance();
        }
        else
        {
            tipoGrupoBalance = "";
        }

        var (grupo, lista) = config.Catalogo[indice - 1];

        Cuenta nueva = Cuenta.Crear(nombre, esPositiva, tipoGrupoBalance);
        nueva.EsCreadoPorUsuario = true;
        lista.Add(nueva);

        MostrarMensajeExito($"Cuenta '{nombre}' agregada exitosamente a {grupo}.", true, false);

        string naturalezaTexto;
        if (esPositiva)
        {
            naturalezaTexto = config.EtiquetaPositiva;
        }
        else
        {
            naturalezaTexto = config.EtiquetaNegativa;
        }
        Console.WriteLine($"Naturaleza: {naturalezaTexto}");

        EsperarTecla();
    }

    /// <summary>Pregunta la naturaleza de una cuenta nueva. Devuelve true si es la positiva (deudora).</summary>
    private static bool ElegirNaturaleza(ConfigCuentas config)
    {
        Console.WriteLine("\n¿Qué tipo de cuenta es?");
        Console.WriteLine($"1. {config.EtiquetaPositiva}");
        Console.WriteLine($"2. {config.EtiquetaNegativa}");

        int opcion = SolicitarEnteroConLimites(1, 2);
        if (opcion == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>Pregunta el grupo del Balance General (solo lo usa Flujo de Efectivo).</summary>
    private static string PedirGrupoBalance()
    {
        Console.WriteLine("\n¿A qué grupo del Balance General pertenece esta cuenta?");
        Console.WriteLine("1. Activo");
        Console.WriteLine("2. Pasivo");
        Console.WriteLine("3. Capital Contable");

        int opcion = SolicitarEnteroConLimites(1, 3);

        switch (opcion)
        {
            case 1:
                return "Activo";
            case 2:
                return "Pasivo";
            default:
                return "Capital";
        }
    }

    #endregion

    #region Buscar

    /// <summary>Busca cuentas cuyo nombre contenga el texto indicado y las muestra en pantalla.</summary>
    public static void BuscarCuenta(ConfigCuentas config)
    {
        MostrarTituloSubrayado("Buscar Cuenta", true, true);
        Console.Write("Escriba el nombre (o parte) de la cuenta a buscar: ");
        string texto = SolicitarString().ToLower();

        int encontradas = 0;

        foreach (var (grupo, lista) in config.Catalogo)
        {
            foreach (Cuenta cuenta in lista)
            {
                if (cuenta.Nombre.ToLower().Contains(texto))
                {
                    Console.WriteLine($"  {config.Etiqueta(cuenta)} {cuenta.Nombre}   ({grupo})");
                    encontradas++;
                }
            }
        }

        if (encontradas == 0)
        {
            MostrarMensajeAdvertencia($"No se encontraron cuentas que contengan '{texto}'.", true, false);
        }
        else
        {
            MostrarMensajeExito($"Se encontraron {encontradas} cuenta(s).", true, false);
        }

        EsperarTecla();
    }

    #endregion

    #region Modificar

    /// <summary>Permite renombrar una de las cuentas creadas por el usuario.</summary>
    public static void ModificarCuenta(ConfigCuentas config)
    {
        MostrarTituloSubrayado("Modificar Cuenta", true, true);

        List<Cuenta> cuentasUsuario = ObtenerCuentasDelUsuario(config, out _);
        if (!HayCuentasDelUsuario(cuentasUsuario))
        {
            return;
        }

        MostrarListaNumerada(cuentasUsuario, config);
        Console.WriteLine($"\nSeleccione la cuenta a modificar (1-{cuentasUsuario.Count}):");
        int indice = SolicitarEnteroConLimites(1, cuentasUsuario.Count) - 1;
        Cuenta seleccionada = cuentasUsuario[indice];

        Console.WriteLine($"\nNombre actual: {seleccionada.Nombre}");
        Console.WriteLine("Ingrese el nuevo nombre de la cuenta:");
        seleccionada.Nombre = SolicitarString();

        MostrarMensajeExito($"Cuenta modificada. Nuevo nombre: {seleccionada.Nombre}", true, false);
        EsperarTecla();
    }

    #endregion

    #region Eliminar

    /// <summary>Permite eliminar una de las cuentas creadas por el usuario, con confirmación.</summary>
    public static void EliminarCuenta(ConfigCuentas config)
    {
        MostrarTituloSubrayado("Eliminar Cuenta", true, true);

        List<Cuenta> cuentasUsuario = ObtenerCuentasDelUsuario(config, out List<List<Cuenta>> listaDeCadaCuenta);
        if (!HayCuentasDelUsuario(cuentasUsuario))
        {
            return;
        }

        MostrarListaNumerada(cuentasUsuario, config);
        Console.WriteLine($"\nSeleccione la cuenta a eliminar (1-{cuentasUsuario.Count}):");
        int indice = SolicitarEnteroConLimites(1, cuentasUsuario.Count) - 1;
        Cuenta seleccionada = cuentasUsuario[indice];

        Console.WriteLine($"\n¿Esta seguro que desea eliminar la cuenta '{seleccionada.Nombre}'?");
        Console.WriteLine("1. Si, eliminar");
        Console.WriteLine("2. No, cancelar");

        int confirmacion = SolicitarEnteroConLimites(1, 2);
        if (confirmacion == 1)
        {
            List<Cuenta> listaOriginal = listaDeCadaCuenta[indice];
            listaOriginal.Remove(seleccionada);
            MostrarMensajeExito($"Cuenta '{seleccionada.Nombre}' eliminada exitosamente.", true, false);
        }
        else
        {
            MostrarMensajeCancelacion("Operacion cancelada.", true, false);
        }

        EsperarTecla();
    }

    #endregion

    #region Selección de grupo y de cuenta (usado también por los cálculos)

    /// <summary>Lista los grupos del catálogo y devuelve el número elegido (1 a N).</summary>
    public static int ElegirGrupo(ConfigCuentas config)
    {
        MostrarTituloSubrayado("Seleccione el grupo de cuenta", true, true);

        for (int i = 0; i < config.Catalogo.Count; i++)
        {
            string nombreGrupo = config.Catalogo[i].grupo;
            Console.WriteLine($"{i + 1}. {nombreGrupo}");
        }

        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(1, config.Catalogo.Count);
    }

    /// <summary>Igual que <see cref="ElegirGrupo"/> pero con opción 0 para finalizar. Devuelve 0 a N.</summary>
    public static int ElegirGrupoConSalida(ConfigCuentas config)
    {
        MostrarTituloSubrayado("Seleccione el grupo de cuenta", true, true);

        for (int i = 0; i < config.Catalogo.Count; i++)
        {
            string nombreGrupo = config.Catalogo[i].grupo;
            Console.WriteLine($"{i + 1}. {nombreGrupo}");
        }

        MostrarLineaDivisora(true, false);
        Console.WriteLine($"0. Finalizar y calcular {config.Nombre}");
        MostrarLineaDivisora(false, true);

        return SolicitarEnteroConLimites(0, config.Catalogo.Count);
    }

    /// <summary>Muestra las cuentas de un grupo numeradas y devuelve la que elija el usuario.</summary>
    public static Cuenta ElegirCuenta(string nombreGrupo, List<Cuenta> lista, ConfigCuentas config)
    {
        MostrarTituloSubrayado($"Cuentas de {nombreGrupo}", true, true);

        for (int i = 0; i < lista.Count; i++)
        {
            Cuenta cuenta = lista[i];
            Console.WriteLine($"{i + 1}. {config.Etiqueta(cuenta)} {cuenta.Nombre}");
        }

        MostrarLineaDivisora(true, true);
        Console.WriteLine($"Seleccione la cuenta (1-{lista.Count}):");

        int indice = SolicitarEnteroConLimites(1, lista.Count) - 1;
        return lista[indice];
    }

    /// <summary>Pregunta si se desea agregar otra cuenta al cálculo. Devuelve true si responde que sí.</summary>
    public static bool Continuar(string nombre)
    {
        Console.WriteLine("\n¿Desea agregar otra cuenta?");
        Console.WriteLine("1. Si, agregar otra cuenta");
        Console.WriteLine($"2. No, finalizar y calcular {nombre}");

        int opcion = SolicitarEnteroConLimites(1, 2);
        if (opcion == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region Apoyo

    /// <summary>
    /// Recolecta las cuentas creadas por el usuario. En <paramref name="listaDeCadaCuenta"/>
    /// devuelve, en el mismo orden, la lista original de cada cuenta (necesario para eliminarla).
    /// </summary>
    private static List<Cuenta> ObtenerCuentasDelUsuario(ConfigCuentas config, out List<List<Cuenta>> listaDeCadaCuenta)
    {
        List<Cuenta> cuentas = new List<Cuenta>();
        listaDeCadaCuenta = new List<List<Cuenta>>();

        foreach (var (grupo, lista) in config.Catalogo)
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
        if (cuentasUsuario.Count > 0)
        {
            return true;
        }

        MostrarMensajeAdvertencia("No has creado ninguna cuenta personalizada.", true, false);
        Console.WriteLine("\tUsa la opcion 'Agregar Cuenta' para crear tus propias cuentas.");
        EsperarTecla();
        return false;
    }

    /// <summary>Imprime las cuentas numeradas (1, 2, 3...) con su etiqueta de naturaleza.</summary>
    private static void MostrarListaNumerada(List<Cuenta> cuentas, ConfigCuentas config)
    {
        for (int i = 0; i < cuentas.Count; i++)
        {
            Cuenta cuenta = cuentas[i];
            Console.WriteLine($"{i + 1}. {config.Etiqueta(cuenta)} {cuenta.Nombre}");
        }
    }

    #endregion
}
