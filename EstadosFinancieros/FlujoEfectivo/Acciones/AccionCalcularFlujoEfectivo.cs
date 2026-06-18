using System.Text;
using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.FlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones;

/// <summary>
/// Pide al usuario movimientos de efectivo por actividad (Operación, Inversión,
/// Financiamiento) y genera dos reportes: una tabla de variaciones y el estado de
/// flujo de efectivo en formato clásico.
/// </summary>
public static class AccionCalcularFlujoEfectivo
{
    #region Tipo de apoyo

    /// <summary>Una cuenta elegida por el usuario con el monto de su movimiento y su actividad ("AO", "AI", "AF").</summary>
    private class Movimiento
    {
        public Cuenta Cuenta { get; }
        public int Monto { get; }
        public string Actividad { get; }

        public Movimiento(Cuenta cuenta, int monto, string actividad)
        {
            Cuenta = cuenta;
            Monto = monto;
            Actividad = actividad;
        }

        /// <summary>Grupo del Balance General de la cuenta ("Activo", "Pasivo" o "Capital").</summary>
        public string Grupo
        {
            get { return Cuenta.TipoGrupoBalance; }
        }

        /// <summary>Efecto en el efectivo: positivo si es entrada (deudora), negativo si es salida (acreedora).</summary>
        public int Efecto
        {
            get { return Cuenta.ValorConSigno(Monto); }
        }
    }

    #endregion

    #region Flujo principal

    public static void Ejecutar()
    {
        MostrarLineaDivisoraConTexto("Calcular Flujo de Efectivo", true, true);

        Console.Write("Ingrese el nombre de la empresa: ");
        string nombreEmpresa = SolicitarString();

        Console.WriteLine();
        Console.Write("Ingrese el primer año (ej. 2014): ");
        int anio1 = SolicitarAnio();
        int anio2 = SolicitarSegundoAnio(anio1);

        MostrarTituloSubrayado("Datos iniciales para Actividades de Operación", true, true);
        Console.Write("Ingrese la Utilidad ANTES de impuestos a la utilidad: ");
        int utilidadAntesImpuestos = SolicitarEntero();

        Console.Write("Ingrese el total de Depreciaciones y Amortizaciones del período: ");
        int depreciaciones = SolicitarEntero();

        Console.WriteLine();
        Console.Write($"Ingrese el saldo de efectivo al inicio del período ({anio1}): ");
        int saldoInicial = SolicitarEnteroNoNegativo();

        List<Movimiento> movimientos = SeleccionarMovimientos();

        if (movimientos.Count == 0)
        {
            MostrarMensajeAdvertencia("No se agregaron cuentas al calculo.", true, false);
            EsperarTecla();
            return;
        }

        StringBuilder reporte = new StringBuilder();
        GenerarTablaVariaciones(movimientos, utilidadAntesImpuestos, depreciaciones, anio1, anio2, nombreEmpresa, reporte);
        Console.WriteLine("\n\n");
        GenerarFlujoEfectivoClasico(movimientos, utilidadAntesImpuestos, depreciaciones, anio1, anio2, saldoInicial, nombreEmpresa, reporte);

        if (PreguntarSiGuardarResultado())
        {
            string ruta = GuardarResultadoEnArchivo("flujo-efectivo", reporte.ToString());
            MostrarMensajeExito($"Resultado guardado en: {ruta}", true, false);
        }

        EsperarTecla();
    }

    /// <summary>Pide el segundo año y exige que sea posterior al primero.</summary>
    private static int SolicitarSegundoAnio(int anio1)
    {
        Console.Write("Ingrese el segundo año (ej. 2015): ");
        int anio2 = SolicitarAnio();

        while (anio2 <= anio1)
        {
            MostrarMensajeError("El segundo año debe ser posterior al primer año.", true, false);
            Console.Write($"Ingrese un año posterior a {anio1}: ");
            anio2 = SolicitarAnio();
        }

        return anio2;
    }

    #endregion

    #region Selección de movimientos

    /// <summary>Permite al usuario elegir varias cuentas con el monto de su movimiento.</summary>
    private static List<Movimiento> SeleccionarMovimientos()
    {
        List<Movimiento> movimientos = new List<Movimiento>();
        ConfigCuentas config = Config;
        string[] codigos = { "AO", "AI", "AF" };
        bool continuar = true;

        while (continuar)
        {
            int actividad = AccionesCuentas.ElegirGrupoConSalida(config); // 0 = finalizar, 1-3 = actividad
            if (actividad == 0)
            {
                break;
            }

            var (nombreActividad, listaCuentas) = config.Catalogo[actividad - 1];
            Cuenta cuenta = AccionesCuentas.ElegirCuenta(nombreActividad, listaCuentas, config);

            // Revisamos si la cuenta ya fue agregada antes.
            bool yaAgregada = movimientos.Any(m => m.Cuenta.Nombre == cuenta.Nombre);

            if (yaAgregada)
            {
                MostrarMensajeAdvertencia($"La cuenta '{cuenta.Nombre}' ya fue agregada anteriormente.", true, false);
                EsperarTecla();
                continue;
            }

            Console.Write($"\nMonto del movimiento para '{cuenta.Nombre}': ");
            int monto = SolicitarEnteroNoNegativo();

            string codigoActividad = codigos[actividad - 1];
            movimientos.Add(new Movimiento(cuenta, monto, codigoActividad));
            MostrarMensajeExito($"Cuenta '{cuenta.Nombre}' agregada", true, false);

            continuar = AccionesCuentas.Continuar(config.Nombre);
        }

        return movimientos;
    }

    #endregion

    #region Reporte 1: Tabla de variaciones

    /// <summary>Genera una tabla con el efecto (entrada/salida) de cada cuenta, agrupado por Activo, Pasivo y Capital.</summary>
    private static void GenerarTablaVariaciones(List<Movimiento> movimientos, int utilidad, int depreciaciones,
        int anio1, int anio2, string nombreEmpresa, StringBuilder reporte)
    {
        MostrarLineaDivisoraConTexto("Tabla de Variaciones - Flujo de Efectivo", true, true);

        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine($"                    {nombreEmpresa.ToUpper()}");
        reporte.AppendLine("              FLUJO DE EFECTIVO - TABLA DE VARIACIONES");
        reporte.AppendLine($"                Del año {anio1} al {anio2}");
        reporte.AppendLine("          (Expresado en Córdobas - NIO C$)");
        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine();

        Linea(Fila("Cuentas", "Entrada", "Salida", "Clasificación"), reporte);
        Linea(new string('-', 100), reporte);

        int totalEntradas = utilidad + depreciaciones;
        int totalSalidas = 0;

        // Filas iniciales fijas de Actividades de Operación
        Linea(Fila("Utilidad antes de impuestos", FormatearMonedaSinPrefijo(utilidad), "", "AO"), reporte);
        Linea(Fila("Depreciaciones y Amortizaciones", FormatearMonedaSinPrefijo(depreciaciones), "", "AO"), reporte);
        Linea("", reporte);

        // Grupos por clasificación de Balance General
        ProcesarGrupo("Activo", movimientos.Where(m => m.Grupo == "Activo"), ref totalEntradas, ref totalSalidas, reporte);
        ProcesarGrupo("Pasivo", movimientos.Where(m => m.Grupo == "Pasivo"), ref totalEntradas, ref totalSalidas, reporte);
        ProcesarGrupo("Capital Contable", movimientos.Where(m => m.Grupo == "Capital"), ref totalEntradas, ref totalSalidas, reporte);

        Linea(new string('-', 100), reporte);
        Linea(Fila("TOTALES", FormatearMonedaSinPrefijo(totalEntradas), FormatearMonedaSinPrefijo(totalSalidas), ""), reporte);
        Linea(new string('=', 100), reporte);
        reporte.AppendLine();
    }

    /// <summary>Imprime las cuentas de un grupo con su entrada o salida y el subtotal del grupo.</summary>
    private static void ProcesarGrupo(string nombreGrupo, IEnumerable<Movimiento> grupo,
        ref int totalEntradas, ref int totalSalidas, StringBuilder reporte)
    {
        // Ordenamos las cuentas del grupo alfabéticamente por nombre.
        List<Movimiento> cuentas = grupo.OrderBy(movimiento => movimiento.Cuenta.Nombre).ToList();

        if (cuentas.Count == 0)
        {
            return;
        }

        int subEntradas = 0;
        int subSalidas = 0;

        foreach (Movimiento movimiento in cuentas)
        {
            string entrada = "";
            string salida = "";

            if (movimiento.Cuenta.EsDeudora)
            {
                // Una cuenta deudora representa una entrada de efectivo.
                subEntradas = subEntradas + movimiento.Monto;
                if (movimiento.Monto > 0)
                {
                    entrada = FormatearMonedaSinPrefijo(movimiento.Monto);
                }
            }
            else
            {
                // Una cuenta acreedora representa una salida de efectivo.
                subSalidas = subSalidas + movimiento.Monto;
                if (movimiento.Monto > 0)
                {
                    salida = FormatearMonedaSinPrefijo(movimiento.Monto);
                }
            }

            Linea(Fila(movimiento.Cuenta.Nombre, entrada, salida, movimiento.Actividad), reporte);
        }

        totalEntradas = totalEntradas + subEntradas;
        totalSalidas = totalSalidas + subSalidas;

        string subEntradasTexto = "";
        if (subEntradas > 0)
        {
            subEntradasTexto = FormatearMonedaSinPrefijo(subEntradas);
        }

        string subSalidasTexto = "";
        if (subSalidas > 0)
        {
            subSalidasTexto = FormatearMonedaSinPrefijo(subSalidas);
        }

        Linea(Fila($"Total de {nombreGrupo}", subEntradasTexto, subSalidasTexto, ""), reporte);
        Linea("", reporte);
    }

    /// <summary>Da formato a una fila de la tabla con columnas de ancho fijo.</summary>
    private static string Fila(string cuenta, string entrada, string salida, string clasificacion)
    {
        return string.Format("{0,-50} {1,15} {2,15} {3,15}", cuenta, entrada, salida, clasificacion);
    }

    #endregion

    #region Reporte 2: Flujo de efectivo clásico

    /// <summary>Genera el estado de flujo de efectivo agrupando por Operación, Inversión y Financiamiento.</summary>
    private static void GenerarFlujoEfectivoClasico(List<Movimiento> movimientos, int utilidad, int depreciaciones,
        int anio1, int anio2, int saldoInicial, string nombreEmpresa, StringBuilder reporte)
    {
        MostrarLineaDivisoraConTexto("Estado de Flujo de Efectivo", true, true);

        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine($"                    {nombreEmpresa.ToUpper()}");
        reporte.AppendLine("                ESTADO DE FLUJO DE EFECTIVO");
        reporte.AppendLine($"                Del año {anio1} al {anio2}");
        reporte.AppendLine("          (Expresado en Córdobas - NIO C$)");
        reporte.AppendLine(new string('=', 62));
        reporte.AppendLine();

        // A. Operación: parte de la utilidad + depreciaciones y suma el efecto de cada movimiento.
        MostrarTituloSubrayado("A. ACTIVIDADES DE OPERACIÓN", true, true);
        reporte.AppendLine("A. ACTIVIDADES DE OPERACIÓN");
        reporte.AppendLine(new string('-', 60));
        Linea($"{"Utilidad antes de impuestos a la utilidad",-45} {FormatearMoneda(utilidad)}", reporte);
        Linea($"{"Depreciaciones y Amortizaciones",-45} {FormatearMoneda(depreciaciones)}", reporte);
        int flujoOperacion = utilidad + depreciaciones + ImprimirActividad(movimientos, "AO", reporte);
        Linea(new string('-', 60), reporte);
        Linea($"Flujos netos de efectivo de actividades de operación: {FormatearMoneda(flujoOperacion)}", reporte);
        reporte.AppendLine();

        // B. Inversión
        MostrarTituloSubrayado("B. ACTIVIDADES DE INVERSIÓN", true, true);
        reporte.AppendLine("B. ACTIVIDADES DE INVERSIÓN");
        reporte.AppendLine(new string('-', 60));
        int flujoInversion = ImprimirActividad(movimientos, "AI", reporte);
        Linea(new string('-', 60), reporte);
        Linea($"Flujos netos de efectivo de actividades de inversión: {FormatearMoneda(flujoInversion)}", reporte);
        reporte.AppendLine();

        int excedente = flujoOperacion + flujoInversion;
        if (excedente >= 0)
        {
            Linea($"Efectivo excedente para aplicar en actividades de financiamiento: {FormatearMoneda(excedente)}", reporte);
        }
        else
        {
            Linea($"Efectivo a obtener de actividades de financiamiento: {FormatearMoneda(Math.Abs(excedente))}", reporte);
        }
        reporte.AppendLine();

        // C. Financiamiento
        MostrarTituloSubrayado("C. ACTIVIDADES DE FINANCIAMIENTO", true, true);
        reporte.AppendLine("C. ACTIVIDADES DE FINANCIAMIENTO");
        reporte.AppendLine(new string('-', 60));
        int flujoFinanciamiento = ImprimirActividad(movimientos, "AF", reporte);
        Linea(new string('-', 60), reporte);
        Linea($"Flujos netos de efectivo de actividades de financiamiento: {FormatearMoneda(flujoFinanciamiento)}", reporte);
        reporte.AppendLine();

        // Resumen final
        int flujoNeto = flujoOperacion + flujoInversion + flujoFinanciamiento;
        MostrarLineaDivisora(true, true);
        reporte.AppendLine(new string('=', 62));

        string tipoFlujo;
        if (flujoNeto >= 0)
        {
            tipoFlujo = "Incremento";
        }
        else
        {
            tipoFlujo = "Disminución";
        }

        int saldoFinal = saldoInicial + flujoNeto;
        Linea($"{tipoFlujo} neto de efectivo y equivalentes de efectivo: {FormatearMoneda(flujoNeto)}", reporte);
        Linea($"Efectivo y equivalentes de efectivo al principio del período: {FormatearMoneda(saldoInicial)}", reporte);
        Linea($"Efectivo y equivalentes de efectivo al final del período: {FormatearMoneda(saldoFinal)}", reporte);
        reporte.AppendLine();
        reporte.AppendLine(new string('=', 62));
    }

    /// <summary>Imprime las cuentas de una actividad y devuelve la suma de sus efectos en el efectivo.</summary>
    private static int ImprimirActividad(List<Movimiento> movimientos, string actividad, StringBuilder reporte)
    {
        int total = 0;
        foreach (Movimiento movimiento in movimientos.Where(m => m.Actividad == actividad))
        {
            total = total + movimiento.Efecto;
            Linea($"{movimiento.Cuenta.Nombre,-45} {FormatearMoneda(movimiento.Efecto)}", reporte);
        }
        return total;
    }

    #endregion

    #region Apoyo

    /// <summary>Escribe una línea tanto en pantalla como en el reporte de texto.</summary>
    private static void Linea(string texto, StringBuilder reporte)
    {
        Console.WriteLine(texto);
        reporte.AppendLine(texto);
    }

    #endregion
}
