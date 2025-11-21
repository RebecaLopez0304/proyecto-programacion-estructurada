using ProyectoProgramacion.Comunes;

namespace ProyectoProgramacion.EstadosFinancieros.EstadoResultados.Catalogos
{
    // Aquí definimos las listas de cuentas que usa el Estado de Resultados
    // Cada lista representa una categoría de ingresos o egresos
    public static class CuentasEstadoResultados
    {
        // MARK: Ventas
        // Ingresos generados por la actividad principal de la empresa
        public static readonly List<Cuenta> Ventas = new()
        {
            // (+) Ingreso total por venta de mercancías o servicios
            new Cuenta("Ventas totales", false),

            // (-) Mercancías que los clientes regresan, disminuye las ventas
            new Cuenta("Devoluciones sobre ventas", true),

            // (-) Rebajas en precio por diversos motivos, disminuye las ventas
            new Cuenta("Descuentos sobre ventas", true),

            // (-) Reducciones especiales otorgadas a clientes, disminuye las ventas
            new Cuenta("Bonificaciones sobre ventas", true),

            // (+) Ingreso por prestación de servicios profesionales o técnicos
            new Cuenta("Ingresos por servicios", false),

            // (+) Rendimientos por inversiones financieras
            new Cuenta("Ingresos financieros", false),

            // (+) Otros ingresos no clasificados en categorías anteriores
            new Cuenta("Otros ingresos", false)
        };

        // MARK: Costo de ventas
        // Costo directo de la mercancía o producto vendido
        public static readonly List<Cuenta> CostoDeVentas = new()
        {
            // (+) Valor de la mercancía disponible al inicio del periodo
            new Cuenta("Inventario inicial", true),

            // (+) Compras de mercancía para reventa
            new Cuenta("Compras", true),

            // (+) Fletes, seguros y otros costos de adquisición de mercancía
            new Cuenta("Gastos sobre compra", true),

            // (-) Mercancía devuelta a proveedores, disminuye el costo
            new Cuenta("Devoluciones sobre compra", false),

            // (-) Rebajas recibidas de proveedores, disminuye el costo
            new Cuenta("Descuentos sobre compra", false),

            // (-) Bonificaciones otorgadas por proveedores, disminuye el costo
            new Cuenta("Bonificaciones sobre compra", false),

            // (-) Valor de mercancía disponible al final del periodo, disminuye el costo
            new Cuenta("Inventario final", false),

            // (+) Costo de fabricación de productos terminados
            new Cuenta("Costo de producción", true),

            // (+) Salarios de trabajadores directamente involucrados en producción
            new Cuenta("Mano de obra directa", true),

            // (+) Materiales usados directamente en la fabricación de productos
            new Cuenta("Materia prima", true)
        };

        // MARK: Gastos de operación
        // Gastos necesarios para realizar las ventas (Gastos de Venta)
        public static readonly List<Cuenta> GastoDeOperacion = new()
        {
            // (+) Salarios del personal del departamento de ventas
            new Cuenta("Sueldos de vendedores", true),

            // (+) Pagos variables basados en ventas realizadas
            new Cuenta("Comisiones de vendedores", true),

            // (+) Aguinaldo, vacaciones, y otras prestaciones de vendedores
            new Cuenta("Prestaciones de vendedores", true),

            // (+) Gastos en promoción y difusión de productos o servicios
            new Cuenta("Publicidad y propaganda", true),

            // (+) Costos de embalaje y transporte de productos a clientes
            new Cuenta("Gastos de empaque y envío", true),

            // (+) Desgaste de vehículos y equipo usado para distribución
            new Cuenta("Depreciación de equipo de reparto", true),

            // (+) Gasolina y aceites para vehículos de reparto
            new Cuenta("Combustibles y lubricantes", true),

            // (+) Reparaciones y servicios de vehículos de distribución
            new Cuenta("Mantenimiento de vehículos", true),

            // (+) Gastos de transporte, hospedaje y alimentación de vendedores
            new Cuenta("Viáticos", true),

            // (+) Regalos y muestras entregadas a clientes potenciales
            new Cuenta("Promociones y muestras", true)
        };

        // MARK: Gastos de administración
        // Gastos necesarios para la dirección y administración general de la empresa
        public static readonly List<Cuenta> GastosAdministracion = new()
        {
            // (+) Salarios de gerentes, contadores, y personal de oficina
            new Cuenta("Sueldos de personal administrativo", true),

            // (+) Aguinaldo, vacaciones y otras prestaciones del personal administrativo
            new Cuenta("Prestaciones administrativas", true),

            // (+) Pagos a contadores, abogados y otros profesionales externos
            new Cuenta("Honorarios profesionales", true),

            // (+) Papel, plumas, folders y material de oficina consumido
            new Cuenta("Gastos de papelería y útiles", true),

            // (+) Luz, agua, teléfono, internet de las oficinas
            new Cuenta("Servicios públicos", true),

            // (+) Pólizas de seguro contra incendio, robo, responsabilidad civil
            new Cuenta("Seguros y fianzas", true),

            // (+) Renta de oficinas, bodegas o locales administrativos
            new Cuenta("Arrendamientos", true),

            // (+) Desgaste de computadoras, muebles y equipo de oficina
            new Cuenta("Depreciación de equipo de oficina", true),

            // (+) Desgaste del inmueble donde opera la empresa
            new Cuenta("Depreciación de edificio", true),

            // (+) Distribución del costo de gastos diferidos (instalación, organización)
            new Cuenta("Amortización de gastos", true),

            // (+) Reparaciones y servicios de mantenimiento de oficinas
            new Cuenta("Mantenimiento y reparaciones", true),

            // (+) Honorarios legales, notariales y trámites jurídicos
            new Cuenta("Gastos legales", true),

            // (+) Cursos, talleres y entrenamiento del personal
            new Cuenta("Capacitación de personal", true)
        };

        // MARK: Gastos y productos financieros
        // Resultados derivados de operaciones financieras, no de la operación principal
        public static readonly List<Cuenta> OtrosResultadosFinancieros = new()
        {
            // (-) Intereses pagados por préstamos y créditos bancarios
            new Cuenta("Intereses pagados", true),

            // (-) Cargos por servicios y transacciones bancarias
            new Cuenta("Comisiones bancarias", true),

            // (-) Pérdidas por fluctuaciones en tipo de cambio de monedas extranjeras
            new Cuenta("Pérdida en cambio de divisas", true),

            // (-) Descuentos otorgados a clientes por pago anticipado
            new Cuenta("Descuentos por pronto pago concedidos", true),

            // (-) Costos relacionados con emisión de bonos u obligaciones
            new Cuenta("Gastos por emisión de obligaciones", true)
        };

    }
}
