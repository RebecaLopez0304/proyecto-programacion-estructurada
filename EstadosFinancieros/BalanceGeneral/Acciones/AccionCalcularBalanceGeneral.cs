using System.Text;
using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.BalanceGeneral;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones;

/// <summary>
/// Pide al usuario cuentas con sus valores, calcula el Balance General y comprueba la
/// ecuación contable (Activos = Pasivos + Capital).
/// </summary>
public static class AccionCalcularBalanceGeneral
{
    #region Tipo de apoyo

    /// <summary>Una cuenta elegida por el usuario con su valor y la sección a la que pertenece.</summary>
    private class CuentaValor
    {
        public Cuenta Cuenta { get; }
        public int Valor { get; }
        public char Seccion { get; } // 'A' = Activo, 'P' = Pasivo, 'C' = Capital

        public CuentaValor(Cuenta cuenta, int valor, char seccion)
        {
            Cuenta = cuenta;
            Valor = valor;
            Seccion = seccion;
        }
    }

    #endregion

    #region Flujo principal

    public static void Ejecutar()
    {
        MostrarLineaDivisoraConTexto("Calculo de Balance General", true, true);

        Console.Write("Ingrese el nombre de la empresa: ");
        string nombreEmpresa = SolicitarString();

        Console.Write("Ingrese el mes del período: ");
        string mes = MesNumeroALetra();

        Console.Write("Ingrese el año del período (ej. 2024): ");
        int anio = SolicitarAnio();

        List<CuentaValor> seleccionadas = SeleccionarCuentas();

        if (seleccionadas.Count == 0)
        {
            MostrarMensajeAdvertencia("No se agregaron cuentas al calculo.", true, false);
            EsperarTecla();
            return;
        }

        GenerarReporte(nombreEmpresa, mes, anio, seleccionadas);
        EsperarTecla();
    }

    #endregion

    #region Selección de cuentas

    /// <summary>Permite al usuario elegir varias cuentas (con su valor) hasta que decide finalizar.</summary>
    private static List<CuentaValor> SeleccionarCuentas()
    {
        List<CuentaValor> seleccionadas = new List<CuentaValor>();
        ConfigCuentas config = Config;
        bool continuar = true;

        while (continuar)
        {
            int categoria = AccionesCuentas.ElegirGrupoConSalida(config); // 0 = finalizar, 1-8 = categoría
            if (categoria == 0)
            {
                break;
            }

            var (nombreGrupo, listaCuentas) = config.Catalogo[categoria - 1];

            // Categorías 1-4 = Activo, 5-6 = Pasivo, 7-8 = Capital
            char seccion;
            if (categoria <= 4)
            {
                seccion = 'A';
            }
            else if (categoria <= 6)
            {
                seccion = 'P';
            }
            else
            {
                seccion = 'C';
            }

            Cuenta cuenta = AccionesCuentas.ElegirCuenta(nombreGrupo, listaCuentas, config);

            Console.Write($"Ingrese el valor para '{cuenta.Nombre}': ");
            int valor = SolicitarEntero();

            seleccionadas.Add(new CuentaValor(cuenta, valor, seccion));
            MostrarMensajeExito($"Cuenta '{cuenta.Nombre}' agregada con valor {FormatearMoneda(valor)}", true, false);

            continuar = AccionesCuentas.Continuar(config.Nombre);
        }

        return seleccionadas;
    }

    #endregion

    #region Reporte y ecuación contable

    /// <summary>Imprime el reporte en pantalla, lo guarda en texto y comprueba la ecuación contable.</summary>
    private static void GenerarReporte(string nombreEmpresa, string mes, int anio, List<CuentaValor> seleccionadas)
    {
        MostrarLineaDivisoraConTexto("Resultado del Balance General", true, true);

        StringBuilder reporte = new StringBuilder();
        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine($"                    {nombreEmpresa.ToUpper()}");
        reporte.AppendLine("                    BALANCE GENERAL");
        reporte.AppendLine($"                Al {mes} de {anio}");
        reporte.AppendLine("          (Expresado en Córdobas - NIO C$)");
        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine();

        int totalActivos = ImprimirSeccion("ACTIVOS", seleccionadas, 'A', reporte);
        int totalPasivos = ImprimirSeccion("PASIVOS", seleccionadas, 'P', reporte);
        int totalCapital = ImprimirSeccion("CAPITAL CONTABLE", seleccionadas, 'C', reporte);

        ComprobarEcuacion(totalActivos, totalPasivos + totalCapital, reporte);

        if (PreguntarSiGuardarResultado())
        {
            string ruta = GuardarResultadoEnArchivo("balance-general", reporte.ToString());
            MostrarMensajeExito($"Resultado guardado en: {ruta}", true, false);
        }
    }

    /// <summary>
    /// Imprime las cuentas de una sección (en pantalla y en el reporte) y devuelve su total.
    /// El signo de cada cuenta lo decide ella misma con <see cref="Cuenta.ValorConSigno"/> (polimorfismo).
    /// </summary>
    private static int ImprimirSeccion(string titulo, List<CuentaValor> seleccionadas, char seccion, StringBuilder reporte)
    {
        reporte.AppendLine(titulo);
        reporte.AppendLine(new string('-', 60));
        MostrarTituloSubrayado(titulo, true, true);

        int total = 0;
        // Tomamos solo las cuentas que pertenecen a esta sección.
        foreach (CuentaValor item in seleccionadas.Where(c => c.Seccion == seccion))
        {
            total = total + item.Cuenta.ValorConSigno(item.Valor);

            string linea = $"  {item.Cuenta.Nombre}: {FormatearMoneda(item.Valor)}";
            Console.WriteLine(linea);
            reporte.AppendLine(linea);
        }

        string totalLinea = $"TOTAL {titulo}: {FormatearMoneda(total)}";
        Console.WriteLine(totalLinea);
        reporte.AppendLine(totalLinea);
        reporte.AppendLine();

        return total;
    }

    /// <summary>Compara Activos contra Pasivos + Capital e informa si el balance cuadra.</summary>
    private static void ComprobarEcuacion(int totalActivos, int totalPasivoMasCapital, StringBuilder reporte)
    {
        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine("                    ECUACION CONTABLE");
        reporte.AppendLine(new string('=', 62));
        MostrarLineaDivisoraConTexto("Ecuacion Contable", true, true);

        string activosLinea = $"Activos           : {FormatearMoneda(totalActivos)}";
        string pasivoCapitalLinea = $"Pasivos + Capital : {FormatearMoneda(totalPasivoMasCapital)}";
        Console.WriteLine(activosLinea);
        Console.WriteLine(pasivoCapitalLinea);
        reporte.AppendLine(activosLinea);
        reporte.AppendLine(pasivoCapitalLinea);

        if (totalActivos == totalPasivoMasCapital)
        {
            MostrarMensajeExito("BALANCE GENERAL CUADRADO", true, false);
            Console.WriteLine("  La ecuacion contable esta balanceada: Activos = Pasivos + Capital");
            reporte.AppendLine();
            reporte.AppendLine("[RESULTADO] BALANCE GENERAL CUADRADO");
        }
        else
        {
            int diferencia = totalActivos - totalPasivoMasCapital;
            MostrarMensajeError("BALANCE GENERAL DESCUADRADO", true, false);
            Console.WriteLine($"  Diferencia: {FormatearMoneda(Math.Abs(diferencia))}");
            reporte.AppendLine();
            reporte.AppendLine("[ADVERTENCIA] BALANCE GENERAL DESCUADRADO");
            reporte.AppendLine($"Diferencia: {FormatearMoneda(Math.Abs(diferencia))}");
        }

        reporte.AppendLine();
        reporte.AppendLine(new string('=', 62));
    }

    #endregion
}
