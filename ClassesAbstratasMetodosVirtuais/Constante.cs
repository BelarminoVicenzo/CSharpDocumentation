using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAbstratasMetodosVirtuais
{
    public class Constante : Expressao
    {
        double valor;

        public Constante(double valor)
        {
            /*Observe o uso da palavra this: 
             * Temos dois membros de nomes iguais (valor), o primeiro é o parâmetro do construtor e o segundo
             * é um campo da instancia da classe. 
             * 
             * Mas como saberemos qual valor estamos usando?
             * 
             * A palavra reservada "this" indica que o valor a esquerda do operador de atribuição "=" é 
             * referente ao campo da instancia da classe
             */
            
            this.valor = valor;
        }

        public override double Calcular(Dictionary<string, object> variaveis)
        {
            throw new NotImplementedException();
        }
    }
}
