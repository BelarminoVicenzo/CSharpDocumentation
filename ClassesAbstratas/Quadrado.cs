using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAbstratas
{
    public class Quadrado : Forma
    {
        private readonly int lado;

        public Quadrado(int lado, string id) : base(id)
        {
            this.lado = lado;
        }

        //Sobrescrevendo o método definido na classe base
        public override double Area
        {
            get
            {
                return lado * lado;
            }
        }
    }
}
