using System;
using System.Collections.Generic;
using System.Text;

namespace SobrecargaMetodos
{
    using System;

    public class Sobrecarga
    {
        static void Metodo()
        {
            Console.WriteLine("Executou Metodo()");
        }

        static void Metodo(object x)
        {
            Console.WriteLine("Executou Metodo(object x)");
        }

        static void Metodo(int x)
        {
            Console.WriteLine("Executou Metodo(int x )");
        }

        static void Metodo(double x)
        {
            Console.WriteLine("Executou Metodo(double x)");
        }

        static void Metodo<T>(T x)
        {
            Console.WriteLine("Executou Metodo<T>(T x)");
        }

        static void Metodo(double x, double y)
        {
            Console.WriteLine("Executou Metodo(double x, double y)");
        }

        public static void ExecutarMetodos()
        {
            Metodo();            
            Metodo(1);           
            Metodo(1.0);         
            Metodo("abc");       
            Metodo((double)1);   
            Metodo((object)1);   
            Metodo<int>(1);      
            Metodo(1, 1);        
        }
    }
}
