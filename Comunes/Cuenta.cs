namespace ProyectoProgramacion.Comunes;

/// <summary>
/// Representa una cuenta contable. Es una clase <b>abstracta</b>: define lo común a
/// toda cuenta pero no se puede instanciar directamente. De ella heredan
/// <see cref="CuentaDeudora"/> y <see cref="CuentaAcreedora"/>, que dan su propia
/// versión de <see cref="EsDeudora"/> y <see cref="ValorConSigno"/> (polimorfismo).
/// </summary>
public abstract class Cuenta
{
    #region Propiedades

    /// <summary>Nombre de la cuenta (ej. "Caja General").</summary>
    public string Nombre { get; set; }

    /// <summary>True si el usuario creó la cuenta en tiempo de ejecución; false si es del sistema.</summary>
    public bool EsCreadoPorUsuario { get; set; }

    /// <summary>Grupo del Balance General ("Activo", "Pasivo", "Capital"). Solo lo usa Flujo de Efectivo.</summary>
    public string TipoGrupoBalance { get; set; }

    #endregion

    #region Constructor

    /// <summary>Constructor base reutilizado por las clases hijas mediante <c>: base(...)</c>.</summary>
    protected Cuenta(string nombre, string tipoGrupoBalance = "")
    {
        Nombre = nombre;
        EsCreadoPorUsuario = false;
        TipoGrupoBalance = tipoGrupoBalance;
    }

    #endregion

    #region Miembros polimórficos

    /// <summary>Naturaleza de la cuenta: true = deudora, false = acreedora.</summary>
    public abstract bool EsDeudora { get; }

    /// <summary>Devuelve el valor con el signo que la cuenta aporta a un cálculo.</summary>
    public abstract int ValorConSigno(int valor);

    #endregion

    #region Fábrica

    /// <summary>Crea la cuenta del tipo correcto (deudora o acreedora) según la naturaleza indicada.</summary>
    public static Cuenta Crear(string nombre, bool esDeudora, string tipoGrupoBalance = "")
    {
        if (esDeudora)
        {
            return new CuentaDeudora(nombre, tipoGrupoBalance);
        }
        else
        {
            return new CuentaAcreedora(nombre, tipoGrupoBalance);
        }
    }

    #endregion
}

/// <summary>Cuenta de naturaleza deudora (activos, gastos, costos): suma en positivo.</summary>
public class CuentaDeudora : Cuenta
{
    public CuentaDeudora(string nombre, string tipoGrupoBalance = "") : base(nombre, tipoGrupoBalance)
    {
    }

    public override bool EsDeudora
    {
        get { return true; }
    }

    public override int ValorConSigno(int valor)
    {
        // Una cuenta deudora aporta su valor en positivo.
        return valor;
    }
}

/// <summary>Cuenta de naturaleza acreedora (pasivos, capital, ingresos): resta en negativo.</summary>
public class CuentaAcreedora : Cuenta
{
    public CuentaAcreedora(string nombre, string tipoGrupoBalance = "") : base(nombre, tipoGrupoBalance)
    {
    }

    public override bool EsDeudora
    {
        get { return false; }
    }

    public override int ValorConSigno(int valor)
    {
        // Una cuenta acreedora aporta su valor en negativo.
        return -valor;
    }
}
