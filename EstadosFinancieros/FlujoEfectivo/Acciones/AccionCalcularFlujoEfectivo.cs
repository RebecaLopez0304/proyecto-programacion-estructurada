using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Catalogos;
using System.Text;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones
{
   /*
   ===========================
       Acción Calcular Flujo de Efectivo
   ===========================
   */
   public static class AccionCalcularFlujoEfectivo
   {
      public static void Ejecutar()
      {
         MostrarLineaDivisoraConTexto("Calcular Flujo de Efectivo", true, true);

         // Solicitar saldo inicial de efectivo
         Console.Write("Ingrese el saldo inicial de efectivo: ");
         int saldoInicial = SolicitarEntero();

         // Guardar las cuentas seleccionadas con sus montos
         var cuentasSeleccionadas = new List<(Cuenta cuenta, int valor)>();

         bool continuar = true;

         while (continuar)
         {
            // El usuario elige una actividad; 0 indica terminar
            int actividad = MostrarMenuActividadesConSalida();

            if (actividad == 0)
            {
               continuar = false;
               continue;
            }

            // Selecciona la lista de cuentas según la actividad elegida
            List<Cuenta> listaCuentas = actividad switch
            {
               1 => CuentasFlujoEfectivo.ActividadesOperacion,
               2 => CuentasFlujoEfectivo.ActividadesInversion,
               3 => CuentasFlujoEfectivo.ActividadesFinanciamiento,
               _ => new List<Cuenta>()
            };

            // Nombre amigable de la actividad para mostrar al usuario
            string nombreActividad = actividad switch
            {
               1 => "Actividades de Operación",
               2 => "Actividades de Inversión",
               3 => "Actividades de Financiamiento",
               _ => "Actividad Desconocida"
            };

            // Mostramos las cuentas de la actividad y pedimos al usuario que elija una
            MostrarTituloSubrayado($"Cuentas de {nombreActividad}", true, true);
            for (int i = 0; i < listaCuentas.Count; i++)
            {
               string naturaleza = listaCuentas[i].EsDeudora ? "[Entrada ]" : "[Salida  ]";
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

         // ===== AHORA SÍ CALCULAMOS TODO (FUERA DEL LOOP) =====

         // Creamos el reporte en pantalla y en memoria
         MostrarLineaDivisoraConTexto("Resultado del Flujo de Efectivo", true, true);

         var resultado = new StringBuilder();
         resultado.AppendLine("==============================================================");
         resultado.AppendLine("                    FLUJO DE EFECTIVO");
         resultado.AppendLine($"                    {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
         resultado.AppendLine("==============================================================");
         resultado.AppendLine();

         // Mostrar saldo inicial
         string saldoInicialLinea = $"SALDO INICIAL DE EFECTIVO: {FormatearMoneda(saldoInicial)}";
         Console.WriteLine(saldoInicialLinea);
         resultado.AppendLine(saldoInicialLinea);
         resultado.AppendLine();

         int flujoOperacion = 0;
         int flujoInversion = 0;
         int flujoFinanciamiento = 0;

         // ===== SECCIÓN 1: ACTIVIDADES DE OPERACIÓN =====
         resultado.AppendLine("ACTIVIDADES DE OPERACIÓN");
         resultado.AppendLine(new string('-', 60));
         MostrarTituloSubrayado("ACTIVIDADES DE OPERACIÓN", true, true);

         foreach (var item in cuentasSeleccionadas.Where(x => CuentasFlujoEfectivo.ActividadesOperacion.Contains(x.cuenta)))
         {
            // Si es Entrada (true) = suma
            // Si es Salida (false) = resta
            int valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
            flujoOperacion += valorConSigno;

            string signo = item.cuenta.EsDeudora ? "(+)" : "(-)";
            string linea = $"  {signo} {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         string flujoOpLinea = $"FLUJO NETO DE OPERACIÓN: {FormatearMoneda(flujoOperacion)}";
         Console.WriteLine(flujoOpLinea);
         resultado.AppendLine(flujoOpLinea);
         resultado.AppendLine();

         // ===== SECCIÓN 2: ACTIVIDADES DE INVERSIÓN =====
         resultado.AppendLine("ACTIVIDADES DE INVERSIÓN");
         resultado.AppendLine(new string('-', 60));
         MostrarTituloSubrayado("ACTIVIDADES DE INVERSIÓN", true, true);

         foreach (var item in cuentasSeleccionadas.Where(x => CuentasFlujoEfectivo.ActividadesInversion.Contains(x.cuenta)))
         {
            // Si es Entrada (true) = venta, suma
            // Si es Salida (false) = compra, resta
            int valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
            flujoInversion += valorConSigno;

            string signo = item.cuenta.EsDeudora ? "(+)" : "(-)";
            string linea = $"  {signo} {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         string flujoInvLinea = $"FLUJO NETO DE INVERSIÓN: {FormatearMoneda(flujoInversion)}";
         Console.WriteLine(flujoInvLinea);
         resultado.AppendLine(flujoInvLinea);
         resultado.AppendLine();

         // ===== SECCIÓN 3: ACTIVIDADES DE FINANCIAMIENTO =====
         resultado.AppendLine("ACTIVIDADES DE FINANCIAMIENTO");
         resultado.AppendLine(new string('-', 60));
         MostrarTituloSubrayado("ACTIVIDADES DE FINANCIAMIENTO", true, true);

         foreach (var item in cuentasSeleccionadas.Where(x => CuentasFlujoEfectivo.ActividadesFinanciamiento.Contains(x.cuenta)))
         {
            // Si es Entrada (true) = préstamo obtenido, aportación, suma
            // Si es Salida (false) = pago, dividendo, resta
            int valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
            flujoFinanciamiento += valorConSigno;

            string signo = item.cuenta.EsDeudora ? "(+)" : "(-)";
            string linea = $"  {signo} {item.cuenta.Nombre}: {FormatearMoneda(item.valor)}";
            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         string flujoFinLinea = $"FLUJO NETO DE FINANCIAMIENTO: {FormatearMoneda(flujoFinanciamiento)}";
         Console.WriteLine(flujoFinLinea);
         resultado.AppendLine(flujoFinLinea);
         resultado.AppendLine();

         // ===== CÁLCULO DEL SALDO FINAL =====
         int aumentoDisminucionNeto = flujoOperacion + flujoInversion + flujoFinanciamiento;
         int saldoFinal = saldoInicial + aumentoDisminucionNeto;

         resultado.AppendLine("==============================================================");
         resultado.AppendLine("                    RESUMEN FINAL");
         resultado.AppendLine("==============================================================");
         MostrarLineaDivisoraConTexto("Resumen Final", true, true);

         string aumentoLinea = aumentoDisminucionNeto >= 0
             ? $"AUMENTO NETO EN EFECTIVO: {FormatearMoneda(aumentoDisminucionNeto)}"
             : $"DISMINUCIÓN NETA EN EFECTIVO: {FormatearMoneda(Math.Abs(aumentoDisminucionNeto))}";

         Console.WriteLine(aumentoLinea);
         resultado.AppendLine(aumentoLinea);

         string saldoFinalLinea = $"SALDO FINAL DE EFECTIVO: {FormatearMoneda(saldoFinal)}";
         Console.WriteLine(saldoFinalLinea);
         resultado.AppendLine(saldoFinalLinea);
         resultado.AppendLine();

         if (aumentoDisminucionNeto >= 0)
         {
            MostrarMensajeExito("La empresa generó efectivo en el período", true, false);
            resultado.AppendLine("[RESULTADO] La empresa generó efectivo en el período");
         }
         else
         {
            MostrarMensajeError("La empresa utilizó efectivo en el período", true, false);
            resultado.AppendLine("[RESULTADO] La empresa utilizó efectivo en el período");
         }

         resultado.AppendLine();
         resultado.AppendLine("==============================================================");

         // Preguntar si desea guardar el resultado
         if (PreguntarSiGuardarResultado())
         {
            string rutaArchivo = GuardarResultadoEnArchivo("flujo-efectivo", resultado.ToString());

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

