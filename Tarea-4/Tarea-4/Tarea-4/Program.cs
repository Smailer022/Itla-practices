using System;
using System.Collections.Generic;

class Calculadora
{
    static void Main(string[] args)
    {
        List<decimal> typedNumbers = new List<decimal>();

        decimal result = 0;
        int typedOption = 1;
        int wantToContinue = 0;
        bool running = true;

        Console.WriteLine("This is the best calculator");

        while (running)
        {
            DisplayHeader();

            try
            {
                typedOption = Convert.ToInt32(Console.ReadLine());

                if (typedOption == 5)
                {
                    running = false;
                }
                else
                {
                    // Limpiar la lista para cada operación nueva
                    typedNumbers.Clear();

                    Console.WriteLine("Please Type the first number");
                    typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

                    Console.WriteLine("Please Type the second number");
                    typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

                    wantToContinue = 0; // reiniciamos la opción de continuar
                    while (wantToContinue != 2)
                    {
                        Console.WriteLine("Do you want to continue inserting numbers? 1. Yes, 2. No");
                        wantToContinue = Convert.ToInt32(Console.ReadLine());
                        if (wantToContinue == 1)
                        {
                            Console.WriteLine("Please Type another number");
                            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));
                        }
                    }

                    switch (typedOption)
                    {
                        case 1:
                            {
                                result = AddList(typedNumbers);
                            }
                            break;
                        case 2:
                            {
                                result = SubtractList(typedNumbers);
                            }
                            break;
                        case 3:
                            {
                                result = MultiplyList(typedNumbers);
                            }
                            break;
                        case 4:
                            {
                                result = DivideList(typedNumbers);
                            }
                            break;
                        default:
                            result = 0;
                            break;
                    }

                    Console.WriteLine($"The Result of the operation is: {result}");
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"You cannot divide by zero: {ex.Message}");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"Arithmetic error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"You need to choose a correct option: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Closing Db Connection");
            }
        }
    }

    // Procedimiento que modifica el valor pasado por referencia
    static void AddByRef(ref decimal valueToModify, decimal value)
    {
        valueToModify += value;
    }

    // Función que retorna el resultado de la suma
    static decimal Add(decimal valueToModify, decimal value)
    {
        valueToModify += value;
        return valueToModify;
    }

    // Suma una lista de números
    static decimal AddList(List<decimal> typedNumbers)
    {
        decimal result = 0;
        foreach (decimal typedNumber in typedNumbers)
        {
            result = Add(result, typedNumber);
        }
        return result;
    }

    // Resta una lista de números: partiendo del primer valor, se le resta cada uno de los siguientes
    static decimal SubtractList(List<decimal> typedNumbers)
    {
        if (typedNumbers.Count == 0)
            return 0;

        decimal result = typedNumbers[0];
        for (int i = 1; i < typedNumbers.Count; i++)
        {
            result -= typedNumbers[i];
        }
        return result;
    }

    // Multiplica una lista de números
    static decimal MultiplyList(List<decimal> typedNumbers)
    {
        if (typedNumbers.Count == 0)
            return 0;

        decimal result = 1;
        foreach (decimal typedNumber in typedNumbers)
        {
            result *= typedNumber;
        }
        return result;
    }

    // Divide una lista de números: partiendo del primer valor, se divide sucesivamente por cada número
    static decimal DivideList(List<decimal> typedNumbers)
    {
        if (typedNumbers.Count == 0)
            return 0;

        decimal result = typedNumbers[0];
        for (int i = 1; i < typedNumbers.Count; i++)
        {
            if (typedNumbers[i] == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");
            result /= typedNumbers[i];
        }
        return result;
    }

    // Muestra el encabezado con las opciones disponibles
    static void DisplayHeader()
    {
        Console.WriteLine("Please Type the option number that you want");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("1. Sum, \n2. Subtract, \n3. Multiplication, \n4. Division, \n5. Exit");
    }
}