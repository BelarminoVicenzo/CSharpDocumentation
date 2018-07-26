using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class ContaBancaria
    {
        public string Numero { get; set; }
        public string Titular { get; set; }
        public decimal Saldo
        { get
            {
                decimal saldo = 0;

                foreach (Transacao transacao in transacoes)
                {
                    saldo += transacao.Valor;
                }
                return saldo;
            }
        }

        private List<Transacao> transacoes = new List<Transacao>();
        private static int controladorNumeroConta = 1234567890;

        public ContaBancaria(string titular, decimal saldoInicial)
        {
            this.Numero = controladorNumeroConta.ToString();
            controladorNumeroConta++;

            Titular = titular;
            Depositar(saldoInicial, DateTime.Now, "Saldo inicial");
        }

        public void Depositar(decimal valor, DateTime dataHora, string observacao)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor do depósito deve ser maior do que zero");
            }

            Transacao deposito = new Transacao(valor, dataHora, observacao);
            transacoes.Add(deposito);
        }   

        public void Sacar(decimal valor, DateTime dataHora, string observacao)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor do depósito deve ser maior do que zero");
            }

            if (Saldo - valor < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Saldo insuficiente");
            }

            Transacao saque = new Transacao(-valor, dataHora, observacao);
            transacoes.Add(saque);
        }

        public string ListarHistorico()
        {
            var historico = new System.Text.StringBuilder();

            historico.AppendLine("\nData\t\tValor\t" +
                "Observacao");
            foreach (var item in transacoes)
            {
                historico.AppendLine($"{item.DataHora.ToShortDateString()}\t{item.Valor}\t{item.Observacao}");
            }

            return historico.ToString();
        }
    }
}
