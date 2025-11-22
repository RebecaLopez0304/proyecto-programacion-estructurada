// Importa utilidades generales del proyecto
using ProyectoProgramacion.Comunes;
// Permite usar métodos de Utilidades sin prefijo
using static ProyectoProgramacion.Comunes.Utilidades;
// Importa menús específicos para pedir categorías y opciones
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus.MenusBalanceGeneral;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Catalogos;
// Para construir texto de salida (StringBuilder)
using System.Text;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones
{
    public static class AccionCalcularBalanceGeneral
    {
        // Método principal que guía al usuario para ingresar valores y calcular el balance
        public static void Ejecutar()
        {
            MostrarLineaDivisoraConTexto("Calculo de Balance General", true, true);

            // Guardará las cuentas seleccionadas con su monto
            var cuentasSeleccionadas = new List<(Cuenta cuenta, int valor)>();

            bool continuar = true;

            // Bucle para permitir agregar varias cuentas al cálculo
            while (continuar)
            {
                // El usuario elige una categoría; 0 indica terminar
                int categoria = MostrarMenuCategoriasConSalida();

                if (categoria == 0)
                {
                    continuar = false;
                    continue;
                }

                // Selecciona la lista de cuentas según la categoría elegida
                List<Cuenta> listaCuentas = categoria switch
                {
                    1 => CuentasBalanceGeneral.ActivoCirculante,
                    2 => CuentasBalanceGeneral.ActivoFijo,
                    3 => CuentasBalanceGeneral.ActivoIntangible,
                    4 => CuentasBalanceGeneral.OtrosActivos,
                    5 => CuentasBalanceGeneral.PasivoLargoPlazo,
                    6 => CuentasBalanceGeneral.PasivoCortoPlazo,
                    7 => CuentasBalanceGeneral.CapitalContribuido,
                    8 => CuentasBalanceGeneral.CapitalGanado,
                    _ => new List<Cuenta>()
                };

                // Nombre amigable de la categoría para mostrar al usuario
                string nombreCategoria = categoria switch
                {
                    1 => "Activo Circulante",
                    2 => "Activo Fijo",
                    3 => "Activo Intangible",
                    4 => "Otros Activos",
                    5 => "Pasivo a Largo Plazo",
                    6 => "Pasivo a Corto Plazo",
                    7 => "Capital Contribuido",
                    8 => "Capital Ganado",
                    _ => ""
                };

                // Mostramos las cuentas de la categoría y pedimos al usuario que elija una
                MostrarTituloSubrayado($"Cuentas de {nombreCategoria}", true, true);
                for (int i = 0; i < listaCuentas.Count; i++)
                {
                    string naturaleza = listaCuentas[i].EsDeudora ? "[Deudora  ]" : "[Acreedora]";
                    Console.WriteLine($"{i + 1}. {naturaleza} {listaCuentas[i].Nombre}");
                }
                MostrarLineaDivisora(true, true);

                Console.WriteLine($"Seleccione la cuenta (1-{listaCuentas.Count}):");
                int indiceCuenta = SolicitarEnteroConLimites(1, listaCuentas.Count) - 1;

                Cuenta cuentaSeleccionada = listaCuentas[indiceCuenta];

                // Solicitamos el valor numérico para la cuenta seleccionada
                Console.Write($"Ingrese el valor para '{cuentaSeleccionada.Nombre}': ");
                int valor = SolicitarEntero();

                // Agregamos la pareja (cuenta, valor) a la lista de cálculo
                cuentasSeleccionadas.Add((cuentaSeleccionada, valor));

                MostrarMensajeExito($"Cuenta '{cuentaSeleccionada.Nombre}' agregada con valor {FormatearMoneda(valor)}", true, false);

                // Preguntamos si desea continuar agregando cuentas
                int opcion = MostrarMenuContinuar();

                if (opcion == 2)
                {
                    continuar = false;
                }
            }

            // Si no hay cuentas, avisamos y salimos
            if (cuentasSeleccionadas.Count == 0)
            {
                MostrarMensajeAdvertencia("No se agregaron cuentas al calculo.", true, false);
                EsperarTecla();
                return;
            }

            // Creamos el reporte en pantalla y en memoria
            MostrarLineaDivisoraConTexto("Resultado del Balance General", true, true);

            var resultado = new StringBuilder();
            resultado.AppendLine("==============================================================");
            resultado.AppendLine("                    BALANCE GENERAL");
            resultado.AppendLine($"                    {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            resultado.AppendLine("==============================================================");
            resultado.AppendLine();

            int totalActivos = 0;
            int totalPasivos = 0;
            int totalCapital = 0;

            // Calculamos y mostramos los ACTIVOS
            resultado.AppendLine("ACTIVOS");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("ACTIVOS", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x => x.cuenta.EsDeudora &&
                (CuentasBalanceGeneral.ActivoCirculante.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.ActivoFijo.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.ActivoIntangible.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.OtrosActivos.Contains(x.cuenta))))
            {
                int valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
                totalActivos += valorConSigno;
                string linea = $"  {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }
            string totalActivosLinea = $"TOTAL ACTIVOS: {FormatearMoneda(totalActivos)}";
            Console.WriteLine(totalActivosLinea);
            resultado.AppendLine(totalActivosLinea);
            resultado.AppendLine();

            // Calculamos y mostramos los PASIVOS
            resultado.AppendLine("PASIVOS");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("PASIVOS", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x => !x.cuenta.EsDeudora &&
                (CuentasBalanceGeneral.PasivoLargoPlazo.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.PasivoCortoPlazo.Contains(x.cuenta))))
            {
                // Para pasivos (normalmente acreedores) aplicamos signo negativo cuando corresponda
                int valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
                totalPasivos += valorConSigno;
                string linea = $"  {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }
            string totalPasivosLinea = $"TOTAL PASIVOS: {FormatearMoneda(totalPasivos)}";
            Console.WriteLine(totalPasivosLinea);
            resultado.AppendLine(totalPasivosLinea);
            resultado.AppendLine();

            // Calculamos y mostramos el CAPITAL
            resultado.AppendLine("CAPITAL CONTABLE");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("CAPITAL CONTABLE", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x =>
                CuentasBalanceGeneral.CapitalContribuido.Contains(x.cuenta) ||
                CuentasBalanceGeneral.CapitalGanado.Contains(x.cuenta)))
            {
                // Para capital aplicamos signo negativo cuando la cuenta es acreedora
                int valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
                totalCapital += valorConSigno;
                string linea = $"  {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }
            string totalCapitalLinea = $"TOTAL CAPITAL CONTABLE: {FormatearMoneda(totalCapital)}";
            Console.WriteLine(totalCapitalLinea);
            resultado.AppendLine(totalCapitalLinea);
            resultado.AppendLine();

            // Comprobamos la ecuación contable
            int totalPasivoMasCapital = totalPasivos + totalCapital;

            resultado.AppendLine("==============================================================");
            resultado.AppendLine("                    ECUACION CONTABLE");
            resultado.AppendLine("==============================================================");
            MostrarLineaDivisoraConTexto("Ecuacion Contable", true, true);

            string activosLinea = $"Activos           : {FormatearMoneda(totalActivos)}";
            string pasivoCapitalLinea = $"Pasivos + Capital : {FormatearMoneda(totalPasivoMasCapital)}";
            Console.WriteLine(activosLinea);
            Console.WriteLine(pasivoCapitalLinea);
            resultado.AppendLine(activosLinea);
            resultado.AppendLine(pasivoCapitalLinea);
            MostrarLineaDivisora(true, false);
            resultado.AppendLine(new string('-', 60));

            // Convertimos a decimal para comparar con una tolerancia pequeña (por centavos)
            bool balanceado = Math.Abs((decimal)totalActivos - (decimal)totalPasivoMasCapital) < 0.01m;

            if (balanceado)
            {
                // Mensaje amigable cuando el balance cuadra
                MostrarMensajeExito("BALANCE GENERAL CUADRADO", true, false);
                Console.WriteLine("  La ecuacion contable esta balanceada:");
                Console.WriteLine("  Activos = Pasivos + Capital");
                resultado.AppendLine();
                resultado.AppendLine("[RESULTADO] BALANCE GENERAL CUADRADO");
                resultado.AppendLine("La ecuacion contable esta balanceada:");
                resultado.AppendLine("Activos = Pasivos + Capital");
            }
            else
            {
                // Mensaje claro cuando hay diferencia
                int diferencia = totalActivos - totalPasivoMasCapital;
                MostrarMensajeError("BALANCE GENERAL DESCUADRADO", true, false);
                Console.WriteLine($"  Diferencia: {FormatearMoneda(Math.Abs(diferencia))}");
                Console.WriteLine(diferencia > 0
                    ? "  Hay mas activos que pasivos + capital"
                    : "  Hay mas pasivos + capital que activos");
                resultado.AppendLine();
                resultado.AppendLine("[ADVERTENCIA] BALANCE GENERAL DESCUADRADO");
                resultado.AppendLine($"Diferencia: {FormatearMoneda(Math.Abs(diferencia))}");
                resultado.AppendLine(diferencia > 0
                    ? "Hay mas activos que pasivos + capital"
                    : "Hay mas pasivos + capital que activos");
            }

            resultado.AppendLine();
            resultado.AppendLine("==============================================================");

            // Ofrecemos guardar el resultado en un archivo
            if (PreguntarSiGuardarResultado())
            {
                string rutaArchivo = GuardarResultadoEnArchivo("balance-general", resultado.ToString());

                if (!string.IsNullOrEmpty(rutaArchivo))
                {
                    MostrarMensajeExito($"Resultado guardado exitosamente en:", true, false);
                    Console.WriteLine($"  {rutaArchivo}");
                }
            }

            // Pausa final para que el usuario revise los datos
            EsperarTecla();
        }
    }
}
