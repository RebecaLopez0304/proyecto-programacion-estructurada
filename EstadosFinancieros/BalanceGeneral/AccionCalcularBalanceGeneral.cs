using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.MenusBalanceGeneral;

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

            // Realizar el cálculo
            MostrarLineaDivisoraConTexto("Resultado del Balance General", true, true);

            decimal totalActivos = 0;
            decimal totalPasivos = 0;
            decimal totalCapital = 0;

            // Agrupar por tipo
            MostrarTituloSubrayado("ACTIVOS", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x => x.cuenta.EsDeudora &&
                (CuentasBalanceGeneral.ActivoCirculante.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.ActivoFijo.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.ActivoIntangible.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.OtrosActivos.Contains(x.cuenta))))
            {
                decimal valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
                totalActivos += valorConSigno;
                Console.WriteLine($"  {item.cuenta.Nombre}: ${item.valor:N2}");
            }
            Console.WriteLine($"TOTAL ACTIVOS: ${totalActivos:N2}");

            MostrarTituloSubrayado("PASIVOS", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x => !x.cuenta.EsDeudora &&
                (CuentasBalanceGeneral.PasivoLargoPlazo.Contains(x.cuenta) ||
                 CuentasBalanceGeneral.PasivoCortoPlazo.Contains(x.cuenta))))
            {
                decimal valorConSigno = item.cuenta.EsDeudora ? item.valor : item.valor;
                totalPasivos += valorConSigno;
                Console.WriteLine($"  {item.cuenta.Nombre}: ${item.valor:N2}");
            }
            Console.WriteLine($"TOTAL PASIVOS: ${totalPasivos:N2}");

            MostrarTituloSubrayado("CAPITAL CONTABLE", true, true);
            foreach (var item in cuentasSeleccionadas.Where(x =>
                CuentasBalanceGeneral.CapitalContribuido.Contains(x.cuenta) ||
                CuentasBalanceGeneral.CapitalGanado.Contains(x.cuenta)))
            {
                decimal valorConSigno = item.cuenta.EsDeudora ? item.valor : item.valor;
                totalCapital += valorConSigno;
                Console.WriteLine($"  {item.cuenta.Nombre}: ${item.valor:N2}");
            }
            Console.WriteLine($"TOTAL CAPITAL CONTABLE: ${totalCapital:N2}");

            // ECUACION CONTABLE
            decimal totalPasivoMasCapital = totalPasivos + totalCapital;

            MostrarLineaDivisoraConTexto("Ecuacion Contable", true, true);
            Console.WriteLine($"Activos           : ${totalActivos:N2}");
            Console.WriteLine($"Pasivos + Capital : ${totalPasivoMasCapital:N2}");
            MostrarLineaDivisora(true, false);

            bool balanceado = Math.Abs(totalActivos - totalPasivoMasCapital) < 0.01m;

            if (balanceado)
            {
                MostrarMensajeExito("BALANCE GENERAL CUADRADO", true, false);
                Console.WriteLine("  La ecuacion contable esta balanceada:");
                Console.WriteLine("  Activos = Pasivos + Capital");
            }
            else
            {
                decimal diferencia = totalActivos - totalPasivoMasCapital;
                MostrarMensajeError("BALANCE GENERAL DESCUADRADO", true, false);
                Console.WriteLine($"  Diferencia: ${Math.Abs(diferencia):N2}");
                Console.WriteLine(diferencia > 0
                    ? "  Hay mas activos que pasivos + capital"
                    : "  Hay mas pasivos + capital que activos");
            }

            EsperarTecla();
        }
    }
}
