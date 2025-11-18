using System;

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

        public static string SolicitarString(string entradaUsuario)
        {
            while (true)
            {
                try
                {
                    string entrada = Console.ReadLine() ?? string.Empty;
                    entradaUsuario = entrada.Trim();

                    if (entradaUsuario.Length > 3)
                    {
                        return entradaUsuario;
                    }
                    else
                    {
                        Console.WriteLine("[Error] debe ingrese al menos 3 caracteres: ");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("[ERROR] favor ingresar un valor valido");
                }
            }
        }

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
    }
}
