using System.Text;
using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.EstadoResultados;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones;

/// <summary>
/// Pide al usuario cuentas con sus valores y calcula el Estado de Resultados hasta
/// obtener la utilidad o pérdida neta del período.
/// </summary>
public static class AccionCalcularEstadoResultados
{
    /// <summary>Una cuenta elegida por el usuario con su valor y su categoría (1-5).</summary>
    private record CuentaValor(Cuenta Cuenta, int Valor, int Categoria);

    /// <summary>Cómo afecta una categoría al resultado, según la naturaleza de cada cuenta.</summary>
    private enum Modo { Ingreso, Costo, Gasto }

    #region Flujo principal

    public static void Ejecutar()
    {
        MostrarLineaDivisoraConTexto("Calcular Estado de Resultados", true, true);

        Console.Write("Ingrese el nombre de la empresa: ");
        string nombreEmpresa = SolicitarString();

        Console.Write("Ingrese el mes del período (ej. Diciembre): ");
        string mes = SolicitarString();

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
        var seleccionadas = new List<CuentaValor>();
        var catalogo = ObtenerCatalogo();
        bool continuar = true;

        while (continuar)
        {
            int categoria = MostrarMenuCategoriasConSalida(); // 0 = finalizar, 1-5 = categoría
            if (categoria == 0) break;

            var (nombreGrupo, listaCuentas) = catalogo[categoria - 1];

            MostrarTituloSubrayado($"Cuentas de {nombreGrupo}", true, true);
            for (int i = 0; i < listaCuentas.Count; i++)
            {
                string naturaleza = listaCuentas[i].EsDeudora ? "[Egreso  ]" : "[Ingreso ]";
                Console.WriteLine($"{i + 1}. {naturaleza} {listaCuentas[i].Nombre}");
            }
            MostrarLineaDivisora(true, true);

            Console.WriteLine($"Seleccione la cuenta (1-{listaCuentas.Count}):");
            Cuenta cuenta = listaCuentas[SolicitarEnteroConLimites(1, listaCuentas.Count) - 1];

            Console.Write($"Ingrese el valor para '{cuenta.Nombre}': ");
            int valor = SolicitarEntero();

            seleccionadas.Add(new CuentaValor(cuenta, valor, categoria));
            MostrarMensajeExito($"Cuenta '{cuenta.Nombre}' agregada con valor {FormatearMoneda(valor)}", true, false);

            continuar = MostrarMenuContinuar() == 1;
        }

        return seleccionadas;
    }

    #endregion

    #region Reporte

    /// <summary>Construye el reporte completo aplicando las fórmulas del Estado de Resultados.</summary>
    private static void GenerarReporte(string nombreEmpresa, string mes, int anio, List<CuentaValor> seleccionadas)
    {
        MostrarLineaDivisoraConTexto("Resultado del Estado de Resultados", true, true);

        var reporte = new StringBuilder();
        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine($"                    {nombreEmpresa.ToUpper()}");
        reporte.AppendLine("                  ESTADO DE RESULTADOS");
        reporte.AppendLine($"            Del 1 al 31 de {mes} de {anio}");
        reporte.AppendLine("          (Expresado en Córdobas - NIO C$)");
        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine();

        int ventas = ImprimirSeccion("VENTAS", seleccionadas, 1, Modo.Ingreso, reporte);
        Linea($"VENTAS NETAS: {FormatearMoneda(ventas)}", reporte);
        reporte.AppendLine();

        int costo = ImprimirSeccion("COSTO DE VENTAS", seleccionadas, 2, Modo.Costo, reporte);
        Linea($"TOTAL COSTO DE VENTAS: {FormatearMoneda(costo)}", reporte);
        reporte.AppendLine();

        int utilidadBruta = ventas - costo;
        Linea($"UTILIDAD BRUTA: {FormatearMoneda(utilidadBruta)}", reporte);
        reporte.AppendLine();

        int gastosOperacion = ImprimirSeccion("GASTOS DE OPERACIÓN", seleccionadas, 3, Modo.Gasto, reporte);
        Linea($"TOTAL GASTOS DE OPERACIÓN: {FormatearMoneda(gastosOperacion)}", reporte);
        reporte.AppendLine();

        int gastosAdministracion = ImprimirSeccion("GASTOS DE ADMINISTRACIÓN", seleccionadas, 4, Modo.Gasto, reporte);
        Linea($"TOTAL GASTOS DE ADMINISTRACIÓN: {FormatearMoneda(gastosAdministracion)}", reporte);
        reporte.AppendLine();

        int utilidadOperacion = utilidadBruta - (gastosOperacion + gastosAdministracion);
        Linea($"UTILIDAD DE OPERACIÓN: {FormatearMoneda(utilidadOperacion)}", reporte);
        reporte.AppendLine();

        int otros = ImprimirSeccion("OTROS RESULTADOS FINANCIEROS", seleccionadas, 5, Modo.Ingreso, reporte);
        Linea($"TOTAL OTROS RESULTADOS: {FormatearMoneda(otros)}", reporte);
        reporte.AppendLine();

        MostrarResultadoFinal(utilidadOperacion + otros, reporte);

        if (PreguntarSiGuardarResultado())
        {
            string ruta = GuardarResultadoEnArchivo("estado-resultados", reporte.ToString());
            MostrarMensajeExito($"Resultado guardado en: {ruta}", true, false);
        }
    }

    /// <summary>
    /// Imprime una sección y devuelve su total. El signo de cada cuenta depende del modo:
    /// Ingreso (ingresos suman), Costo (costos suman) o Gasto (siempre suman).
    /// </summary>
    private static int ImprimirSeccion(string titulo, List<CuentaValor> seleccionadas, int categoria, Modo modo, StringBuilder reporte)
    {
        reporte.AppendLine(titulo);
        reporte.AppendLine(new string('-', 60));
        MostrarTituloSubrayado(titulo, true, true);

        int total = 0;
        foreach (CuentaValor item in seleccionadas.Where(c => c.Categoria == categoria))
        {
            (int valorConSigno, string signo) = modo switch
            {
                // En ingresos, una cuenta acreedora (ingreso) suma y una deudora (devolución) resta.
                Modo.Ingreso => (-item.Cuenta.ValorConSigno(item.Valor), item.Cuenta.EsDeudora ? "(-)" : "(+)"),
                // En costos, una cuenta deudora (costo) suma y una acreedora (descuento) resta.
                Modo.Costo => (item.Cuenta.ValorConSigno(item.Valor), item.Cuenta.EsDeudora ? "(+)" : "(-)"),
                // Los gastos siempre suman.
                _ => (item.Valor, "(+)"),
            };

            total += valorConSigno;
            Linea($"  {signo} {item.Cuenta.Nombre}: {FormatearMoneda(item.Valor)}", reporte);
        }

        return total;
    }

    /// <summary>Muestra si el período cerró con utilidad o con pérdida.</summary>
    private static void MostrarResultadoFinal(int resultado, StringBuilder reporte)
    {
        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine("                    RESULTADO FINAL");
        reporte.AppendLine(new string('=', 62));
        MostrarLineaDivisoraConTexto("Resultado Final", true, true);

        if (resultado >= 0)
        {
            Linea($"UTILIDAD NETA: {FormatearMoneda(resultado)}", reporte);
            MostrarMensajeExito("La empresa obtuvo UTILIDAD en el período", true, false);
        }
        else
        {
            Linea($"PÉRDIDA NETA: {FormatearMoneda(Math.Abs(resultado))}", reporte);
            MostrarMensajeError("La empresa tuvo PÉRDIDA en el período", true, false);
        }

        reporte.AppendLine();
        reporte.AppendLine(new string('=', 62));
    }

    /// <summary>Escribe una línea tanto en pantalla como en el reporte de texto.</summary>
    private static void Linea(string texto, StringBuilder reporte)
    {
        Console.WriteLine(texto);
        reporte.AppendLine(texto);
    }

    #endregion
}
