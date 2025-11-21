namespace ProyectoProgramacion.Comunes
{
    public class Cuenta
    {
        public string Nombre { get; set; }
        public int Valor { get; set; }
        
        // true = Deudora (se suma, positivo): Activos, Gastos, Costos
        // false = Acreedora (se resta, negativo): Pasivos, Capital, Ingresos, Cuentas complementarias
        public bool EsDeudora { get; set; }

        public bool EsCreadoPorUsuario { get; set; }

        public Cuenta(string nombre, bool esDeudora = true)
        {
            Nombre = nombre;
            Valor = 0;
            EsDeudora = esDeudora;
            EsCreadoPorUsuario = false; // Por defecto, las cuentas son del sistema
        }

        // Método para obtener el valor con signo según si es deudora o acreedora
        public int ObtenerValorConSigno()
        {
            if (EsDeudora)
            {
                return Valor;  // Deudora: suma (positivo)
            }
            else
            {
                return -Valor; // Acreedora: resta (negativo)
            }
        }

        // Método para mostrar el signo visual
        public string ObtenerSignoVisual()
        {
            if (Valor == 0) return "";
            
            if (EsDeudora)
            {
                return "(+)";  // Deudora: positivo
            }
            else
            {
                return "(-)";  // Acreedora: negativo
            }
        }
    }
}
