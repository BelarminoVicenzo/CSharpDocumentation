using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAbstratasMetodosVirtuais
{
    public class ReferenciaVariavel : Expressao
    {
        string nome;

        public ReferenciaVariavel(string nome)
        {
            this.nome = nome;
        }

        public override double Processar(Dictionary<string, object> variaveis)
        {
            object valor = variaveis[nome];
            if (valor == null)
            {
                throw new Exception($"Variável {nome} desconhecida");
            }
            return Convert.ToDouble(valor);
        }
    }
}
