namespace ProyectoProgramacion.Comunes;

/// <summary>
/// Configuración que cada estado financiero entrega a las acciones compartidas. Reúne
/// lo único que cambia entre Balance General, Estado de Resultados y Flujo de Efectivo:
/// el nombre, su catálogo de cuentas y cómo se llama cada naturaleza.
/// </summary>
public class ConfigCuentas
{
    #region Propiedades

    /// <summary>Nombre del estado financiero, ej. "Balance General".</summary>
    public string Nombre { get; }

    /// <summary>Listas de cuentas con el nombre de su grupo.</summary>
    public List<(string grupo, List<Cuenta> lista)> Catalogo { get; }

    /// <summary>Texto para una cuenta deudora (ej. "Deudora", "Egreso", "Entrada").</summary>
    public string EtiquetaPositiva { get; }

    /// <summary>Texto para una cuenta acreedora (ej. "Acreedora", "Ingreso", "Salida").</summary>
    public string EtiquetaNegativa { get; }

    /// <summary>True solo en Flujo de Efectivo: al agregar pide el grupo del Balance General.</summary>
    public bool PedirGrupoBalance { get; }

    #endregion

    #region Constructor

    public ConfigCuentas(
        string nombre,
        List<(string grupo, List<Cuenta> lista)> catalogo,
        string etiquetaPositiva,
        string etiquetaNegativa,
        bool pedirGrupoBalance = false)
    {
        Nombre = nombre;
        Catalogo = catalogo;
        EtiquetaPositiva = etiquetaPositiva;
        EtiquetaNegativa = etiquetaNegativa;
        PedirGrupoBalance = pedirGrupoBalance;
    }

    #endregion

    #region Métodos

    /// <summary>Etiqueta de naturaleza para mostrar antes del nombre, ej. "[Deudora  ]".</summary>
    public string Etiqueta(Cuenta cuenta)
    {
        // Calculamos el ancho mayor para que las etiquetas queden alineadas.
        int ancho = Math.Max(EtiquetaPositiva.Length, EtiquetaNegativa.Length);

        string texto;
        if (cuenta.EsDeudora)
        {
            texto = EtiquetaPositiva;
        }
        else
        {
            texto = EtiquetaNegativa;
        }

        return $"[{texto.PadRight(ancho)}]";
    }

    #endregion
}
