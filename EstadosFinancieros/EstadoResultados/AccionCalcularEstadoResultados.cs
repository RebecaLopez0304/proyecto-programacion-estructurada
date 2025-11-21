// Importa utilidades generales del proyecto
using ProyectoProgramacion.Comunes;
// Permite usar métodos de Utilidades sin prefijo
using static ProyectoProgramacion.Comunes.Utilidades;
// Importa menús específicos para pedir categorías y opciones
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.MenusEstadoResultados;
// Para construir texto de salida (StringBuilder)
using System.Text;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    /*
    ===========================
        Acción Calcular Estado de Resultados
    ===========================
    
    TODO: Implementar el cálculo interactivo del Estado de Resultados
    Seguir el patrón de AccionCalcularBalanceGeneral.cs pero con la lógica específica del Estado de Resultados
    
    Estructura del cálculo:
    
    1. VENTAS NETAS
       - Solicitar cuentas de Ingresos interactivamente
       - Calcular: Ventas Totales - Devoluciones - Descuentos - Bonificaciones = VENTAS NETAS
    
    2. UTILIDAD BRUTA
       - Solicitar cuentas de Costo de Ventas
       - Calcular: Ventas Netas - Costo de Ventas = UTILIDAD BRUTA
    
    3. UTILIDAD DE OPERACIÓN
       - Solicitar Gastos de Venta
       - Solicitar Gastos de Administración
       - Calcular: Utilidad Bruta - Gastos de Operación = UTILIDAD DE OPERACIÓN
    
    4. UTILIDAD ANTES DE OTROS GASTOS Y PRODUCTOS
       - Solicitar Gastos Financieros
       - Solicitar Productos Financieros
       - Calcular: Utilidad Operación + Productos Financieros - Gastos Financieros
    
    5. UTILIDAD ANTES DE IMPUESTOS
       - Solicitar Otros Gastos
       - Solicitar Otros Productos
       - Calcular: Utilidad anterior + Otros Productos - Otros Gastos
    
    6. UTILIDAD NETA
       - Solicitar Impuestos (ISR, PTU)
       - Calcular: Utilidad antes de impuestos - Impuestos = UTILIDAD NETA
    
    Flujo del programa:
    1. Crear List<(Cuenta cuenta, int valor)> para almacenar cuentas seleccionadas
    2. Loop para cada categoría usando MostrarMenuCategoriasConSalida()
    3. Para cada cuenta seleccionada: solicitar valor int
    4. Permitir agregar múltiples cuentas con MostrarMenuContinuar()
    5. Calcular totales por sección
    6. Mostrar resultado formateado con totales parciales y UTILIDAD NETA final
    
    IMPORTANTE:
    - Respetar naturaleza de las cuentas (Deudora suma, Acreedora resta)
    - Mostrar totales parciales de cada sección
    - Formato: usar MostrarTituloSubrayado() para secciones
    - Al final mostrar si hubo utilidad (positivo) o pérdida (negativo)
    
    GUARDADO DE RESULTADOS:
    - Usar StringBuilder para construir el contenido del archivo
    - Agregar fecha y hora al inicio del documento
    - Incluir todos los cálculos y totales en el contenido
    - Al final preguntar: if (PreguntarSiGuardarResultado())
    - Guardar con: GuardarResultadoEnArchivo("estado-resultados", resultado.ToString())
    - Mostrar mensaje de éxito con la ruta del archivo guardado
    - El archivo se guardará como: estado-resultados-1.txt, estado-resultados-2.txt, etc.
    */
    public static class AccionCalcularEstadoResultados
    {
        public static void Ejecutar()
        {
            MostrarLineaDivisoraConTexto("Calcular Estado de Resultados", true, true);

            // guardar las cuentas seleccionadas con sus montos
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
                      1 => "Ingresos (Ventas)",
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
                    string naturaleza = listaCuentas[i].EsDeudora ? "[Deudora  ]" : "[Acreedora]";
                    Console.WriteLine($"{i + 1}. {naturaleza} {listaCuentas[i].Nombre}");
                }
                MostrarLineaDivisora(true, true);

                Console.WriteLine($"Seleccione la cuenta (1-{listaCuentas.Count}):");
                int indiceCuenta = SolicitarEnteroConLimites(1, listaCuentas.Count) - 1;

                Cuenta cuentaSeleccionada = listaCuentas[indiceCuenta];

                // Solicitamos el valor numérico para la cuenta seleccionada
                Console.WriteLine($"Ingrese el valor para '{cuentaSeleccionada.Nombre}': $");
                int valor = SolicitarEntero();

                
                // Agregamos la pareja (cuenta, valor) a la lista de cálculo
                cuentasSeleccionadas.Add((cuentaSeleccionada, valor));

                MostrarMensajeExito($"Cuenta '{cuentaSeleccionada.Nombre}' agregada con valor ${valor:N2}", true, false);

                // Preguntamos si desea continuar agregando cuentas
                int opcion = MostrarMenuContinuar();

                if (opcion == 2)
                {
                    continuar = false;
                }
                
                 // Creamos el reporte en pantalla y en memoria
                MostrarLineaDivisoraConTexto("Resultado del Balance General", true, true);

                var resultado = new StringBuilder();
                resultado.AppendLine("==============================================================");
                resultado.AppendLine("                    ESTADO DE RESULTADOS");
                resultado.AppendLine($"                    {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                resultado.AppendLine("==============================================================");
                resultado.AppendLine();
                
                
                int Ventas = 0;
                int CostoDeVentas  = 0;
                 int GastoDeOperacion = 0;
                int GastosAdministracion = 0;
                int OtrosResultadosFinancieros = 0;

                  // Calculamos y mostramos los VENTAS
                resultado.AppendLine("VENTAS");
                resultado.AppendLine(new string('-', 60));
                MostrarTituloSubrayado("VENTAS", true, true);

                foreach (var item in cuentasSeleccionadas.Where(x => x.cuenta.EsDeudora &&
                (CuentasEstadoResultados.Ventas.Contains(x.cuenta) ||
                 CuentasEstadoResultados.CostoDeVentas.Contains(x.cuenta) ||
                 CuentasEstadoResultados.GastoDeOperacion.Contains(x.cuenta) ||
                 CuentasEstadoResultados.GastosAdministracion.Contains(x.cuenta)) ||
                    CuentasEstadoResultados.OtrosResultadosFinancieros.Contains(x.cuenta)))
                {
                     int valorConSigno = item.cuenta.EsDeudora ? item.valor : -item.valor;
                    Ventas += valorConSigno;
                     string linea = $"  {item.cuenta.Nombre}: ${item.valor:N2}";
                    Console.WriteLine(linea);
                    resultado.AppendLine(linea);
                }

                string totalVentasLinea = $"TOTAL VENTAS: ${Ventas:N2}";
                 Console.WriteLine(totalVentasLinea);
                resultado.AppendLine(totalVentasLinea);
                resultado.AppendLine();

                // Calculamos y mostramos el COSTO DE VENTAS
                resultado.AppendLine("COSTO DE VENTAS");
             resultado.AppendLine(new string('-', 60));
             MostrarTituloSubrayado("COSTO DE VENTAS", true, true);
             foreach (var item in cuentasSeleccionadas.Where(x => !x.cuenta.EsDeudora &&
                (CuentasEstadoResultados.CostoDeVentas.Contains(x.cuenta) ||
                 CuentasEstadoResultados.CostoDeVentas.Contains(x.cuenta))))
                {
                    int valorConSigno = item.cuenta.EsDeudora ? item.valor : item.valor;
                     CostoDeVentas += valorConSigno;
                    string linea = $"  {item.cuenta.Nombre}: ${item.valor:N2}";
                    Console.WriteLine(linea);
                    resultado.AppendLine(linea);
                }

                 string totalCostoDeVentasLinea = $"TOTAL COSTO DE VENTAS: ${CostoDeVentas:N2}";
                 Console.WriteLine(totalCostoDeVentasLinea);
                 resultado.AppendLine(totalCostoDeVentasLinea);
                resultado.AppendLine();

                // Calculamos y mostramos el GASTO DE OPERACION
                 resultado.AppendLine("GASTOS DE OPERACIÓN");
                resultado.AppendLine(new string('-', 60));
                MostrarTituloSubrayado("GASTOS DE OPERACIÓN", true, true);
                foreach (var item in cuentasSeleccionadas.Where(x =>
                CuentasEstadoResultados.GastoDeOperacion.Contains(x.cuenta) ||
                CuentasEstadoResultados.GastoDeOperacion.Contains(x.cuenta)))
                {
                    int valorConSigno = item.cuenta.EsDeudora ? item.valor : item.valor;
                    GastoDeOperacion += valorConSigno;
                    string linea = $"  {item.cuenta.Nombre}: ${item.valor:N2}";
                    Console.WriteLine(linea);
                    resultado.AppendLine(linea);
                }

                string totalGastoDeOperacionLinea = $"TOTAL GASTOS DE OPERACIÓN: ${GastoDeOperacion:N2}";
                Console.WriteLine(totalGastoDeOperacionLinea);
                resultado.AppendLine(totalGastoDeOperacionLinea);
                resultado.AppendLine();

                // Calculamos y mostramos los GASTOS DE ADMINISTRACION
                resultado.AppendLine("GASTOS DE ADMINISTRACIÓN");
                resultado.AppendLine(new string('-', 60));
                MostrarTituloSubrayado("GASTOS DE ADMINISTRACIÓN", true, true);
                foreach (var item in cuentasSeleccionadas.Where(x =>
                CuentasEstadoResultados.GastosAdministracion.Contains(x.cuenta) ||  
                CuentasEstadoResultados.GastosAdministracion.Contains(x.cuenta)))
                {
                    int valorConSigno = item.cuenta.EsDeudora ? item.valor : item.valor;
                    GastosAdministracion += valorConSigno;
                    string linea = $"  {item.cuenta.Nombre}: ${item.valor:N2}";
                    Console.WriteLine(linea);
                    resultado.AppendLine(linea);
                }
                string totalGastosAdministracionLinea = $"TOTAL GASTOS DE ADMINISTRACIÓN: ${GastosAdministracion:N2}";
              Console.WriteLine(totalGastosAdministracionLinea);
                resultado.AppendLine(totalGastosAdministracionLinea);
                resultado.AppendLine();

                // Calculamos y mostramos los OTROS RESULTADOS FINANCIEROS
                resultado.AppendLine("OTROS RESULTADOS FINANCIEROS");
                resultado.AppendLine(new string('-', 60));
                MostrarTituloSubrayado("OTROS RESULTADOS FINANCIEROS", true,    false);
                foreach (var item in cuentasSeleccionadas.Where(x =>
                CuentasEstadoResultados.OtrosResultadosFinancieros.Contains(x.cuenta) ||
                CuentasEstadoResultados.OtrosResultadosFinancieros.Contains(x.cuenta)))
            {
                int valorConSigno = item.cuenta.EsDeudora ? item.valor : item.valor;
                OtrosResultadosFinancieros += valorConSigno;
                string linea = $"  {item.cuenta.Nombre}: ${item.valor:N2}";
                Console.WriteLine(linea);
                resultado.AppendLine(linea);
            }
                string totalOtrosResultadosFinancierosLinea = $"TOTAL OTROS RESULTADOS FINANCIEROS: ${OtrosResultadosFinancieros:N2}";
                Console.WriteLine(totalOtrosResultadosFinancierosLinea);
                resultado.AppendLine(totalOtrosResultadosFinancierosLinea);
                 resultado.AppendLine();


                 
            // Comprobamos la ecuación contable
            int RESULTADO = Ventas - (CostoDeVentas + GastoDeOperacion + GastosAdministracion + OtrosResultadosFinancieros);

            resultado.AppendLine("==============================================================");
            resultado.AppendLine("                    ECUACION CONTABLE");
            resultado.AppendLine("==============================================================");
            MostrarLineaDivisoraConTexto("Ecuacion Contable", true, true);
            
            // string activosLinea = $"Activos           : ${totalActivos:N2}";
            // string pasivoCapitalLinea = $"Pasivos + Capital : ${totalPasivoMasCapital:N2}";
            // Console.WriteLine(activosLinea);
            // Console.WriteLine(pasivoCapitalLinea);
            // resultado.AppendLine(activosLinea);
            // resultado.AppendLine(pasivoCapitalLinea);
            MostrarLineaDivisora(true, false);
            resultado.AppendLine(new string('-', 60));

             }

              // Si no hay cuentas, avisamos y salimos
            if (cuentasSeleccionadas.Count == 0)
            {
                MostrarMensajeAdvertencia("No se agregaron cuentas al calculo.", true, false);
                EsperarTecla();
                return;
            }
            
            
            // TODO: Implementar toda la lógica de cálculo del Estado de Resultados
            // Esta es la parte más compleja - requiere:
            // - Selección interactiva de cuentas por categoría
            // - Cálculo de subtotales (Utilidad Bruta, Utilidad Operación, etc.)
            // - Aplicación correcta de naturaleza de cuentas
            // - Formato de presentación claro mostrando cada paso del cálculo
            
            MostrarMensajeAdvertencia("Esta funcionalidad aun no esta implementada.", true, true);
            MostrarMensajeAdvertencia("Debe calcular: Ventas Netas -> Utilidad Bruta -> Utilidad Operacion -> Utilidad Neta", true, false);
            EsperarTecla();
        }
    }
}
