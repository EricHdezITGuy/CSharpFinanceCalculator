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

            // Leer el monto del préstamo
            Console.Write("Ingrese el monto del préstamo: ");
            var montoPrestamo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Lee la tasa de interés
            Console.Write("Ingrese la tasa de interés: ");
            var tasaInteres = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

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