using BibliotecasUteis;
using System;

namespace OlaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nQual é o seu nome?");
            string nome = Console.ReadLine();
            DateTime data = DateTime.Now;

            Console.WriteLine($"\nOlá {nome}, em {data:d} às {data:t}!");
            Console.WriteLine($"Seu nome {(!UteisString.IniciaComMaiuscula(nome) ? "não" : "") } inicia com maiúscula");

            Console.Write("\nPressione alguma tecla para sair...");

            

            Console.ReadKey(true);            
        }
    }
}
