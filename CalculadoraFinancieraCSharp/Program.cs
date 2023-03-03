using System.Globalization;

namespace CalculadoraFinancieraCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crea un objeto Scanner para leer las entradas del usuario
            Console.WriteLine(
                "Bienvenido(a) a la calculadora de préstamos, por favor leer las siguientes instrucciones.\n");
            Console.WriteLine("Tipos de clientes:\n");
            Console.WriteLine("Tipo A1, A2: Crédito otorgado con un descuento del 2%.");
            Console.WriteLine("Tipo B: Crédito ordinario basado en cuotas establecidas.");
            Console.WriteLine("Tipo C: Crédito denegado.\n");
            Console.Write("Ingrese el tipo de cliente (A1, A2, B, C): ");
            var tipoCliente = Console.ReadLine().ToUpper();

            double descuento = 0;
            switch (tipoCliente)
            {
                case "A1":
                case "A2":
                    descuento = 0.02;
                    break;
                case "C":
                    Console.WriteLine("Crédito denegado.");
                    return;
            } 
            // Menu de opciones de préstamo
            Console.WriteLine("Seleccione una opción de préstamo:\n");
            Console.WriteLine("1. Personal Regular - Tasa de interés: 15%");
            Console.WriteLine("2. Personal Rápido - Tasa de interés: 18%");
            Console.WriteLine("3. Reparación y ampliación de vivienda - Tasa de interés: 12%");
            Console.WriteLine("4. Compra de Lote - Tasa de interés: 12%");
            Console.WriteLine("5. Compra de Vehículo Nuevo - Tasa de interés: 18%");
            Console.Write("Ingrese el número de opción: ");
            var opcionPrestamo = int.Parse(Console.ReadLine());

            float tasaInteres;
                switch (opcionPrestamo)
            {
                case 1:
                tasaInteres = (float)0.15;
                break;
                case 2:
                tasaInteres = (float)0.18;
                break;
                case 3:
                tasaInteres = (float)0.12;
                break;
                case 4:
                tasaInteres = (float)0.12;
                break;
                case 5:
                tasaInteres = (float)0.18;
                break;
                default:
                Console.WriteLine("Opción de préstamo no válida.");
                return;
        }

            // Leer el monto del préstamo
            Console.Write("Ingrese el monto del préstamo: ");
            var montoPrestamo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Lee la tasa de interés | Esto lo cambiamos para que este quemado en el codigo, segun requerimientos
            // Console.Write("Ingrese la tasa de interés: ");
           // tasaInteres = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Leer el número de años
            Console.Write("Introduzca el número de años: ");
            var cantidadAnios = int.Parse(Console.ReadLine());

            // Calcular el pago mensual
            // La fórmula es la siguiente:
            // PagoMensual = (MontoPrestamo - MontoPrestamo * descuento) * (tasaInteres / 12) / (1 - 1 / Math.Pow(1 + TasaInteres, CantidadAnios * 12));
            var pagoMensual = (montoPrestamo - montoPrestamo * descuento) * (tasaInteres / 12) /
                              (1 - 1 / Math.Pow(1 + tasaInteres, cantidadAnios * 12));

            // Calcular el pago total
            // La fórmula es la siguiente:
            // PagoTotal = PagoMensual * CantidadAnios * 12;
            var pagoTotal = pagoMensual * cantidadAnios * 12;

            // Calcular el monto del descuento
            var montoDescuento = montoPrestamo * descuento;

            // Crear un objeto NumberFormatInfo
            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberGroupSeparator = ",";

            // Salida del pago mensual
            Console.WriteLine("Mensualidad: ₡" + pagoMensual.ToString("N2", nfi));

            // Salida del pago total
            Console.WriteLine("Pago total: ₡" + pagoTotal.ToString("N2", nfi));

            // Salida del monto del descuento si corresponde
            if (descuento > 0)
            {
                Console.WriteLine("Monto del descuento: ₡" + montoDescuento.ToString("N2", nfi));
            }

            // Calcular el costo total del préstamo
            var costoTotal = pagoTotal + montoDescuento;

            // Salida del costo total del préstamo
            Console.WriteLine("Costo total del préstamo: ₡" + costoTotal.ToString("N2", nfi));

            // Espera a que el usuario presione una tecla para salir
            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }

}