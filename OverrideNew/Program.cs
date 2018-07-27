using System;
using System.Collections.Generic;

namespace OverrideNew
{
    class Program
    {
        static void Main(string[] args)
        {
            TesteCarros1();
            TesteCarros2();
            TesteCarros3();
            TesteCarros4();
        }

        private static void TesteCarros1()
        {
            System.Console.WriteLine("Primeiro teste de carros");
            System.Console.WriteLine("-----------------------");

            Carro carro1 = new Carro();
            carro1.Descrever();
            System.Console.WriteLine("-----------------------");


            /* A chamada abaixo irá ExibirDetalhes da classe base Carro, pois o método foi definido com o
             * modificador new na classe derivada Conversivel. 
             */
            Conversivel carro2 = new Conversivel();
            carro2.Descrever();
            System.Console.WriteLine("-----------------------");

            /* A chamada abaixo irá ExibirDetalhes da classe base Minivan, pois o método foi definido com o
             * modificador override na classe derivada Minivan
            */
            Minivan carro3 = new Minivan();
            carro3.Descrever();
            System.Console.WriteLine("-----------------------");
        }

        private static void TesteCarros2()
        {
            System.Console.WriteLine("\n\nSegundo teste de carros");
            System.Console.WriteLine("-----------------------");

            List<Carro> carros = new List<Carro> { new Carro(), new Conversivel(), new Minivan() };

            //Carro[2] chamará o método ExibirDetalhes com base na classe Minivan nos dois casos, 
            //tendo ele o tipo Minivan ou o tipo Carro
            foreach (Carro carro in carros)
            {
                carro.Descrever();
                System.Console.WriteLine("-----------------------");
            }
        }

        public static void TesteCarros3()
        {
            System.Console.WriteLine("\n\nTerceiro teste de carros");
            System.Console.WriteLine("------------------------");

            Conversivel carro2 = new Conversivel();
            Minivan carro3 = new Minivan();
            carro2.ExibirDetalhes();
            carro3.ExibirDetalhes();
        }

        public static void TesteCarros4()
        {
            System.Console.WriteLine("\nTestCars4");
            System.Console.WriteLine("----------");
            Carro carro2 = new Conversivel();
            Carro carro3 = new Minivan();
            carro2.ExibirDetalhes();
            carro3.ExibirDetalhes();
        }
    }
}
