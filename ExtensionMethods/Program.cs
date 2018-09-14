using System;
using MetodosExtensao;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //string minhaString = "Hello Extension Methods";
            //Console.WriteLine($"Palavras na frase: {minhaString.ContarPalavras()}");

            Nota matematica = Nota.F;
            Nota portugues = Nota.C;
            Nota geografia = Nota.A;
            Nota historia = Nota.B;

            Console.WriteLine("Você {0} passou em matematica", matematica.Passou() ? "" : "não");
            Console.WriteLine("Você {0} passou em portugues", portugues.Passou() ? "" : "não");
            Console.WriteLine("Você {0} passou em geografia", geografia.Passou() ? "" : "não");
            Console.WriteLine("Você {0} passou em historia", historia.Passou() ? "" : "não");

            MinhasExtensoes.minimoParaPassar = Nota.B;
            Console.WriteLine("\nAumentando a dificuldade", matematica.Passou() ? "" : "não");
            Console.WriteLine("========================\n");
            Console.WriteLine("Você {0} passou em matematica", matematica.Passou() ? "" : "não");
            Console.WriteLine("Você {0} passou em portugues", portugues.Passou() ? "" : "não");
            Console.WriteLine("Você {0} passou em geografia", geografia.Passou() ? "" : "não");
            Console.WriteLine("Você {0} passou em historia", historia.Passou() ? "" : "não");
        }
    }
}
