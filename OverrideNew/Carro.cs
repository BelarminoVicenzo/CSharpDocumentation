using System;
using System.Collections.Generic;
using System.Text;

namespace OverrideNew
{
    public class Carro
    {
        public virtual void Descrever()
        {
            Console.WriteLine("Quatro rodas e um motor");
            ExibirDetalhes();
        }

        public virtual void ExibirDetalhes()
        {
            Console.WriteLine("Transporta cinco pessoas");
        }
    }
}
