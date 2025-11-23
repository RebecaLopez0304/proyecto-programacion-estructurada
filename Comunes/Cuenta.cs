namespace ProyectoProgramacion.Comunes
{
    public class Cuenta// cuenta es un objeto que representa una cuenta contable
    {
        public string Nombre { get; set; }// get es para obtener el nombre de la cuenta y set es para asignar el nombre
        public int Valor { get; set; }

        // true = Deudora (se suma, positivo): Activos, Gastos, Costos
        // false = Acreedora (se resta, negativo): Pasivos, Capital, Ingresos, Cuentas complementarias
        public bool EsDeudora { get; set; }

        public bool EsCreadoPorUsuario { get; set; }

        // Clasificación en el Balance General: "Activo", "Pasivo", "Capital", o "" si no aplica
        public string TipoGrupoBalance { get; set; }// indica a qué grupo del balance general pertenece la cuenta

        // Objeto cuenta con sus características
        public Cuenta(string nombre, bool esDeudora = true, string tipoGrupoBalance = "")
        {
            Nombre = nombre;// asignamos el nombre de la cuenta
            Valor = 0;
            EsDeudora = esDeudora;
            EsCreadoPorUsuario = false; // Por defecto, las cuentas son del sistema
            TipoGrupoBalance = tipoGrupoBalance;
        }
    }
}
