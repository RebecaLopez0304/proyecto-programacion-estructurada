namespace ProyectoProgramacion.Comunes;

/// <summary>
/// Funciones de apoyo usadas en todo el programa: lectura validada de datos por consola,
/// mensajes con formato, elementos visuales, formato de moneda y guardado en archivo.
/// </summary>
public static class Utilidades
{
    #region Entrada de datos

    /// <summary>Pide un entero positivo (mayor que 0), repitiendo hasta que la entrada sea válida.</summary>
    public static int SolicitarEntero()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0)
                return valor;

            MostrarMensajeError("Debe ingresar un número entero positivo (mayor que 0).", false, true);
        }
    }

    /// <summary>Pide un entero no negativo (0 o mayor), repitiendo hasta que la entrada sea válida.</summary>
    public static int SolicitarEnteroNoNegativo()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int valor) && valor >= 0)
                return valor;

            MostrarMensajeError("Debe ingresar un número entero no negativo (0 o mayor).", false, true);
        }
    }

    /// <summary>Pide un entero dentro del rango [límiteInferior, límiteSuperior], ambos inclusive.</summary>
    public static int SolicitarEnteroConLimites(int limiteInferior, int limiteSuperior)
    {
        while (true)
        {
            Console.WriteLine($"Ingrese un numero entero entre {limiteInferior} y {limiteSuperior}: ");

            if (int.TryParse(Console.ReadLine(), out int valor) && valor >= limiteInferior && valor <= limiteSuperior)
                return valor;

            MostrarMensajeError($"Debe ingresar un número entero entre {limiteInferior} y {limiteSuperior}.", false, true);
        }
    }

    /// <summary>Pide un año válido (entre 1900 y 2100).</summary>
    public static int SolicitarAnio()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int anio) && anio >= 1900 && anio <= 2100)
                return anio;

            MostrarMensajeError("El año debe estar entre 1900 y 2100.", false, false);
            Console.Write("Intente de nuevo: ");
        }
    }

    /// <summary>Pide un texto de al menos 3 caracteres que no sea solo números.</summary>
    public static string SolicitarString()
    {
        while (true)
        {
            string entrada = (Console.ReadLine() ?? string.Empty).Trim();

            if (entrada.Length >= 3 && !entrada.All(char.IsDigit))
                return entrada;

            MostrarMensajeError("Debe ingresar un texto válido de al menos 3 caracteres que no sea solo números.", false, true);
        }
    }

    /// <summary>Pide el número de un mes (1-12) y devuelve su nombre (ej. 3 -> "Marzo").</summary>
    public static string MesNumeroALetra()
    {
        string[] meses =
        {
            "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
        };

        int mes = SolicitarEnteroConLimites(1, 12);
        return meses[mes - 1];
    }

    #endregion

    #region Mensajes

    /// <summary>Imprime un mensaje con una etiqueta entre corchetes y saltos de línea opcionales.</summary>
    private static void Mensaje(string etiqueta, string texto, bool saltoInicio, bool saltoFinal)
    {
        if (saltoInicio) Console.WriteLine();
        Console.WriteLine($"[{etiqueta}] - {texto}");
        if (saltoFinal) Console.WriteLine();
    }

    public static void MostrarMensajeError(string mensaje, bool saltoInicio = false, bool saltoFinal = false)
        => Mensaje("ERROR", mensaje, saltoInicio, saltoFinal);

    public static void MostrarMensajeExito(string mensaje, bool saltoInicio = false, bool saltoFinal = false)
        => Mensaje("OPERACION EXITOSA", mensaje, saltoInicio, saltoFinal);

    public static void MostrarMensajeAdvertencia(string mensaje, bool saltoInicio = false, bool saltoFinal = false)
        => Mensaje("ADVERTENCIA", mensaje, saltoInicio, saltoFinal);

    public static void MostrarMensajeCancelacion(string mensaje, bool saltoInicio = false, bool saltoFinal = false)
        => Mensaje("OPERACION CANCELADA", mensaje, saltoInicio, saltoFinal);

    #endregion

    #region Elementos visuales

    /// <summary>Imprime una línea divisora simple, con saltos de línea opcionales.</summary>
    public static void MostrarLineaDivisora(bool saltoInicio = false, bool saltoFinal = false)
    {
        if (saltoInicio) Console.WriteLine();
        Console.WriteLine(new string('-', 62));
        if (saltoFinal) Console.WriteLine();
    }

    /// <summary>Imprime un texto centrado entre dos líneas de "=", a modo de encabezado.</summary>
    public static void MostrarLineaDivisoraConTexto(string texto, bool saltoInicio = false, bool saltoFinal = false)
    {
        if (saltoInicio) Console.WriteLine();
        Console.WriteLine(new string('=', 62));
        Console.WriteLine($"                       {texto}");
        Console.WriteLine(new string('=', 62));
        if (saltoFinal) Console.WriteLine();
    }

    /// <summary>Imprime un título con una línea de guiones debajo.</summary>
    public static void MostrarTituloSubrayado(string titulo, bool saltoInicio = false, bool saltoFinal = false)
    {
        if (saltoInicio) Console.WriteLine();
        Console.WriteLine(titulo);
        Console.WriteLine(new string('-', titulo.Length + 1));
        if (saltoFinal) Console.WriteLine();
    }

    /// <summary>Muestra la opción "Volver al menu anterior" precedida de una línea divisora.</summary>
    public static void VolverAtras()
    {
        MostrarLineaDivisora(true, false);
        Console.WriteLine("0. Volver al menu anterior");
    }

    /// <summary>Pausa la ejecución hasta que el usuario presione una tecla.</summary>
    public static void EsperarTecla()
    {
        MostrarLineaDivisora(true, true);
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    #endregion

    #region Formato de moneda

    /// <summary>Formatea un número como moneda nicaragüense. Ej. 1234 -> "NIO C$ 1,234.00".</summary>
    public static string FormatearMoneda(int valor) => $"NIO C$ {valor:N2}";

    /// <summary>Igual que <see cref="FormatearMoneda"/> pero sin el prefijo "NIO" (útil para tablas).</summary>
    public static string FormatearMonedaSinPrefijo(int valor) => $"C$ {valor:N2}";

    #endregion

    #region Persistencia en archivo

    /// <summary>Pregunta al usuario si desea guardar el resultado. Devuelve true si responde que sí.</summary>
    public static bool PreguntarSiGuardarResultado()
    {
        MostrarLineaDivisora(true, true);
        Console.WriteLine("¿Desea guardar este resultado en un archivo de texto?");
        Console.WriteLine("1. Si, guardar resultado");
        Console.WriteLine("2. No, solo visualizar");
        MostrarLineaDivisora(true, true);

        return SolicitarEnteroConLimites(1, 2) == 1;
    }

    /// <summary>
    /// Guarda el texto en "Resultados/&lt;nombre&gt;.txt" (sobrescribe el resultado anterior)
    /// y devuelve la ruta del archivo.
    /// </summary>
    public static string GuardarResultadoEnArchivo(string nombreEstadoFinanciero, string contenido)
    {
        Directory.CreateDirectory("Resultados");
        string ruta = Path.Combine("Resultados", $"{nombreEstadoFinanciero}.txt");
        File.WriteAllText(ruta, contenido);
        return ruta;
    }

    #endregion
}
