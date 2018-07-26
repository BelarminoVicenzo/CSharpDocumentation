using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAbstratasMetodosVirtuais
{
    public abstract class Expressao
    {
        //Por ser uma classe abstrata não há uma implementação do método, apenas a definição de sua assinatura
        public abstract double Calcular(Dictionary<string, object> variaveis);
    }
}
