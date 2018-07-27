using System;
using System.Collections.Generic;
using System.Text;

namespace OverrideNew
{
    public class Conversivel : Carro
    {
        public new void ExibirDetalhes()
        {
            Console.WriteLine("Um teto retrátil");
        }
    }
}
