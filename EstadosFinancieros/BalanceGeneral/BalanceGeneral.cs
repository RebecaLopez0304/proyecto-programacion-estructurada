using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.AccionesVerCuentas;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral
{
    /*
    ===========================
        Clase Balance General
    ===========================
    */
    public static class BalanceGeneral
    {
        public static void Ejecutar()
        {
            bool volver = false;

            while (!volver)
            {
                int opcion = MostrarMenu();

                switch (opcion)
                {
                    case 1:
                        VerCuentas();
                        break;
                    case 2:
                        AgregarCuenta();
                        break;
                    case 3:
                        EliminarCuenta();
                        break;
                    case 4:
                        CalcularBalanceGeneral();
                        break;
                    case 0:
                        volver = true;
                        Console.WriteLine("\nVolviendo al Menu Principal...\n");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }
        }

        private static int MostrarMenu()
        {
            MostrarLineaDivisoraConTexto("Menu Balance General", true, true);
            MostrarTituloSubrayado("Seleccione una opcion (0-4):", false, true);
            Console.WriteLine("1. Ver Cuentas");
            Console.WriteLine("2. Agregar Cuenta");
            Console.WriteLine("3. Eliminar Cuenta");
            MostrarLineaDivisora(false, true);
            Console.WriteLine("4. Realizar calculo de Balance General");
            VolverAtras();
            MostrarLineaDivisora(true, true);

            int opcion = SolicitarEnteroConLimites(0, 4);
            return opcion;
        }

        private static void VerCuentas()
        {
            bool regresar = false;

            while (!regresar)
            {
                MostrarTituloSubrayado("Ver Cuentas - Balance General", true, true);
                Console.WriteLine("1. Ver todas las cuentas");
                Console.WriteLine("2. Ver cuentas generales (Activos, Pasivos, Capital)");
                Console.WriteLine("3. Ver cuentas subclasificadas");
                MostrarLineaDivisora(true, true);
                VolverAtras();

                int opcion = SolicitarEnteroConLimites(0, 3);

                switch (opcion)
                {
                    case 1:
                        MostrarTodasCuentasBalanceGeneral();
                        break;
                    case 2:
                        MostrarCuentasGeneralesBalanceGeneral();
                        break;
                    case 3:
                        MostrarCuentasSubclasificadasBalanceGeneral();
                        break;
                    case 0:
                        regresar = true;
                        break;
                }
            }
        }

        private static void AgregarCuenta()
        {
            MostrarTituloSubrayado("Agregar Cuenta - Balance General", true, true);

            // Seleccionar categoria principal
            Console.WriteLine("Seleccione la categoria principal:");

            MostrarTituloSubrayado("Activos", false, true);
            Console.WriteLine("1. Activo Circulante");
            Console.WriteLine("2. Activo Fijo");
            Console.WriteLine("3. Activo Intangible");
            Console.WriteLine("4. Otros Activos");

            MostrarTituloSubrayado("Pasivos", false, true);
            Console.WriteLine("5. Pasivo a Largo Plazo");
            Console.WriteLine("6. Pasivo a Corto Plazo");

            MostrarTituloSubrayado("Capital", false, true);
            Console.WriteLine("7. Capital Contribuido");
            Console.WriteLine("8. Capital Ganado");
            MostrarLineaDivisora(true, true);

            int categoria = SolicitarEnteroConLimites(1, 8);

            // Solicitar nombre de la cuenta
            Console.WriteLine("\nIngrese el nombre de la nueva cuenta:");
            string nombreCuenta = SolicitarString("");

            // Solicitar naturaleza de la cuenta
            Console.WriteLine("\n¿La cuenta es de naturaleza Deudora?");
            Console.WriteLine("1. Si (Deudora - aumenta con cargos/debitos)");
            Console.WriteLine("2. No (Acreedora - aumenta con abonos/creditos)");
            int naturalezaOpcion = SolicitarEnteroConLimites(1, 2);
            bool esDeudora = naturalezaOpcion == 1;

            // Crear la nueva cuenta y marcarla como creada por el usuario
            Cuenta nuevaCuenta = new Cuenta(nombreCuenta, esDeudora)
            {
                EsCreadoPorUsuario = true
            };

            // Agregar a la lista correspondiente
            switch (categoria)
            {
                case 1:
                    CuentasBalanceGeneral.ActivoCirculante.Add(nuevaCuenta);
                    Console.WriteLine($"\n✓ Cuenta agregada exitosamente a Activo Circulante");
                    break;
                case 2:
                    CuentasBalanceGeneral.ActivoFijo.Add(nuevaCuenta);
                    Console.WriteLine($"\n✓ Cuenta agregada exitosamente a Activo Fijo");
                    break;
                case 3:
                    CuentasBalanceGeneral.ActivoIntangible.Add(nuevaCuenta);
                    Console.WriteLine($"\n✓ Cuenta agregada exitosamente a Activo Intangible");
                    break;
                case 4:
                    CuentasBalanceGeneral.OtrosActivos.Add(nuevaCuenta);
                    Console.WriteLine($"\n✓ Cuenta agregada exitosamente a Otros Activos");
                    break;
                case 5:
                    CuentasBalanceGeneral.PasivoLargoPlazo.Add(nuevaCuenta);
                    Console.WriteLine($"\n✓ Cuenta agregada exitosamente a Pasivo a Largo Plazo");
                    break;
                case 6:
                    CuentasBalanceGeneral.PasivoCortoPlazo.Add(nuevaCuenta);
                    Console.WriteLine($"\n✓ Cuenta agregada exitosamente a Pasivo a Corto Plazo");
                    break;
                case 7:
                    CuentasBalanceGeneral.CapitalContribuido.Add(nuevaCuenta);
                    Console.WriteLine($"\n✓ Cuenta agregada exitosamente a Capital Contribuido");
                    break;
                case 8:
                    CuentasBalanceGeneral.CapitalGanado.Add(nuevaCuenta);
                    Console.WriteLine($"\n✓ Cuenta agregada exitosamente a Capital Ganado");
                    break;
            }

            string naturalezaTexto = esDeudora ? "Deudora (+)" : "Acreedora (-)";
            Console.WriteLine($"Cuenta: {nombreCuenta}");
            Console.WriteLine($"Naturaleza: {naturalezaTexto}");
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void EliminarCuenta()
        {
            MostrarTituloSubrayado("Eliminar Cuenta - Balance General", true, true);

            // Seleccionar categoria
            Console.WriteLine("Seleccione la categoria de la cuenta a eliminar:");
            Console.WriteLine("1. Activo Circulante");
            Console.WriteLine("2. Activo Fijo");
            Console.WriteLine("3. Activo Intangible");
            Console.WriteLine("4. Otros Activos");
            Console.WriteLine("5. Pasivo a Largo Plazo");
            Console.WriteLine("6. Pasivo a Corto Plazo");
            Console.WriteLine("7. Capital Contribuido");
            Console.WriteLine("8. Capital Ganado");
            MostrarLineaDivisora(true, true);

            int categoria = SolicitarEnteroConLimites(1, 8);

            // Obtener la lista correspondiente
            List<Cuenta> listaCompleta = categoria switch
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

            // Filtrar solo las cuentas creadas por el usuario
            var cuentasUsuario = listaCompleta.Where(c => c.EsCreadoPorUsuario).ToList();

            if (cuentasUsuario.Count == 0)
            {
                Console.WriteLine("\n⚠ No hay cuentas creadas por el usuario en esta categoria.");
                Console.WriteLine("   Solo puedes eliminar las cuentas que tu has creado.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // Mostrar solo las cuentas creadas por el usuario
            Console.WriteLine("\nCuentas creadas por ti (eliminables):");
            MostrarLineaDivisora(false, true);
            for (int i = 0; i < cuentasUsuario.Count; i++)
            {
                string naturaleza = cuentasUsuario[i].EsDeudora ? "[Deudora  ]" : "[Acreedora]";
                Console.WriteLine($"{i + 1}. {naturaleza} {cuentasUsuario[i].Nombre}");
            }
            MostrarLineaDivisora(true, true);

            Console.WriteLine($"Seleccione el numero de la cuenta a eliminar (1-{cuentasUsuario.Count}):");
            int indice = SolicitarEnteroConLimites(1, cuentasUsuario.Count) - 1;

            // Confirmacion
            Console.WriteLine($"\n¿Esta seguro que desea eliminar la cuenta '{cuentasUsuario[indice].Nombre}'?");
            Console.WriteLine("1. Si, eliminar");
            Console.WriteLine("2. No, cancelar");
            int confirmacion = SolicitarEnteroConLimites(1, 2);

            if (confirmacion == 1)
            {
                string nombreEliminado = cuentasUsuario[indice].Nombre;
                listaCompleta.Remove(cuentasUsuario[indice]);
                Console.WriteLine($"\n✓ Cuenta '{nombreEliminado}' eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("\n✗ Operacion cancelada.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void CalcularBalanceGeneral()
        {
            MostrarLineaDivisoraConTexto("Calculo de Balance General", true, true);

            // ACTIVOS
            MostrarTituloSubrayado("ACTIVOS", true, true);

            decimal totalActivoCirculante = CalcularTotalCategoria(CuentasBalanceGeneral.ActivoCirculante, "Activo Circulante");
            decimal totalActivoFijo = CalcularTotalCategoria(CuentasBalanceGeneral.ActivoFijo, "Activo Fijo");
            decimal totalActivoIntangible = CalcularTotalCategoria(CuentasBalanceGeneral.ActivoIntangible, "Activo Intangible");
            decimal totalOtrosActivos = CalcularTotalCategoria(CuentasBalanceGeneral.OtrosActivos, "Otros Activos");

            decimal totalActivos = totalActivoCirculante + totalActivoFijo + totalActivoIntangible + totalOtrosActivos;
            
            MostrarLineaDivisora(true, false);
            Console.WriteLine($"TOTAL ACTIVOS: ${totalActivos:N2}");
            MostrarLineaDivisora(false, true);

            // PASIVOS
            MostrarTituloSubrayado("PASIVOS", true, true);

            decimal totalPasivoLargoPlazo = CalcularTotalCategoria(CuentasBalanceGeneral.PasivoLargoPlazo, "Pasivo a Largo Plazo");
            decimal totalPasivoCortoPlazo = CalcularTotalCategoria(CuentasBalanceGeneral.PasivoCortoPlazo, "Pasivo a Corto Plazo");

            decimal totalPasivos = totalPasivoLargoPlazo + totalPasivoCortoPlazo;
            
            MostrarLineaDivisora(true, false);
            Console.WriteLine($"TOTAL PASIVOS: ${totalPasivos:N2}");
            MostrarLineaDivisora(false, true);

            // CAPITAL
            MostrarTituloSubrayado("CAPITAL CONTABLE", true, true);

            decimal totalCapitalContribuido = CalcularTotalCategoria(CuentasBalanceGeneral.CapitalContribuido, "Capital Contribuido");
            decimal totalCapitalGanado = CalcularTotalCategoria(CuentasBalanceGeneral.CapitalGanado, "Capital Ganado");

            decimal totalCapital = totalCapitalContribuido + totalCapitalGanado;
            
            MostrarLineaDivisora(true, false);
            Console.WriteLine($"TOTAL CAPITAL CONTABLE: ${totalCapital:N2}");
            MostrarLineaDivisora(false, true);

            // ECUACION CONTABLE
            decimal totalPasivoMasCapital = totalPasivos + totalCapital;
            
            MostrarLineaDivisoraConTexto("Ecuacion Contable", true, true);
            Console.WriteLine($"Activos           : ${totalActivos:N2}");
            Console.WriteLine($"Pasivos + Capital : ${totalPasivoMasCapital:N2}");
            MostrarLineaDivisora(true, false);
            
            bool balanceado = Math.Abs(totalActivos - totalPasivoMasCapital) < 0.01m;
            
            if (balanceado)
            {
                Console.WriteLine("✓ BALANCE GENERAL CUADRADO");
                Console.WriteLine("  La ecuacion contable esta balanceada:");
                Console.WriteLine("  Activos = Pasivos + Capital");
            }
            else
            {
                decimal diferencia = totalActivos - totalPasivoMasCapital;
                Console.WriteLine("✗ BALANCE GENERAL DESCUADRADO");
                Console.WriteLine($"  Diferencia: ${Math.Abs(diferencia):N2}");
                Console.WriteLine(diferencia > 0 
                    ? "  Hay mas activos que pasivos + capital" 
                    : "  Hay mas pasivos + capital que activos");
            }

            MostrarLineaDivisora(true, true);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static decimal CalcularTotalCategoria(List<Cuenta> cuentas, string nombreCategoria)
        {
            Console.WriteLine($"\n{nombreCategoria}:");
            decimal total = 0;

            foreach (var cuenta in cuentas)
            {
                Console.Write($"  {cuenta.Nombre}: $");
                decimal valor = (decimal)SolicitarDouble(0);
                
                // Aplicar el signo segun la naturaleza
                decimal valorConSigno = cuenta.EsDeudora ? valor : -valor;
                total += valorConSigno;

                string signo = cuenta.EsDeudora ? "(+)" : "(-)";
                Console.WriteLine($"    Naturaleza: {signo} | Aporte al total: ${valorConSigno:N2}");
            }

            Console.WriteLine($"  Subtotal {nombreCategoria}: ${total:N2}");
            return total;
        }
        public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas)
        {
            MostrarTituloSubrayado(titulo, true);

            foreach (var cuenta in listaDeCuentas)
            {
                string naturaleza = cuenta.EsDeudora ? "[ Deudora   ]" : "[ Acreedora ]";
                Console.WriteLine($"\t{naturaleza} \t{cuenta.Nombre} ");
            }
        }
    }
}
