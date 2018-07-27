using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAbstratas
{
    public class Circulo : Forma
    {
        private readonly int raio;

        public Circulo(int raio, string id) : base(id)
        {
            this.raio = raio;
        }

        public override double Area
        {
            get
            {
                return raio * raio * Math.PI;
            }
        }
    }
}
