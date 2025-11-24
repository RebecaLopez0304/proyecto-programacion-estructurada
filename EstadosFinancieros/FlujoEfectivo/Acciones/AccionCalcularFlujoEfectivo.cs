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
      // MARK: - Estructura de Datos

      // Estructura para almacenar datos de una cuenta con valores de 2 años
      private class CuentaConValores
      {
         public Cuenta Cuenta { get; set; } = null!;
         public int Valor2014 { get; set; }
         public int Valor2015 { get; set; }
         public string TipoActividad { get; set; } = string.Empty;
         public string TipoGrupo { get; set; } = string.Empty; // Activo, Pasivo o Capital
      }

      // MARK: - Método Principal

      public static void Ejecutar()
      {
         MostrarLineaDivisoraConTexto("Calcular Flujo de Efectivo", true, true);

         // MARK: Solicitud de Datos Iniciales

         // Solicitar datos de la empresa
         Console.Write("Ingrese el nombre de la empresa: ");
         string nombreEmpresa = SolicitarString();

         // Solicitar año 1 y año 2 con validación
         Console.WriteLine();
         Console.Write("Ingrese el primer año (ej. 2014): ");
         int anio1 = SolicitarAnio();

         Console.Write("Ingrese el segundo año (ej. 2015): ");
         int anio2 = SolicitarAnio();

         // Validar que el segundo año sea posterior al primero
         while (anio2 <= anio1)
         {
            MostrarMensajeError("El segundo año debe ser posterior al primer año (no pueden ser iguales).", true, false);
            Console.Write($"Ingrese un año posterior a {anio1}: ");
            anio2 = SolicitarAnio();
         }

         // Solicitar utilidad ANTES de impuestos y depreciación (siempre van primero en AO)
         Console.WriteLine();
         MostrarTituloSubrayado("Datos iniciales para Actividades de Operación", true, true);

         Console.Write("Ingrese la Utilidad ANTES de impuestos a la utilidad: ");
         int utilidadAntesImpuestos = SolicitarEntero();

         Console.Write("Ingrese el total de Depreciaciones y Amortizaciones del período: ");
         int depreciacionesAmortizaciones = SolicitarEntero();

         // Solicitar saldo inicial de efectivo
         Console.WriteLine();
         Console.Write($"Ingrese el saldo de efectivo al inicio del período ({anio1}): ");
         int saldoInicial = SolicitarEnteroNoNegativo();

         // MARK: Selección de Cuentas por Actividad

         // Guardar las cuentas seleccionadas con sus valores para ambos años
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

            // Validar que la cuenta no haya sido agregada anteriormente
            if (cuentasConValores.Any(c => c.Cuenta.Nombre == cuentaSeleccionada.Nombre))
            {
               MostrarMensajeAdvertencia($"La cuenta '{cuentaSeleccionada.Nombre}' ya fue agregada anteriormente.", true, false);
               EsperarTecla();
               continue;
            }

            // Solicitamos los valores según el tipo de actividad
            // Para Actividades de Operación: solo pedimos el MONTO del movimiento (no saldos)
            // Para Inversión y Financiamiento: el valor representa el monto de la transacción

            int valor2014 = 0;
            int valor2015 = 0;

            if (actividad == 1) // Actividades de Operación
            {
               Console.WriteLine($"\nNota: Ingrese el MONTO del movimiento para '{cuentaSeleccionada.Nombre}'");
               Console.Write($"Monto del movimiento: ");
               valor2015 = SolicitarEnteroNoNegativo(); // Solo pedimos un valor
               valor2014 = 0; // No hay saldo anterior en movimientos
            }
            else // Actividades de Inversión y Financiamiento
            {
               Console.WriteLine($"\nNota: Ingrese el MONTO de la transacción para '{cuentaSeleccionada.Nombre}'");
               Console.Write($"Monto de la transacción: ");
               valor2015 = SolicitarEnteroNoNegativo();
               valor2014 = 0;
            }

            // Validar que la cuenta tenga clasificación de Balance General
            if (string.IsNullOrEmpty(cuentaSeleccionada.TipoGrupoBalance))
            {
               MostrarMensajeError($"ERROR: La cuenta '{cuentaSeleccionada.Nombre}' no tiene clasificación de Balance General asignada.", true, false);
               EsperarTecla();
               continue;
            }

            // Agregamos la cuenta con sus valores (la clasificación ya viene preestablecida)
            cuentasConValores.Add(new CuentaConValores
            {
               Cuenta = cuentaSeleccionada,
               Valor2014 = valor2014,
               Valor2015 = valor2015,
               TipoActividad = tipoActividad,
               TipoGrupo = cuentaSeleccionada.TipoGrupoBalance // Usamos la clasificación preestablecida
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

         // MARK: Generación de Reportes

         // ===== GENERAR AMBOS REPORTES =====
         var resultado = new StringBuilder();

         // ===== REPORTE 1: TABLA DE VARIACIONES =====
         GenerarTablaVariaciones(cuentasConValores, utilidadAntesImpuestos, depreciacionesAmortizaciones, anio1, anio2, nombreEmpresa, resultado);

         Console.WriteLine("\n\n");

         // ===== REPORTE 2: FLUJO DE EFECTIVO FORMATO CLÁSICO =====
         GenerarFlujoEfectivoClasico(cuentasConValores, utilidadAntesImpuestos, depreciacionesAmortizaciones, anio1, anio2, saldoInicial, nombreEmpresa, resultado);

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

      // MARK: Tabla de Variaciones

      private static void GenerarTablaVariaciones(List<CuentaConValores> cuentas, int utilidadAntesImpuestos, int depreciacionesAmortizaciones, int anio1, int anio2, string nombreEmpresa, StringBuilder resultado)
      {
         MostrarLineaDivisoraConTexto("Tabla de Variaciones - Flujo de Efectivo", true, true);

         resultado.AppendLine("==============================================================");
         resultado.AppendLine($"                    {nombreEmpresa.ToUpper()}");
         resultado.AppendLine("              FLUJO DE EFECTIVO - TABLA DE VARIACIONES");
         resultado.AppendLine($"                Del año {anio1} al {anio2}");
         resultado.AppendLine($"          (Expresado en Córdobas - NIO C$)");
         resultado.AppendLine("==============================================================");
         resultado.AppendLine();

         // Encabezados de la tabla (simplificados ya que no usamos años ni variaciones)
         string encabezado = string.Format("{0,-50} {1,15} {2,15} {3,15}",
            "Cuentas", "Efecto Neto en el Efectivo", "", "Clasificación");
         string subEncabezado = string.Format("{0,-50} {1,15} {2,15} {3,15}",
            "", "Entrada", "Salida", "");

         Console.WriteLine(encabezado);
         resultado.AppendLine(encabezado);
         Console.WriteLine(subEncabezado);
         resultado.AppendLine(subEncabezado);
         Console.WriteLine(new string('-', 100));
         resultado.AppendLine(new string('-', 100));

         // MARK: Cálculo de Totales por Grupo

         // Variables para totales generales
         int totalEntradas = 0;
         int totalSalidas = 0;

         // Función auxiliar para procesar un grupo de cuentas
         void ProcesarGrupo(string nombreGrupo, List<CuentaConValores> cuentasGrupo)
         {
            if (cuentasGrupo.Count == 0) return;

            int subtotalEntradas = 0;
            int subtotalSalidas = 0;

            foreach (var cuentaConValores in cuentasGrupo.OrderBy(c => c.Cuenta.Nombre))
            {
               // Para todas las cuentas: Valor2015 contiene el monto del movimiento
               // EsDeudora indica si es entrada (+) o salida (-)
               int entrada = 0;
               int salida = 0;

               if (cuentaConValores.Valor2015 > 0)
               {
                  if (cuentaConValores.Cuenta.EsDeudora)
                  {
                     entrada = cuentaConValores.Valor2015;
                     subtotalEntradas += entrada;
                     totalEntradas += entrada;
                  }
                  else
                  {
                     salida = cuentaConValores.Valor2015;
                     subtotalSalidas += salida;
                     totalSalidas += salida;
                  }
               }

               string linea = string.Format("{0,-50} {1,15} {2,15} {3,15}",
                  cuentaConValores.Cuenta.Nombre,
                  entrada > 0 ? FormatearMonedaSinPrefijo(entrada) : "",
                  salida > 0 ? FormatearMonedaSinPrefijo(salida) : "",
                  cuentaConValores.TipoActividad);

               Console.WriteLine(linea);
               resultado.AppendLine(linea);
            }

            // Subtotal del grupo
            string lineaSubtotal = string.Format("{0,-50} {1,15} {2,15} {3,15}",
               $"Total de {nombreGrupo}",
               subtotalEntradas > 0 ? FormatearMonedaSinPrefijo(subtotalEntradas) : "",
               subtotalSalidas > 0 ? FormatearMonedaSinPrefijo(subtotalSalidas) : "",
               "");

            Console.WriteLine(lineaSubtotal);
            resultado.AppendLine(lineaSubtotal);
            Console.WriteLine();
            resultado.AppendLine();
         }

         // Agregar cuentas especiales al inicio (si las hay)
         string lineaUtilidad = string.Format("{0,-50} {1,15} {2,15} {3,15}",
            "Utilidad antes de impuestos",
            FormatearMonedaSinPrefijo(utilidadAntesImpuestos), "", "AO");
         Console.WriteLine(lineaUtilidad);
         resultado.AppendLine(lineaUtilidad);
         totalEntradas += utilidadAntesImpuestos;

         string lineaDepreciacion = string.Format("{0,-50} {1,15} {2,15} {3,15}",
            "Depreciaciones y Amortizaciones",
            FormatearMonedaSinPrefijo(depreciacionesAmortizaciones), "", "AO");
         Console.WriteLine(lineaDepreciacion);
         resultado.AppendLine(lineaDepreciacion);
         Console.WriteLine();
         resultado.AppendLine();
         totalEntradas += depreciacionesAmortizaciones;

         // Agrupar y procesar por Activo, Pasivo y Capital
         var cuentasActivo = cuentas.Where(c => c.TipoGrupo == "Activo").ToList();
         var cuentasPasivo = cuentas.Where(c => c.TipoGrupo == "Pasivo").ToList();
         var cuentasCapital = cuentas.Where(c => c.TipoGrupo == "Capital").ToList();

         ProcesarGrupo("Activo", cuentasActivo);
         ProcesarGrupo("Pasivo", cuentasPasivo);
         ProcesarGrupo("Capital Contable", cuentasCapital);

         // Línea de totales generales
         Console.WriteLine(new string('-', 100));
         resultado.AppendLine(new string('-', 100));

         string lineaTotal = string.Format("{0,-50} {1,15} {2,15} {3,15}",
            "TOTALES",
            FormatearMonedaSinPrefijo(totalEntradas),
            FormatearMonedaSinPrefijo(totalSalidas), "");

         Console.WriteLine(lineaTotal);
         resultado.AppendLine(lineaTotal);

         Console.WriteLine(new string('=', 100));
         resultado.AppendLine(new string('=', 100));
         resultado.AppendLine();
      }

      // MARK: - Flujo de Efectivo Clásico

      private static void GenerarFlujoEfectivoClasico(List<CuentaConValores> cuentas, int utilidadAntesImpuestos, int depreciacionesAmortizaciones, int anio1, int anio2, int saldoInicial, string nombreEmpresa, StringBuilder resultado)
      {
         MostrarLineaDivisoraConTexto("Estado de Flujo de Efectivo", true, true);

         resultado.AppendLine("==============================================================");
         resultado.AppendLine($"                    {nombreEmpresa.ToUpper()}");
         resultado.AppendLine("                ESTADO DE FLUJO DE EFECTIVO");
         resultado.AppendLine($"                Del año {anio1} al {anio2}");
         resultado.AppendLine($"          (Expresado en Córdobas - NIO C$)");
         resultado.AppendLine("==============================================================");
         resultado.AppendLine();

         int flujoOperacion = utilidadAntesImpuestos + depreciacionesAmortizaciones;
         int flujoInversion = 0;
         int flujoFinanciamiento = 0;

         // MARK: Actividades de Operación

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
         foreach (var cuentaOperacion in cuentas.Where(c => c.TipoActividad == "AO"))
         {
            // Para cuentas de operación, Valor2015 contiene el monto del movimiento
            // EsDeudora indica si es entrada (+) o salida (-)
            int efecto = cuentaOperacion.Cuenta.EsDeudora ? cuentaOperacion.Valor2015 : -cuentaOperacion.Valor2015;

            flujoOperacion += efecto;

            string linea = $"{cuentaOperacion.Cuenta.Nombre,-45} {FormatearMoneda(efecto)}";
            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         Console.WriteLine(new string('-', 60));
         resultado.AppendLine(new string('-', 60));
         string flujoOpLinea = $"Flujos netos de efectivo de actividades de operación: {FormatearMoneda(flujoOperacion)}";
         Console.WriteLine(flujoOpLinea);
         resultado.AppendLine(flujoOpLinea);
         resultado.AppendLine();

         // MARK: Actividades de Inversión

         // ===== B. ACTIVIDADES DE INVERSIÓN =====
         resultado.AppendLine("B. ACTIVIDADES DE INVERSIÓN");
         resultado.AppendLine(new string('-', 60));
         MostrarTituloSubrayado("B. ACTIVIDADES DE INVERSIÓN", true, true);

         foreach (var cuentaInversion in cuentas.Where(c => c.TipoActividad == "AI"))
         {
            // EsDeudora indica si es entrada (+) o salida (-)
            int efecto = cuentaInversion.Cuenta.EsDeudora ? cuentaInversion.Valor2015 : -cuentaInversion.Valor2015;

            flujoInversion += efecto;

            string linea = $"{cuentaInversion.Cuenta.Nombre,-45} {FormatearMoneda(efecto)}";
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

         // MARK: Actividades de Financiamiento

         // ===== C. ACTIVIDADES DE FINANCIAMIENTO =====
         resultado.AppendLine("C. ACTIVIDADES DE FINANCIAMIENTO");
         resultado.AppendLine(new string('-', 60));
         MostrarTituloSubrayado("C. ACTIVIDADES DE FINANCIAMIENTO", true, true);

         foreach (var cuentaFinanciamiento in cuentas.Where(c => c.TipoActividad == "AF"))
         {
            // EsDeudora indica si es entrada (+) o salida (-)
            int efecto = cuentaFinanciamiento.Cuenta.EsDeudora ? cuentaFinanciamiento.Valor2015 : -cuentaFinanciamiento.Valor2015;

            flujoFinanciamiento += efecto;

            string linea = $"{cuentaFinanciamiento.Cuenta.Nombre,-45} {FormatearMoneda(efecto)}";
            Console.WriteLine(linea);
            resultado.AppendLine(linea);
         }

         Console.WriteLine(new string('-', 60));
         resultado.AppendLine(new string('-', 60));
         string flujoFinLinea = $"Flujos netos de efectivo de actividades de financiamiento: {FormatearMoneda(flujoFinanciamiento)}";
         Console.WriteLine(flujoFinLinea);
         resultado.AppendLine(flujoFinLinea);
         resultado.AppendLine();

         // MARK: Resumen Final del Flujo

         // ===== RESUMEN FINAL =====
         int flujoNeto = flujoOperacion + flujoInversion + flujoFinanciamiento;

         resultado.AppendLine("==============================================================");
         MostrarLineaDivisora(true, true);

         string tipoFlujo = flujoNeto >= 0 ? "Incremento" : "Disminución";
         string lineaFlujoNeto = $"{tipoFlujo} neto de efectivo y equivalentes de efectivo: {FormatearMoneda(flujoNeto)}";
         Console.WriteLine(lineaFlujoNeto);
         resultado.AppendLine(lineaFlujoNeto);

         string lineaSaldoInicial = $"Efectivo y equivalentes de efectivo al principio del período: {FormatearMoneda(saldoInicial)}";
         Console.WriteLine(lineaSaldoInicial);
         resultado.AppendLine(lineaSaldoInicial);

         int saldoFinal = saldoInicial + flujoNeto;
         string lineaSaldoFinal = $"Efectivo y equivalentes de efectivo al final del período: {FormatearMoneda(saldoFinal)}";
         Console.WriteLine(lineaSaldoFinal);
         resultado.AppendLine(lineaSaldoFinal); resultado.AppendLine();
         resultado.AppendLine("==============================================================");
      }

      // MARK: - Funciones de Formato

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