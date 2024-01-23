using System;

namespace ComplexNumberConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Complex Number");

            ComplexNumber z = ComplexNumber.parse(Console.ReadLine());

            Console.WriteLine("Enter an Operation");

            String operationInput = Console.ReadLine();

            Operation operationToPerform = OperationFromInput(operationInput);

            Console.WriteLine("Enter Another Complex Number");

            ComplexNumber z2 = ComplexNumber.parse(Console.ReadLine());

            ComplexNumber result = new ComplexNumber();

            result = PerformOperation(z, z2, operationToPerform);

            Console.WriteLine("the Result is {0}", result);
        }
        private static ComplexNumber PerformOperation(ComplexNumber z, ComplexNumber z2, Operation operationToPerform)
        {
            if (operationToPerform == Operation.Addition) return z + z2;
            if (operationToPerform == Operation.Subtraction) return z - z2;
            if (operationToPerform == Operation.Multiplication) return z * z2;
            if (operationToPerform == Operation.Division) return z / z2;
            return new ComplexNumber(0, 0);
        }

        private static Operation OperationFromInput(String operationInput) {
            if (operationInput == "+" || operationInput.Equals("Add", StringComparison.OrdinalIgnoreCase) || operationInput.Equals("Plus", StringComparison.OrdinalIgnoreCase)) return Operation.Addition;
            if (operationInput == "-" || operationInput.Equals("Subtract", StringComparison.OrdinalIgnoreCase) || operationInput.Equals("Minus", StringComparison.OrdinalIgnoreCase)) return Operation.Subtraction;
            if (operationInput == "*" || operationInput.Equals("Multiply", StringComparison.OrdinalIgnoreCase) || operationInput.Equals("Times", StringComparison.OrdinalIgnoreCase)) return Operation.Multiplication;
            if (operationInput == "/" || operationInput.Equals("Divide", StringComparison.OrdinalIgnoreCase)) return Operation.Division;
            return Operation.Invalid;
        }

    }

    enum Operation { 
        Addition, Subtraction, Multiplication, Division, Invalid
    }


}