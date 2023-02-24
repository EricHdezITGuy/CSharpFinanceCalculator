using System;
using System.Globalization;

namespace CalculadoraPrestamos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crea un objeto Scanner para leer las entradas del usuario
            Console.WriteLine("Bienvenido(a) a la calculadora de préstamos, por favor leer las siguientes instrucciones.\n");
            Console.WriteLine("Tipos de clientes:\n");
            Console.WriteLine("Tipo A1, A2: Crédito otorgado con un descuento del 2%.");
            Console.WriteLine("Tipo B: Crédito ordinario basado en cuotas establecidas.");
            Console.WriteLine("Tipo C: Crédito denegado.\n");
            Console.Write("Ingrese el tipo de cliente (A1, A2, B, C): ");
            string tipoCliente = Console.ReadLine().ToUpper();

            double descuento = 0;
            if (tipoCliente.Equals("A1") || tipoCliente.Equals("A2"))
            {
                descuento = 0.02;
            }
            else if (tipoCliente.Equals("C"))
            {
                Console.WriteLine("Crédito denegado.");
                return;
            }

            // Leer el monto del préstamo
            Console.Write("Ingrese el monto del préstamo: ");
            double MontoPrestamo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Lee la tasa de interés
            Console.Write("Ingrese la tasa de interés: ");
            float TasaInteres = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Leer el número de años
            Console.Write("Introduzca el número de años: ");
            int CantidadAnios = int.Parse(Console.ReadLine());

            // Calcular el pago mensual
            // La fórmula es la siguiente:
            // PagoMensual = (MontoPrestamo - MontoPrestamo * descuento) * TasaInteres / (1 - 1 / Math.Pow(1 + TasaInteres, CantidadAnios * 12));
            double PagoMensual = (MontoPrestamo - MontoPrestamo * descuento) * (TasaInteres/12) / (1 - 1 / Math.Pow(1 + TasaInteres, CantidadAnios * 12));

            // Calcular el pago total
            // La fórmula es la siguiente:
            // PagoTotal = PagoMensual * CantidadAnios * 12;
            double PagoTotal = PagoMensual * CantidadAnios * 12;

            // Calcular el monto del descuento
            double MontoDescuento = MontoPrestamo * descuento;

            // Crear un objeto NumberFormatInfo
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberGroupSeparator = ",";

            // Salida del pago mensual
            Console.WriteLine("Mensualidad: ₡" + PagoMensual.ToString("N2", nfi));

            // Salida del pago total
            Console.WriteLine("Pago total: ₡" + PagoTotal.ToString("N2", nfi));

            // Salida del monto del descuento si corresponde
            if (descuento > 0)
            {
                Console.WriteLine("Monto del descuento: ₡" + MontoDescuento.ToString("N2", nfi));
            }

            // Calcular el costo total del préstamo
            double CostoTotal = PagoTotal + MontoDescuento;
            
            // Salida del costo total del préstamo
            Console.WriteLine("Costo total del préstamo: ₡" + CostoTotal.ToString("N2", nfi));

// Espera a que el usuario presione una tecla para salir
            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();