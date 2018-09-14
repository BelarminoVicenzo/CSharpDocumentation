using System;

namespace ClassesAbstratas
{
    class Program
    {
        static void Main(string[] args)
        {
            Forma[] formas =
            {
                new Quadrado(20, "Quadrado 1"),
                new Circulo(5, "Circulo 1"),
                new Retangulo(3, 5, "Retangulo 1")
            };

            Console.WriteLine("Coleção de formas");
            Console.WriteLine("=================");

            foreach(Forma forma in formas)
            {
                //Não é necessário chamar ToString, ele é chamado automaticamente
                Console.WriteLine(forma);
            }
        }
    }
}
