using ProyectoProgramacion.Comunes;
using static ProyectoProgramacion.Comunes.Utilidades;
using ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Acciones;
using static ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo.Menus.MenusFlujoEfectivo;

namespace ProyectoProgramacion.EstadosFinancieros.FlujoEfectivo
{
    /*
    ===========================
        Clase Flujo de Efectivo
    ===========================
    
    TODO: Esta clase debe seguir el mismo patrón arquitectónico que BalanceGeneral.
    
    Estructura requerida:
    1. Crear MenusFlujoEfectivo.cs con todas las funciones de menú
    2. Crear AccionesVerCuentas.cs para visualizar cuentas del flujo de efectivo
    3. Crear AccionAgregarCuenta.cs para agregar nuevas cuentas (marcar con EsCreadoPorUsuario = true)
    4. Crear AccionEliminarCuenta.cs para eliminar solo cuentas creadas por el usuario
    5. Crear AccionCalcularFlujoEfectivo.cs para realizar el cálculo interactivo
    
    El cálculo debe:
    - Solicitar saldo inicial de efectivo
    - Permitir seleccionar cuentas de cada actividad interactivamente
    - Actividades de Operación: partir de utilidad neta, ajustar por partidas que no generan efectivo
    - Actividades de Inversión: compras/ventas de activos fijos e inversiones
    - Actividades de Financiamiento: préstamos, aportaciones, dividendos pagados
    - Calcular flujo neto por cada actividad
    - Sumar: Saldo inicial + Flujo Operación + Flujo Inversión + Flujo Financiamiento = Saldo final
    - Mostrar resultado con formato claro mostrando cada actividad y sus totales
    
    Categorías de actividades (ver CuentasFlujoEfectivo.cs):
    - Actividades de Operación (operaciones normales del negocio)
    - Actividades de Inversión (compra/venta de activos a largo plazo)
    - Actividades de Financiamiento (deuda y capital)
    
    Naturaleza de las cuentas en flujo de efectivo:
    - EsDeudora = true significa ENTRADA de efectivo [+]
    - EsDeudora = false significa SALIDA de efectivo [-]
    */
    public static class FlujoEfectivo
    {
        public static void Ejecutar()
        {
            // TODO: Implementar menú principal similar a BalanceGeneral
            // Debe tener opciones:
            // 1. Ver Cuentas (llamar a AccionesVerCuentas)
            // 2. Agregar Cuenta (llamar a AccionAgregarCuenta.Ejecutar())
            // 3. Eliminar Cuenta (llamar a AccionEliminarCuenta.Ejecutar())
            // 4. Calcular Flujo de Efectivo (llamar a AccionCalcularFlujoEfectivo.Ejecutar())
            // 0. Volver al menú principal
            
            MostrarMensajeAdvertencia("El modulo de Flujo de Efectivo aun no esta implementado.", true, true);
            MostrarMensajeAdvertencia("Debe seguir la misma estructura que Balance General.", true, false);
            EsperarTecla();
        }

        // TODO: Crear método MostrarSeccion para visualizar listas de cuentas
        // Este método debe ser público y utilizado por AccionesVerCuentas
        // Similar al método MostrarSeccion en BalanceGeneral.cs
    }
}
