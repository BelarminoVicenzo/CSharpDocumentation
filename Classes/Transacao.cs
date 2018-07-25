using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Transacao
    {
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
        public string Observacao { get; set; }

        public Transacao(decimal valor, DateTime dataHora, string observacao)
        {
            Valor = valor;
            DataHora = dataHora;
            Observacao = observacao;
        }



    }
}
