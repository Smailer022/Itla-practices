using System;
class tarea2
{
    public static void Main()
    {
        Console.WriteLine("Escribe un numero: ");
       
        int Numero = Convert.ToInt32 (Console.ReadLine());

        Console.WriteLine("Resultado: " + Numero);

        if ((Numero % 2) == 0)
        {
            Console.WriteLine("Es par");
        }
        else
        {
            Console.WriteLine("Es impar");
        }
    }
}

