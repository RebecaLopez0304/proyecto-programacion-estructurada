// Utilidades comunes del proyecto (como lectura/validación de consola)
using ProyectoProgramacion.Comunes;
// Importa métodos estáticos de Utilidades para usarlos sin prefijo
using static ProyectoProgramacion.Comunes.Utilidades;
// Importa los menús del Balance General (para pedir opciones al usuario)
using static ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Menus.MenusBalanceGeneral;
using ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Catalogos;

namespace ProyectoProgramacion.EstadosFinancieros.BalanceGeneral.Acciones
{
    public static class AccionAgregarCuenta
    {
        // Método que maneja la creación de una nueva cuenta por parte del usuario
        public static void Ejecutar()
        {
            // Pedimos al usuario a qué categoría principal pertenece la nueva cuenta
            int categoria = MostrarMenuCategorias("Agregar Cuenta - Balance General");

            // Pedimos el nombre de la cuenta
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre de la nueva cuenta:");
            string nombreCuenta = SolicitarString("");

            // Pedimos la naturaleza: si es deudora o acreedora
            int naturalezaOpcion = MostrarMenuNaturalezaCuenta();
            bool esDeudora = naturalezaOpcion == 1; // true = Deudora, false = Acreedora

            // Creamos la cuenta y marcamos que fue creada por el usuario
            Cuenta nuevaCuenta = new Cuenta(nombreCuenta, esDeudora)
            {
                EsCreadoPorUsuario = true
            };

            // Según la categoría elegida, agregamos la cuenta a la lista correspondiente
            switch (categoria)
            {
                case 1:
                    CuentasBalanceGeneral.ActivoCirculante.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Activo Circulante", true, false);
                    break;
                case 2:
                    CuentasBalanceGeneral.ActivoFijo.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Activo Fijo", true, false);
                    break;
                case 3:
                    CuentasBalanceGeneral.ActivoIntangible.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Activo Intangible", true, false);
                    break;
                case 4:
                    CuentasBalanceGeneral.OtrosActivos.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Otros Activos", true, false);
                    break;
                case 5:
                    CuentasBalanceGeneral.PasivoLargoPlazo.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Pasivo a Largo Plazo", true, false);
                    break;
                case 6:
                    CuentasBalanceGeneral.PasivoCortoPlazo.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Pasivo a Corto Plazo", true, false);
                    break;
                case 7:
                    CuentasBalanceGeneral.CapitalContribuido.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Capital Contribuido", true, false);
                    break;
                case 8:
                    CuentasBalanceGeneral.CapitalGanado.Add(nuevaCuenta);
                    MostrarMensajeExito($"Cuenta agregada exitosamente a Capital Ganado", true, false);
                    break;
            }

            // Mostramos un resumen sencillo de la cuenta creada
            string naturalezaTexto = esDeudora ? "Deudora (+)" : "Acreedora (-)";
            Console.WriteLine($"Cuenta: {nombreCuenta}");
            Console.WriteLine($"Naturaleza: {naturalezaTexto}");

            // Pausa para que el usuario lea el mensaje
            EsperarTecla();
        }
    }
}
