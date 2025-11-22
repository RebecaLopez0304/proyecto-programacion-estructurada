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
      // Estructura para almacenar datos de una cuenta con valores de 2 años
      private class CuentaConValores
      {
         public Cuenta Cuenta { get; set; } = null!;
         public int Valor2014 { get; set; }
         public int Valor2015 { get; set; }
         public string TipoActividad { get; set; } = string.Empty;
      }

      public static void Ejecutar()
      {
         MostrarLineaDivisoraConTexto("Calcular Flujo de Efectivo", true, true);

         // Solicitar año 1 y año 2 con validación
         Console.Write("Ingrese el primer año (ej. 2014): ");
         int anio1 = SolicitarAnio();

         Console.Write("Ingrese el segundo año (ej. 2015): ");
         int anio2 = SolicitarAnio();

         // Validar que el segundo año sea posterior al primero
         while (anio2 <= anio1)
         {
            MostrarMensajeError("El segundo año debe ser posterior al primer año.", true, false);
            Console.Write($"Ingrese un año posterior a {anio1}: ");
            anio2 = SolicitarAnio();
         }

         // Solicitar utilidad ANTES de impuestos y depreciación (siempre van primero en AO)
         Console.WriteLine();
         MostrarTituloSubrayado("Datos iniciales para Actividades de Operación", true, true);

         Console.Write("Ingrese la Utilidad ANTES de impuestos a la utilidad: ");
         int utilidadAntesImpuestos = SolicitarEntero();

         Console.Write("Ingrese el total de Depreciaciones y Amortizaciones del período: ");
         int depreciacionesAmortizaciones = SolicitarEntero();         // Guardar las cuentas seleccionadas con sus valores para ambos años
         var cuentasConValores = new List<CuentaConValores>();

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

            string tipoActividad = actividad switch
            {
               1 => "AO",
               2 => "AI",
               3 => "AF",
               _ => ""
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

            // Solicitamos los valores para ambos años
            Console.Write($"Ingrese el valor para '{cuentaSeleccionada.Nombre}' en {anio1}: ");
            int valor2014 = SolicitarEntero();

            Console.Write($"Ingrese el valor para '{cuentaSeleccionada.Nombre}' en {anio2}: ");
            int valor2015 = SolicitarEntero();

            // Agregamos la cuenta con sus valores
            cuentasConValores.Add(new CuentaConValores
            {
               Cuenta = cuentaSeleccionada,
               Valor2014 = valor2014,
               Valor2015 = valor2015,
               TipoActividad = tipoActividad
            });

            MostrarMensajeExito($"Cuenta '{cuentaSeleccionada.Nombre}' agregada", true, false);

            // Preguntamos si desea continuar agregando cuentas
            int opcion = MostrarMenuContinuar();

            if (opcion == 2)
            {
               continuar = false;
            }
         }

         // Si no hay cuentas, avisamos y salimos
         if (cuentasConValores.Count == 0)
         {
            MostrarMensajeAdvertencia("No se agregaron cuentas al calculo.", true, false);
            EsperarTecla();
            return;
         }

         // ===== GENERAR AMBOS REPORTES =====
         var resultado = new StringBuilder();

         // ===== REPORTE 1: TABLA DE VARIACIONES =====
         GenerarTablaVariaciones(cuentasConValores, utilidadAntesImpuestos, depreciacionesAmortizaciones, anio1, anio2, resultado);

         Console.WriteLine("\n\n");

         // ===== REPORTE 2: FLUJO DE EFECTIVO FORMATO CLÁSICO =====
         GenerarFlujoEfectivoClasico(cuentasConValores, utilidadAntesImpuestos, depreciacionesAmortizaciones, anio1, anio2, resultado);

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

      private static void GenerarTablaVariaciones(List<CuentaConValores> cuentas, int utilidadAntesImpuestos, int depreciacionesAmortizaciones, int anio1, int anio2, StringBuilder resultado)
      {
         MostrarLineaDivisoraConTexto("Tabla de Variaciones - Flujo de Efectivo", true, true);

         resultado.AppendLine("==============================================================");
         resultado.AppendLine("              FLUJO DE EFECTIVO - TABLA DE VARIACIONES");
         resultado.AppendLine($"                    {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
         resultado.AppendLine("==============================================================");
         resultado.AppendLine();

         // Encabezados de la tabla
         string encabezado = string.Format("{0,-40} {1,12} {2,12} {3,12} {4,15} {5,15} {6,15}",
            "Cuentas", anio1.ToString(), anio2.ToString(), "Variaciones",
            "Efecto Neto en el Efectivo", "", "Clasificación");
         string subEncabezado = string.Format("{0,-40} {1,12} {2,12} {3,12} {4,15} {5,15} {6,15}",
            "", "", "", "", "Entrada", "Salida", "");

         Console.WriteLine(encabezado);
         resultado.AppendLine(encabezado);
         Console.WriteLine(subEncabezado);
         resultado.AppendLine(subEncabezado);
         Console.WriteLine(new string('-', 140));
         resultado.AppendLine(new string('-', 140));

         // Variables para totales
         int totalVariaciones = 0;
         int totalEntradas = 0;
         int totalSalidas = 0;

         // Agregar Utilidad antes de impuestos y Depreciaciones/Amortizaciones primero (siempre AO)
         int variacionUtilidad = utilidadAntesImpuestos;
         totalVariaciones += variacionUtilidad;
         totalEntradas += utilidadAntesImpuestos;

         string lineaUtilidad = string.Format("{0,-40} {1,12} {2,12} {3,12} {4,15} {5,15} {6,15}",
            "Utilidad antes de impuestos", "", "", "",
            FormatearMonedaSinPrefijo(utilidadAntesImpuestos), "", "AO");
         Console.WriteLine(lineaUtilidad);
         resultado.AppendLine(lineaUtilidad);

         string lineaDepreciacion = string.Format("{0,-40} {1,12} {2,12} {3,12} {4,15} {5,15} {6,15}",
            "Depreciaciones y Amortizaciones", "", "", "",
            FormatearMonedaSinPrefijo(depreciacionesAmortizaciones), "", "AO");
         Console.WriteLine(lineaDepreciacion);
         resultado.AppendLine(lineaDepreciacion);

         totalEntradas += depreciacionesAmortizaciones;

         // Procesar todas las cuentas ordenadas por tipo de actividad
         var cuentasOrdenadas = cuentas.OrderBy(c => c.TipoActividad).ThenBy(c => c.Cuenta.Nombre);

         foreach (var item in cuentasOrdenadas)
         {
            int variacion = item.Valor2015 - item.Valor2014;
            totalVariaciones += variacion;

            // Determinar si es entrada o salida según la naturaleza de la cuenta y la variación
            int entrada = 0;
            int salida = 0;

            // Lógica según el tipo de cuenta y si aumentó o disminuyó
            if (variacion > 0)
            {
               // La cuenta aumentó
               if (item.Cuenta.EsDeudora)
               {
                  // Cuenta deudora aumentó = salida de efectivo
                  salida = Math.Abs(variacion);
                  totalSalidas += salida;
               }
               else
               {
                  // Cuenta acreedora aumentó = entrada de efectivo
                  entrada = variacion;
                  totalEntradas += entrada;
               }
            }
            else if (variacion < 0)
            {
               // La cuenta disminuyó
               if (item.Cuenta.EsDeudora)
               {
                  // Cuenta deudora disminuyó = entrada de efectivo
                  entrada = Math.Abs(variacion);
                  totalEntradas += entrada;
               }
               else
               {
                  // Cuenta acreedora disminuyó = salida de efectivo
                  salida = Math.Abs(variacion);
                  totalSalidas += salida;
               }
            }

            string linea = string.Format("{0,-40} {1,12} {2,12} {3,12} {4,15} {5,15} {6,15}",
               item.Cuenta.Nombre,
               FormatearMonedaSinPrefijo(item.Valor2014),
               FormatearMonedaSinPrefijo(item.Valor2015),
               FormatearMonedaSinPrefijo(variacion),
               entrada > 0 ? FormatearMonedaSinPrefijo(entrada) : "",
               salida > 0 ? FormatearMonedaSinPrefijo(salida) : "",
               item.TipoActividad);

            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         // Línea de totales
         Console.WriteLine(new string('-', 140));
         resultado.AppendLine(new string('-', 140));

         string lineaTotal = string.Format("{0,-40} {1,12} {2,12} {3,12} {4,15} {5,15} {6,15}",
            "TOTALES", "", "", "",
            FormatearMonedaSinPrefijo(totalEntradas),
            FormatearMonedaSinPrefijo(totalSalidas), "");

         Console.WriteLine(lineaTotal);
         resultado.AppendLine(lineaTotal);

         Console.WriteLine(new string('=', 140));
         resultado.AppendLine(new string('=', 140));
         resultado.AppendLine();
      }

      private static void GenerarFlujoEfectivoClasico(List<CuentaConValores> cuentas, int utilidadAntesImpuestos, int depreciacionesAmortizaciones, int anio1, int anio2, StringBuilder resultado)
      {
         MostrarLineaDivisoraConTexto("Estado de Flujo de Efectivo", true, true);

         resultado.AppendLine("==============================================================");
         resultado.AppendLine("                ESTADO DE FLUJO DE EFECTIVO");
         resultado.AppendLine($"                    al 31/12/{anio2}");
         resultado.AppendLine("==============================================================");
         resultado.AppendLine();

         int flujoOperacion = utilidadAntesImpuestos + depreciacionesAmortizaciones;
         int flujoInversion = 0;
         int flujoFinanciamiento = 0;

         // ===== A. ACTIVIDADES DE OPERACIÓN =====
         resultado.AppendLine("A. ACTIVIDADES DE OPERACIÓN");
         resultado.AppendLine(new string('-', 60));
         MostrarTituloSubrayado("A. ACTIVIDADES DE OPERACIÓN", true, true);

         string lineaUtilidad = $"Utilidad antes de impuestos a la utilidad {FormatearMoneda(utilidadAntesImpuestos)}";
         Console.WriteLine(lineaUtilidad);
         resultado.AppendLine(lineaUtilidad);

         string lineaDepreciacion = $"Depreciaciones y Amortizaciones           {FormatearMoneda(depreciacionesAmortizaciones)}";
         Console.WriteLine(lineaDepreciacion);
         resultado.AppendLine(lineaDepreciacion);

         // Procesar cuentas de operación
         foreach (var item in cuentas.Where(c => c.TipoActividad == "AO"))
         {
            int variacion = item.Valor2015 - item.Valor2014;
            int efecto = 0;

            // Calcular efecto en flujo
            if (variacion > 0)
            {
               efecto = item.Cuenta.EsDeudora ? -Math.Abs(variacion) : variacion;
            }
            else if (variacion < 0)
            {
               efecto = item.Cuenta.EsDeudora ? Math.Abs(variacion) : -Math.Abs(variacion);
            }

            flujoOperacion += efecto;

            string linea = $"{item.Cuenta.Nombre,-45} {FormatearMoneda(efecto)}";
            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         Console.WriteLine(new string('-', 60));
         resultado.AppendLine(new string('-', 60));
         string flujoOpLinea = $"Flujos netos de efectivo de actividades de operación: {FormatearMoneda(flujoOperacion)}";
         Console.WriteLine(flujoOpLinea);
         resultado.AppendLine(flujoOpLinea);
         resultado.AppendLine();

         // ===== B. ACTIVIDADES DE INVERSIÓN =====
         resultado.AppendLine("B. ACTIVIDADES DE INVERSIÓN");
         resultado.AppendLine(new string('-', 60));
         MostrarTituloSubrayado("B. ACTIVIDADES DE INVERSIÓN", true, true);

         foreach (var item in cuentas.Where(c => c.TipoActividad == "AI"))
         {
            int variacion = item.Valor2015 - item.Valor2014;
            int efecto = 0;

            if (variacion > 0)
            {
               efecto = item.Cuenta.EsDeudora ? -Math.Abs(variacion) : variacion;
            }
            else if (variacion < 0)
            {
               efecto = item.Cuenta.EsDeudora ? Math.Abs(variacion) : -Math.Abs(variacion);
            }

            flujoInversion += efecto;

            string linea = $"{item.Cuenta.Nombre,-45} {FormatearMoneda(efecto)}";
            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         Console.WriteLine(new string('-', 60));
         resultado.AppendLine(new string('-', 60));
         string flujoInvLinea = $"Flujos netos de efectivo de actividades de inversión: {FormatearMoneda(flujoInversion)}";
         Console.WriteLine(flujoInvLinea);
         resultado.AppendLine(flujoInvLinea);
         resultado.AppendLine();

         // Efectivo excedente o a obtener
         int efectivoExcedente = flujoOperacion + flujoInversion;
         string lineaExcedente = efectivoExcedente >= 0
            ? $"Efectivo excedente para aplicar en actividades de financiamiento: {FormatearMoneda(efectivoExcedente)}"
            : $"Efectivo a obtener de actividades de financiamiento: {FormatearMoneda(Math.Abs(efectivoExcedente))}";
         Console.WriteLine(lineaExcedente);
         resultado.AppendLine(lineaExcedente);
         resultado.AppendLine();

         // ===== C. ACTIVIDADES DE FINANCIAMIENTO =====
         resultado.AppendLine("C. ACTIVIDADES DE FINANCIAMIENTO");
         resultado.AppendLine(new string('-', 60));
         MostrarTituloSubrayado("C. ACTIVIDADES DE FINANCIAMIENTO", true, true);

         foreach (var item in cuentas.Where(c => c.TipoActividad == "AF"))
         {
            int variacion = item.Valor2015 - item.Valor2014;
            int efecto = 0;

            if (variacion > 0)
            {
               efecto = item.Cuenta.EsDeudora ? -Math.Abs(variacion) : variacion;
            }
            else if (variacion < 0)
            {
               efecto = item.Cuenta.EsDeudora ? Math.Abs(variacion) : -Math.Abs(variacion);
            }

            flujoFinanciamiento += efecto;

            string linea = $"{item.Cuenta.Nombre,-45} {FormatearMoneda(efecto)}";
            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         Console.WriteLine(new string('-', 60));
         resultado.AppendLine(new string('-', 60));
         string flujoFinLinea = $"Flujos netos de efectivo de actividades de financiamiento: {FormatearMoneda(flujoFinanciamiento)}";
         Console.WriteLine(flujoFinLinea);
         resultado.AppendLine(flujoFinLinea);
         resultado.AppendLine();

         // ===== RESUMEN FINAL =====
         int flujoNeto = flujoOperacion + flujoInversion + flujoFinanciamiento;

         // Calcular saldo de efectivo del periodo anterior (necesitamos el saldo de Bancos 2014)
         var cuentaBancos = cuentas.FirstOrDefault(c => c.Cuenta.Nombre.Contains("Bancos"));
         int saldoPeriodoAnterior = cuentaBancos?.Valor2014 ?? 0;
         int saldoFinal = saldoPeriodoAnterior + flujoNeto;

         resultado.AppendLine("==============================================================");
         MostrarLineaDivisora(true, true);

         string tipoFlujo = flujoNeto >= 0 ? "Incremento" : "Disminución";
         string lineaFlujoNeto = $"{tipoFlujo} neto de efectivo y equivalentes de efectivo: {FormatearMoneda(flujoNeto)}";
         Console.WriteLine(lineaFlujoNeto);
         resultado.AppendLine(lineaFlujoNeto);

         string lineaSaldoAnterior = $"Efectivo y equivalentes de efectivo al principio del período: {FormatearMoneda(saldoPeriodoAnterior)}";
         Console.WriteLine(lineaSaldoAnterior);
         resultado.AppendLine(lineaSaldoAnterior);

         string lineaSaldoFinal = $"Efectivo y equivalentes de efectivo al final del período: {FormatearMoneda(saldoFinal)}";
         Console.WriteLine(lineaSaldoFinal);
         resultado.AppendLine(lineaSaldoFinal);

         resultado.AppendLine();
         resultado.AppendLine("==============================================================");
      }

      // Función auxiliar para formatear sin el prefijo "NIO" (para tablas)
      private static string FormatearMonedaSinPrefijo(int valor)
      {
         return $"C$ {valor:N2}";
      }

      // Función auxiliar para formatear con prefijo completo NIO C$
      private static string FormatearMoneda(int valor)
      {
         return $"NIO C$ {valor:N2}";
      }
   }
}