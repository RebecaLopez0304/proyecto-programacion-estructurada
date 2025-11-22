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

        // Clasificación en el Balance General: "Activo", "Pasivo", "Capital", o "" si no aplica
        public string TipoGrupoBalance { get; set; }

        // Objeto cuenta con sus características
        public Cuenta(string nombre, bool esDeudora = true, string tipoGrupoBalance = "")
        {
            Nombre = nombre;
            Valor = 0;
            EsDeudora = esDeudora;
            EsCreadoPorUsuario = false; // Por defecto, las cuentas son del sistema
            TipoGrupoBalance = tipoGrupoBalance;
        }
    }
}
