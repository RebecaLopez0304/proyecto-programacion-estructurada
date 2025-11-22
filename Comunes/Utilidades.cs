
namespace ProyectoProgramacion.Comunes
{
    /*
    ===========================
        Utilidades
    ===========================
    */
    public static class Utilidades
    {
        public static double SolicitarDouble(double entradaUsuario)
        {
            while (true)
            {
                try
                {
                    entradaUsuario = double.Parse(Console.ReadLine() ?? string.Empty);
                    if (entradaUsuario > 0)
                    {
                        return entradaUsuario;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR] Debe ingresar un número entero positivo. Intente de nuevo\n\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("[ERROR] Entrada no válida. Por favor, intente de nuevo.\n\n");
                }
            }
        }

        // MARK: Solicitar una cadena con validaciones
        public static string SolicitarString()
        {
            while (true)
            {
                try
                {
                    string entrada = Console.ReadLine() ?? string.Empty;
                    string entradaUsuario = entrada.Trim();

                    if (entradaUsuario.Length > 3)
                    {
                        return entradaUsuario;
                    }
                    else
                    {
                        Console.WriteLine("[Error] Tiene que ingresar mas de 3 caracteres");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("[ERROR] favor ingresar un valor valido");
                }
            }
        }

        // MARK: Solicitar un número entero positivo
        public static int SolicitarEntero()
        {
            while (true)
            {
                try
                {
                    int entradaUsuario = int.Parse(Console.ReadLine() ?? string.Empty);
                    if (entradaUsuario > 0)
                    {
                        return entradaUsuario;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR] Debe ingresar un numero entero positivo. Intente de nuevo\n\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("[ERROR] Entrada no valida. Por favor, intente de nuevo.\n\n");
                }
            }
        }

        // MARK: Solicitar un número entero no negativo
        public static int SolicitarEnteroNoNegativo()
        {
            while (true)
            {
                try
                {
                    int entradaUsuario = int.Parse(Console.ReadLine() ?? string.Empty);
                    if (entradaUsuario >= 0)
                    {
                        return entradaUsuario;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR] Debe ingresar un numero entero no negativo (0 o mayor). Intente de nuevo\n\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("[ERROR] Entrada no valida. Por favor, intente de nuevo.\n\n");
                }
            }
        }

        // MARK: Solicitar un número entero dentro de unos límites específicos
        // limiteInferior: valor mínimo aceptable (inclusive)
        // limiteSuperior: valor máximo aceptable (inclusive)
        public static int SolicitarEnteroConLimites(int limiteInferior, int limiteSuperior)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Ingrese un numero entero entre {limiteInferior} y {limiteSuperior}: ");
                    int entradaUsuario = int.Parse(Console.ReadLine() ?? string.Empty);
                    if (entradaUsuario >= limiteInferior && entradaUsuario <= limiteSuperior)
                    {
                        return entradaUsuario;
                    }
                    else
                    {
                        Console.WriteLine($"[ERROR] Debe ingresar un numero entero entre {limiteInferior} y {limiteSuperior}. Intente de nuevo\n\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("[ERROR] Entrada no valida. Por favor, intente de nuevo.\n\n");
                }
            }
        }




        // MARK: UTILIDADES VISUALES - inicio
        public static void MostrarLineaDivisora(bool SaltoDeLineaInicio = false, bool SaltoDeLineaFinal = false)
        {
            if (SaltoDeLineaInicio)
            {
                Console.WriteLine();
            }

            Console.WriteLine("--------------------------------------------------------------");

            if (SaltoDeLineaFinal)
            {
                Console.WriteLine();
            }
        }

        public static void MostrarLineaDivisoraConTexto(string texto, bool SaltoDeLineaInicio = false, bool SaltoDeLineaFinal = false)
        {
            if (SaltoDeLineaInicio)
            {
                Console.WriteLine();
            }

            Console.WriteLine($"==============================================================");
            Console.WriteLine($"                       {texto}");
            Console.WriteLine($"==============================================================");

            if (SaltoDeLineaFinal)
            {
                Console.WriteLine();
            }
        }

        public static void MostrarTituloSubrayado(string titulo, bool SaltoDeLineaInicio = false, bool SaltoDeLineaFinal = false)
        {
            if (SaltoDeLineaInicio)
            {
                Console.WriteLine();
            }

            Console.WriteLine($"{titulo}");
            Console.WriteLine(new string('-', titulo.Length + 1));

            if (SaltoDeLineaFinal)
            {
                Console.WriteLine();
            }
        }

        public static void EsperarTecla()
        {
            MostrarLineaDivisora(true, true);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void VolverAtras()
        {
            MostrarLineaDivisora(true, false);
            Console.WriteLine("0. Volver al menu anterior");
            // EsperarTecla();
        }

        public static void MostrarMensajeError(string mensaje, bool SaltoDeLineaInicio = false, bool SaltoDeLineaFinal = false)
        {
            if (SaltoDeLineaInicio)
            {
                Console.WriteLine();
            }

            Console.WriteLine($"[ERROR] - {mensaje}");

            if (SaltoDeLineaFinal)
            {
                Console.WriteLine();
            }
        }

        public static void MostrarMensajeExito(string mensaje, bool SaltoDeLineaInicio = false, bool SaltoDeLineaFinal = false)
        {
            if (SaltoDeLineaInicio)
            {
                Console.WriteLine();
            }

            Console.WriteLine($"[OPERACION EXITOSA] - {mensaje}");

            if (SaltoDeLineaFinal)
            {
                Console.WriteLine();
            }
        }

        public static void MostrarMensajeAdvertencia(string mensaje, bool SaltoDeLineaInicio = false, bool SaltoDeLineaFinal = false)
        {
            if (SaltoDeLineaInicio)
            {
                Console.WriteLine();
            }

            Console.WriteLine($"[ADVERTENCIA] - {mensaje}");

            if (SaltoDeLineaFinal)
            {
                Console.WriteLine();
            }
        }

        public static void MostrarMensajeCancelacion(string mensaje, bool SaltoDeLineaInicio = false, bool SaltoDeLineaFinal = false)
        {
            if (SaltoDeLineaInicio)
            {
                Console.WriteLine();
            }

            Console.WriteLine($"[OPERACION CANCELADA] - {mensaje}");

            if (SaltoDeLineaFinal)
            {
                Console.WriteLine();
            }
        }

        // MARK: UTILIDADES VISUALES - fin

        /*
        ===========================
            Funciones de Guardado de Resultados
        ===========================
        */

        // Guarda el contenido en un archivo de texto con nombre autoincremental (estado-financiero-<numero autoincremental>.txt)
        // nombreEstadoFinanciero: "balance-general", "estado-resultados", "flujo-efectivo"
        // contenido: todo el texto que se guardará en el archivo
        // retorna: ruta completa del archivo guardado
        // MARK: Guardar en archivo
        public static string GuardarResultadoEnArchivo(string nombreEstadoFinanciero, string contenido)
        {
            try
            {
                // Obtiene la ruta de la carpeta "Resultados" en el directorio actual - <ruta_actual>/Resultados
                // Path.Combine combina el resultado que nos devuelve GetCurrentDirectory + el nombre de la carpeta que queremos crear/verificar, en este caso es resultados

                // GetCurrentDirectory devuelve esto -> F:\REBECA\proyecto-programacion
                // y Path.Combine combina el resultado y nos devuelve esto -> F:\REBECA\proyecto-programacion\Resultados
                string carpetaResultados = Path.Combine(Directory.GetCurrentDirectory(), "Resultados");

                // Si la carpeta "Resultados" no existe, la crea
                // si existe no hace nada
                if (!Directory.Exists(carpetaResultados))
                {
                    Directory.CreateDirectory(carpetaResultados);
                }

                // Obtiene el siguiente número disponible para el archivo (autoincremental)
                int numero = ObtenerSiguienteNumeroArchivo(carpetaResultados, nombreEstadoFinanciero);

                // Construye el nombre del archivo con el formato: <nombreEstadoFinanciero>-<numero>.txt
                string nombreArchivo = $"{nombreEstadoFinanciero}-{numero}.txt";

                // Une la carpeta y el nombre del archivo para obtener la ruta completa
                string rutaCompleta = Path.Combine(carpetaResultados, nombreArchivo);

                // Escribe el contenido en el archivo especificado
                File.WriteAllText(rutaCompleta, contenido);

                // Retorna la ruta completa del archivo guardado
                return rutaCompleta;
            }
            catch (Exception ex)
            {
                // Si ocurre un error, muestra un mensaje y retorna string.Empty
                MostrarMensajeError($"Error al guardar el archivo: {ex.Message}", true, true);
                return string.Empty;
            }
        }

        // Obtiene el siguiente número disponible para el archivo
        // Busca archivos existentes y retorna el número más alto + 1
        // MARK: Guardar archivo - obtener siguiente número
        private static int ObtenerSiguienteNumeroArchivo(string carpeta, string nombreBase)
        {
            string patron = $"{nombreBase}-*.txt";
            string[] archivosExistentes = Directory.GetFiles(carpeta, patron);

            if (archivosExistentes.Length == 0)
            {
                return 1;
            }

            int maxNumero = 0;
            // Recorre todos los archivos que coinciden con el patrón (por ejemplo: "balance-general-*.txt")
            foreach (string archivo in archivosExistentes)
            {
                // Obtiene el nombre del archivo sin la extensión (por ejemplo: "balance-general-3")
                string nombreArchivo = Path.GetFileNameWithoutExtension(archivo);

                // Divide el nombre del archivo usando el guion como separador
                // Esto genera un arreglo, por ejemplo: ["balance", "general", "3"]
                string[] partes = nombreArchivo.Split('-');

                // Verifica que haya al menos dos partes y que la última parte sea un número entero
                // partes[^1] accede al último elemento del arreglo (el número autoincremental)
                if (partes.Length >= 2 && int.TryParse(partes[^1], out int numero))
                {
                    // Si el número encontrado es mayor que el máximo actual, lo actualiza
                    if (numero > maxNumero)
                    {
                        maxNumero = numero;
                    }
                }
            }

            return maxNumero + 1;
        }

        // Pregunta al usuario si desea guardar el resultado
        // retorna: true si quiere guardar, false si no

        // MARK: Guardar archivo - preguntar si guardar
        public static bool PreguntarSiGuardarResultado()
        {
            MostrarLineaDivisora(true, true);
            Console.WriteLine("¿Desea guardar este resultado en un archivo de texto?");
            Console.WriteLine("1. Si, guardar resultado");
            Console.WriteLine("2. No, solo visualizar");
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(1, 2);
            return opcion == 1;
        }

        /*
        ===========================
            Función de Formateo de Moneda
        ===========================
        */
        // MARK: Utilidad Moneda
        // Formatea un número como moneda en córdobas nicaragüenses (NIO)
        // Formato: NIO C$ 1,234.56
        public static string FormatearMoneda(int valor)
        {
            return $"NIO C$ {valor:N2}";
        }

        // Sobrecarga para valores decimales
        public static string FormatearMoneda(decimal valor)
        {
            return $"NIO C$ {valor:N2}";
        }

        // Solicita un año válido (entre 1900 y 2100)
        public static int SolicitarAnio()
        {
            while (true)
            {
                try
                {
                    int anio = int.Parse(Console.ReadLine() ?? string.Empty);
                    if (anio >= 1900 && anio <= 2100)
                    {
                        return anio;
                    }
                    else
                    {
                        Console.Write("[ERROR] El año debe estar entre 1900 y 2100. Intente de nuevo: ");
                    }
                }
                catch (Exception)
                {
                    Console.Write("[ERROR] Entrada no válida. Ingrese un año válido: ");
                }
            }
        }
    }
}
