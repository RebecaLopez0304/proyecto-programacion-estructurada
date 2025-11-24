using System;
using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo;

/*
    Este programa se utilizara para realizar un balance general, un estado de resultados y un flujo de efectivo
    Las clasificaciones de las cuentas seran fijadas desde un iniciio, junto a su subclasificaciones
    El usuario podra agregar, eliminar o modificar cuentas y sus clasificaciones
*/

namespace ProyectoProgramacion
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                int opcion = MostrarMenuPrincipal();

                switch (opcion)
                {
                    case 1:
                        BalanceGeneral.Ejecutar();
                        break;
                    case 2:
                        EstadoResultados.Ejecutar();
                        break;
                    case 3:
                        FlujoEfectivo.Ejecutar();
                        break;
                    case 0:
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        MostrarMensajeError("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static int MostrarMenuPrincipal()
        {
            MostrarLineaDivisoraConTexto("Menu Principal", true, true);
            MostrarTituloSubrayado("Seleccione una opcion (0-3):");

            Console.WriteLine("1. Balance General");
            Console.WriteLine("2. Estado de Resultados");
            Console.WriteLine("3. Flujo de Efectivo");

            MostrarLineaDivisora(true);
            Console.WriteLine("0. Salir");

            int opcion = SolicitarEnteroConLimites(0, 3);

            return opcion;
        }
    }
}

