using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Menus.MenusEstadoResultados;
using ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos;
using System.Text;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Acciones
{
    /*
    ===========================
        Acción Calcular Estado de Resultados
    ===========================
    */
    public static class AccionCalcularEstadoResultados
    {
        public static void Ejecutar()
        {
            MostrarLineaDivisoraConTexto("Calcular Estado de Resultados", true, true);

            // Solicitar datos de la empresa y período
            Console.Write("Ingrese el nombre de la empresa: ");
            string nombreEmpresa = SolicitarString("");

            Console.Write("Ingrese el mes del período (ej. Diciembre): ");
            string mes = SolicitarString("");

            Console.Write("Ingrese el año del período (ej. 2024): ");
            int anio = SolicitarAnio();

            Console.WriteLine();

            // Guardar las cuentas seleccionadas con sus montos
            var cuentasSeleccionadas = new List<(Cuenta cuenta, int valor)>();

            bool continuar = true;

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
                    1 => CuentasEstadoResultados.Ventas,
                    2 => CuentasEstadoResultados.CostoDeVentas,
                    3 => CuentasEstadoResultados.GastoDeOperacion,
                    4 => CuentasEstadoResultados.GastosAdministracion,
                    5 => CuentasEstadoResultados.OtrosResultadosFinancieros,
                    _ => new List<Cuenta>()
                };

                // Nombre amigable de la categoría para mostrar al usuario
                string nombreCategoria = categoria switch
                {
                    1 => "Ventas",
                    2 => "Costo de Ventas",
                    3 => "Gastos de Operación",
                    4 => "Gastos de Administración",
                    5 => "Otros Resultados Financieros",
                    _ => "Categoría Desconocida"
                };

                // Mostramos las cuentas de la categoría y pedimos al usuario que elija una
                MostrarTituloSubrayado($"Cuentas de {nombreCategoria}", true, true);
                for (int i = 0; i < listaCuentas.Count; i++)
                {
                    string naturaleza = listaCuentas[i].EsDeudora ? "[Egreso  ]" : "[Ingreso ]";
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
            MostrarLineaDivisoraConTexto("Resultado del Estado de Resultados", true, true);

            var resultado = new StringBuilder();
            resultado.AppendLine("==============================================================");
            resultado.AppendLine($"                    {nombreEmpresa.ToUpper()}");
            resultado.AppendLine("                  ESTADO DE RESULTADOS");
            resultado.AppendLine($"            Del 1 al 31 de {mes} de {anio}");
            resultado.AppendLine($"          (Expresado en Córdobas - NIO C$)");
            resultado.AppendLine("==============================================================");
            resultado.AppendLine();

            int totalVentas = 0;
            int totalCostoVentas = 0;
            int totalGastosOperacion = 0;
            int totalGastosAdministracion = 0;
            int totalOtrosResultados = 0;

            // MARK: VENTAS
            resultado.AppendLine("VENTAS");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("VENTAS", true, true);

            // Filtrar SOLO las cuentas de Ventas
            foreach (var item in cuentasSeleccionadas.Where(x => CuentasEstadoResultados.Ventas.Contains(x.cuenta)))
            {
                // Si es Ingreso (false) = ventas, suma
                // Si es Egreso (true) = devolución/descuento, resta
                int valorConSigno = item.cuenta.EsDeudora ? -item.valor : item.valor;
                totalVentas += valorConSigno;

                string signo = item.cuenta.EsDeudora ? "(-)" : "(+)";
                string linea = $"  {signo} {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }

            string totalVentasLinea = $"VENTAS NETAS: {FormatearMoneda(totalVentas)}";
            Console.WriteLine(totalVentasLinea);
            resultado.AppendLine(totalVentasLinea);
            resultado.AppendLine();

            // MARK: COSTO DE VENTAS
            resultado.AppendLine("COSTO DE VENTAS");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("COSTO DE VENTAS", true, true);

            foreach (var item in cuentasSeleccionadas.Where(x => CuentasEstadoResultados.CostoDeVentas.Contains(x.cuenta)))
            {
                // Si es Egreso (true) = costo, suma
                // Si es Ingreso (false) = descuento/devolución, resta
                int valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
                totalCostoVentas += valorConSigno;

                string signo = item.cuenta.EsDeudora ? "(+)" : "(-)";
                string linea = $"  {signo} {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }

            string totalCostoLinea = $"TOTAL COSTO DE VENTAS: {FormatearMoneda(totalCostoVentas)}";
            Console.WriteLine(totalCostoLinea);
            resultado.AppendLine(totalCostoLinea);
            resultado.AppendLine();

            // MARK: UTILIDAD BRUTA
            int utilidadBruta = totalVentas - totalCostoVentas;
            string utilidadBrutaLinea = $"UTILIDAD BRUTA: {FormatearMoneda(utilidadBruta)}";
            Console.WriteLine(utilidadBrutaLinea);
            resultado.AppendLine(utilidadBrutaLinea);
            resultado.AppendLine();

            // MARK: GASTOS DE OPERACIÓN
            resultado.AppendLine("GASTOS DE OPERACIÓN");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("GASTOS DE OPERACIÓN", true, true);

            foreach (var item in cuentasSeleccionadas.Where(x => CuentasEstadoResultados.GastoDeOperacion.Contains(x.cuenta)))
            {
                // Gastos son Egresos, siempre suman
                totalGastosOperacion += item.valor;
                string linea = $"  (+) {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }

            string totalGastosOpLinea = $"TOTAL GASTOS DE OPERACIÓN: {FormatearMoneda(totalGastosOperacion)}";
            Console.WriteLine(totalGastosOpLinea);
            resultado.AppendLine(totalGastosOpLinea);
            resultado.AppendLine();

            // MARK: GASTOS DE ADMINISTRACIÓN
            resultado.AppendLine("GASTOS DE ADMINISTRACIÓN");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("GASTOS DE ADMINISTRACIÓN", true, true);

            foreach (var item in cuentasSeleccionadas.Where(x => CuentasEstadoResultados.GastosAdministracion.Contains(x.cuenta)))
            {
                // Gastos son Egresos, siempre suman
                totalGastosAdministracion += item.valor;
                string linea = $"  (+) {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }

            string totalGastosAdminLinea = $"TOTAL GASTOS DE ADMINISTRACIÓN: {FormatearMoneda(totalGastosAdministracion)}";
            Console.WriteLine(totalGastosAdminLinea);
            resultado.AppendLine(totalGastosAdminLinea);
            resultado.AppendLine();

            // MARK: UTILIDAD DE OPERACIÓN
            int totalGastosOperacionCompletos = totalGastosOperacion + totalGastosAdministracion;
            int utilidadOperacion = utilidadBruta - totalGastosOperacionCompletos;
            string utilidadOpLinea = $"UTILIDAD DE OPERACIÓN: {FormatearMoneda(utilidadOperacion)}";
            Console.WriteLine(utilidadOpLinea);
            resultado.AppendLine(utilidadOpLinea);
            resultado.AppendLine();

            // MARK: OTROS RESULTADOS FINANCIEROS
            resultado.AppendLine("OTROS RESULTADOS FINANCIEROS");
            resultado.AppendLine(new string('-', 60));
            MostrarTituloSubrayado("OTROS RESULTADOS FINANCIEROS", true, true);

            foreach (var item in cuentasSeleccionadas.Where(x => CuentasEstadoResultados.OtrosResultadosFinancieros.Contains(x.cuenta)))
            {
                // Si es Egreso = gasto financiero, resta
                // Si es Ingreso = producto financiero, suma
                int valorConSigno = item.cuenta.EsDeudora ? -item.valor : item.valor;
                totalOtrosResultados += valorConSigno;

                string signo = item.cuenta.EsDeudora ? "(-)" : "(+)";
                string linea = $"  {signo} {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }

            string totalOtrosLinea = $"TOTAL OTROS RESULTADOS: {FormatearMoneda(totalOtrosResultados)}";
            Console.WriteLine(totalOtrosLinea);
            resultado.AppendLine(totalOtrosLinea);
            resultado.AppendLine();

            // MARK: RESULTADO FINAL (UTILIDAD O PÉRDIDA)
            int resultadoFinal = utilidadOperacion + totalOtrosResultados;

            resultado.AppendLine("==============================================================");
            resultado.AppendLine("                    RESULTADO FINAL");
            resultado.AppendLine("==============================================================");
            MostrarLineaDivisoraConTexto("Resultado Final", true, true);

            string resultadoLinea = resultadoFinal >= 0
                ? $"UTILIDAD NETA: {FormatearMoneda(resultadoFinal)}"
                : $"PÉRDIDA NETA: {FormatearMoneda(Math.Abs(resultadoFinal))}";

            Console.WriteLine(resultadoLinea);
            resultado.AppendLine(resultadoLinea);
            resultado.AppendLine();

            if (resultadoFinal >= 0)
            {
                MostrarMensajeExito("La empresa obtuvo UTILIDAD en el período", true, false);
                resultado.AppendLine("[RESULTADO] La empresa obtuvo UTILIDAD en el período");
            }
            else
            {
                MostrarMensajeError("La empresa tuvo PÉRDIDA en el período", true, false);
                resultado.AppendLine("[RESULTADO] La empresa tuvo PÉRDIDA en el período");
            }

            resultado.AppendLine();
            resultado.AppendLine("==============================================================");

            // MARK: Preguntar si desea guardar el resultado
            if (PreguntarSiGuardarResultado())
            {
                string rutaArchivo = GuardarResultadoEnArchivo("estado-resultados", resultado.ToString());

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
