public class Cuenta
{
    public string Nombre { get; set; }
    public decimal Valor { get; set; }

    public Cuenta(string nombre)
    {
        Nombre = nombre;
        Valor = 0;
    }
}
