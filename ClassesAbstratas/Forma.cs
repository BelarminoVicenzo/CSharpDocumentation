using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAbstratas
{
    public abstract class Forma
    {
        private string nome;

        public Forma(string s)
        {
            //Chama o acessador set da proriedade Id
            Id = s;
        }

        public string Id {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        //Area é uma propriedade somente leitura, pois é obtida através de um cálculo
        //Ao declarar uma propriedade abstrata, você simplesmente indica quais acessadores de propriedade 
        //estão disponíveis, mas não os implementa.
        public abstract double Area
        {
            get;
        }

        public override string ToString()
        {
            return $"Area = {Area:F2}";
        }
    }
}
