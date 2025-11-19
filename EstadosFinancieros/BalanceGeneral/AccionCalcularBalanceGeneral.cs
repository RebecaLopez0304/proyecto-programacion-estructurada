using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.MenusBalanceGeneral;
using System.Text;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    public static class AccionCalcularBalanceGeneral
    {
        public static void Ejecutar()
        {
            MostrarLineaDivisoraConTexto("Calculo de Balance General", true, true);

            // Lista para almacenar las cuentas seleccionadas con sus valores
            var cuentasSeleccionadas = new List<(Cuenta cuenta, decimal valor)>();

            bool continuar = true;

            while (continuar)
            {
                // Mostrar menú de categorías
                int categoria = MostrarMenuCategoriasConSalida();

                if (categoria == 0)
                {
                    continuar = false;
                    continue;
                }

                // Obtener la lista de cuentas según la categoría seleccionada
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

                // Mostrar cuentas disponibles
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

                // Solicitar valor
                Console.WriteLine($"Ingrese el valor para '{cuentaSeleccionada.Nombre}': $");
                decimal valor = (decimal)SolicitarDouble(0);

                // Agregar a la lista de cuentas seleccionadas
                cuentasSeleccionadas.Add((cuentaSeleccionada, valor));

                MostrarMensajeExito($"Cuenta '{cuentaSeleccionada.Nombre}' agregada con valor ${valor:N2}", true, false);

                // Preguntar si desea agregar más cuentas
                int opcion = MostrarMenuContinuar();

                if (opcion == 2)
                {
                    continuar = false;
                }
            }

            // Verificar que se hayan agregado cuentas
            if (cuentasSeleccionadas.Count == 0)
            {
                MostrarMensajeAdvertencia("No se agregaron cuentas al calculo.", true, false);
                EsperarTecla();
                return;
            }

            // Realizar el cálculo y construir el contenido para guardar
            MostrarLineaDivisoraConTexto("Resultado del Balance General", true, true);

            var resultado = new StringBuilder();
            resultado.AppendLine("==============================================================");
            resultado.AppendLine("                    BALANCE GENERAL");
            resultado.AppendLine($"                    {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            resultado.AppendLine("==============================================================");
            resultado.AppendLine();

            decimal totalActivos = 0;
            decimal totalPasivos = 0;
            decimal totalCapital = 0;

            // Agrupar por tipo - ACTIVOS
            resultado.AppendLine("ACTIVOS");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("ACTIVOS", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x => x.cuenta.EsDeudora &&
                (CuentasBalanceGeneral.ActivoCirculante.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.ActivoFijo.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.ActivoIntangible.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.OtrosActivos.Contains(x.cuenta))))
            {
                decimal valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
                totalActivos += valorConSigno;
                string linea = $"  {item.cuenta.Nombre}: ${item.valor:N2}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }
            string totalActivosLinea = $"TOTAL ACTIVOS: ${totalActivos:N2}";
            Console.WriteLine(totalActivosLinea);
            resultado.AppendLine(totalActivosLinea);
            resultado.AppendLine();

            // PASIVOS
            resultado.AppendLine("PASIVOS");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("PASIVOS", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x => !x.cuenta.EsDeudora &&
                (CuentasBalanceGeneral.PasivoLargoPlazo.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.PasivoCortoPlazo.Contains(x.cuenta))))
            {
                decimal valorConSigno = item.cuenta.EsDeudora ? item.valor : item.valor;
                totalPasivos += valorConSigno;
                string linea = $"  {item.cuenta.Nombre}: ${item.valor:N2}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }
            string totalPasivosLinea = $"TOTAL PASIVOS: ${totalPasivos:N2}";
            Console.WriteLine(totalPasivosLinea);
            resultado.AppendLine(totalPasivosLinea);
            resultado.AppendLine();

            // CAPITAL CONTABLE
            resultado.AppendLine("CAPITAL CONTABLE");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("CAPITAL CONTABLE", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x =>
                CuentasBalanceGeneral.CapitalContribuido.Contains(x.cuenta) ||
                CuentasBalanceGeneral.CapitalGanado.Contains(x.cuenta)))
            {
                decimal valorConSigno = item.cuenta.EsDeudora ? item.valor : item.valor;
                totalCapital += valorConSigno;
                string linea = $"  {item.cuenta.Nombre}: ${item.valor:N2}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }
            string totalCapitalLinea = $"TOTAL CAPITAL CONTABLE: ${totalCapital:N2}";
            Console.WriteLine(totalCapitalLinea);
            resultado.AppendLine(totalCapitalLinea);
            resultado.AppendLine();

            // ECUACION CONTABLE
            decimal totalPasivoMasCapital = totalPasivos + totalCapital;

            resultado.AppendLine("==============================================================");
            resultado.AppendLine("                    ECUACION CONTABLE");
            resultado.AppendLine("==============================================================");
            MostrarLineaDivisoraConTexto("Ecuacion Contable", true, true);
            
            string activosLinea = $"Activos           : ${totalActivos:N2}";
            string pasivoCapitalLinea = $"Pasivos + Capital : ${totalPasivoMasCapital:N2}";
            Console.WriteLine(activosLinea);
            Console.WriteLine(pasivoCapitalLinea);
            resultado.AppendLine(activosLinea);
            resultado.AppendLine(pasivoCapitalLinea);
            MostrarLineaDivisora(true, false);
            resultado.AppendLine(new string('-', 60));

            bool balanceado = Math.Abs(totalActivos - totalPasivoMasCapital) < 0.01m;

            if (balanceado)
            {
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
                decimal diferencia = totalActivos - totalPasivoMasCapital;
                MostrarMensajeError("BALANCE GENERAL DESCUADRADO", true, false);
                Console.WriteLine($"  Diferencia: ${Math.Abs(diferencia):N2}");
                Console.WriteLine(diferencia > 0
                    ? "  Hay mas activos que pasivos + capital"
                    : "  Hay mas pasivos + capital que activos");
                resultado.AppendLine();
                resultado.AppendLine("[ADVERTENCIA] BALANCE GENERAL DESCUADRADO");
                resultado.AppendLine($"Diferencia: ${Math.Abs(diferencia):N2}");
                resultado.AppendLine(diferencia > 0
                    ? "Hay mas activos que pasivos + capital"
                    : "Hay mas pasivos + capital que activos");
            }

            resultado.AppendLine();
            resultado.AppendLine("==============================================================");

            // Preguntar si desea guardar el resultado
            if (PreguntarSiGuardarResultado())
            {
                string rutaArchivo = GuardarResultadoEnArchivo("balance-general", resultado.ToString());
                
                if (!string.IsNullOrEmpty(rutaArchivo))
                {
                    MostrarMensajeExito($"Resultado guardado exitosamente en:", true, false);
                    Console.WriteLine($"  {rutaArchivo}");
                }
            }

            EsperarTecla();
        }
    }
}
