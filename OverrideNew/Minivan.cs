using System;
using System.Collections.Generic;
using System.Text;

namespace OverrideNew
{
    public class Minivan : Carro
    {
        public override void ExibirDetalhes()
        {
            Console.WriteLine("Transporta sete pessoas");
        }
    }
}
