using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.AccionesVerCuentas;
using static ProyectoProgramacion.EstadosFinancieros.EstadoResultados.MenusEstadoResultados;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados
{
    /*
    ===========================
        Clase Estado de Resultados
    ===========================
    
    TODO: Esta clase debe seguir el mismo patrón arquitectónico que BalanceGeneral.
    
    Estructura requerida:
    1. Crear MenusEstadoResultados.cs con todas las funciones de menú
    2. Crear AccionesVerCuentas.cs para visualizar cuentas del estado de resultados
    3. Crear AccionAgregarCuenta.cs para agregar nuevas cuentas (marcar con EsCreadoPorUsuario = true)
    4. Crear AccionEliminarCuenta.cs para eliminar solo cuentas creadas por el usuario
    5. Crear AccionCalcularEstadoResultados.cs para realizar el cálculo interactivo
    
    El cálculo debe:
    - Solicitar al usuario que seleccione cuentas de cada categoría interactivamente
    - Calcular: Ingresos - Costo de Ventas = Utilidad Bruta
    - Restar Gastos de Operación (Venta + Administración) = Utilidad de Operación
    - Sumar/Restar Gastos y Productos Financieros = Utilidad antes de Otros
    - Sumar/Restar Otros Gastos y Productos = Utilidad antes de Impuestos
    - Restar Impuestos = Utilidad Neta
    - Mostrar resultado con formato claro y totales parciales
    
    Categorías de cuentas (ver CuentasEstadoResultados.cs):
    - Ingresos (9 categorías)
    - Costo de Ventas
    - Gastos de Venta
    - Gastos de Administración
    - Gastos Financieros
    - Productos Financieros
    - Otros Gastos
    - Otros Productos
    - Impuestos
    */
    public static class EstadoResultados
    {
        public static void Ejecutar()
        {
            // TODO: Implementar menú principal similar a BalanceGeneral
            // Debe tener opciones:
            bool volver = false;

            while (!volver)
            {
                int opcion = MostrarMenuPrincipal();

                switch (opcion)
                {
                    case 1:
                        VerCuentas();
                        break;
                    case 2:
                        AccionAgregarCuenta.Ejecutar();
                        break;
                    case 3:
                        AccionEliminarCuenta.Ejecutar();
                        break;
                    case 4:
                        AccionCalcularEstadoResultados.Ejecutar();
                        break;
                    case 0:
                        volver = true;
                        Console.WriteLine("\n\n");
                        break;
                    default:
                        MostrarMensajeError("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }
            // 1. Ver Cuentas (llamar a AccionesVerCuentas)
            // 2. Agregar Cuenta (llamar a AccionAgregarCuenta.Ejecutar())
            // 3. Eliminar Cuenta (llamar a AccionEliminarCuenta.Ejecutar())
            // 4. Calcular Estado de Resultados (llamar a AccionCalcularEstadoResultados.Ejecutar())
            // 0. Volver al menú principal

            MostrarMensajeAdvertencia("El modulo de Estado de Resultados aun no esta implementado.", true, true);
            MostrarMensajeAdvertencia("Debe seguir la misma estructura que Balance General.", true, false);
            EsperarTecla();
        }

        // TODO: Crear método MostrarSeccion para visualizar listas de cuentas
        // Este método debe ser público y utilizado por AccionesVerCuentas
        // Similar al método MostrarSeccion en BalanceGeneral.cs

        private static void VerCuentas()
        {
            bool regresar = false;

            while (!regresar)
            {
                int opcion = MostrarMenuCuentas();

                switch (opcion)
                {
                    case 1:
                        MostrarTodoER();
                        break;
                    case 2:
                        MostrarPorCategoriaER();
                        break;
                    case 0:
                        regresar = true;
                        break;
                }
            }
        }

        public static void MostrarSeccion(string titulo, List<Cuenta> listaDeCuentas, bool v)//
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
