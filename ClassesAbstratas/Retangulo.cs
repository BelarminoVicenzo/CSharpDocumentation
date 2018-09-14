using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAbstratas
{
    public class Retangulo : Forma
    {
        private readonly int largura;
        private readonly int altura;
            
        public Retangulo(int largura, int altura, string id) : base(id)
        {
            this.largura = largura;
            this.altura = altura;            
        }

        public override double Area
        {
            get
            {
                return largura * altura;
            }
        }
    }
}
