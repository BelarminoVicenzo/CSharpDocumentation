using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAbstratasMetodosVirtuais
{
    public class Operacao : Expressao
    {
        Expressao esquerda;
        char operador;
        Expressao direita;

        public Operacao(Expressao esquerda, char operador, Expressao direita)
        {
            this.esquerda = esquerda;
            this.operador = operador;
            this.direita = direita;
        }

        public override double Processar(Dictionary<string, object> variaveis)
        {
            double x = esquerda.Processar(variaveis);
            double y = direita.Processar(variaveis);

            switch (operador)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
            }

            throw new Exception("Operador desconhecido");
        }
    }
}