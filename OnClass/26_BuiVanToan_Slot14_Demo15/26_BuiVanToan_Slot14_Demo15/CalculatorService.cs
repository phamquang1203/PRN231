using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _26_BuiVanToan_Slot14_Demo15
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CalculatorService : ICalculator
    {
     
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine(result);
            return result;
        }

        public Complex AddComplexNumber(Complex n1, Complex n2)
        {
            Complex result = new Complex();
            result.RealPart = n1.RealPart + n2.RealPart;
            result.ImaginaryPart = n1.ImaginaryPart + n2.ImaginaryPart;
            Console.WriteLine(result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine(result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine(result);
            return result;
        }

        public Complex SubComplexNumber(Complex n1, Complex n2)
        {
            Complex result = new Complex();
            result.RealPart = n1.RealPart - n2.RealPart;
            result.ImaginaryPart = n1.ImaginaryPart - n2.ImaginaryPart;
            Console.WriteLine(result);
            return result;
        }

        public double Substract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine(result);
            return result;
        }
    }
}
