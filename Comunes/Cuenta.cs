namespace ProyectoProgramacion.Comunes
{
    public class Cuenta
    {
        public string Nombre { get; set; }
        public int Valor { get; set; }

        public Cuenta(string nombre)
        {
            Nombre = nombre;
            Valor = 0;
        }
    }
}
