using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _26_BuiVanToan_Slot14_Demo15
{

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2); 
        [OperationContract]
        double Substract(double n1, double n2);
        [OperationContract]
        Complex AddComplexNumber(Complex n1, Complex n2); 
        [OperationContract]
        Complex SubComplexNumber(Complex n1, Complex n2);
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }
        [DataContract]
     public class Complex {
            private int realPart;
            private int imaginaryPart;
   [DataMember]
    public int RealPart { get; set; }
   [DataMember]
    public int ImaginaryPart { get; set; }
       
    } 
}
