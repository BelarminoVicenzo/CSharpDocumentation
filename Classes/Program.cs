using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria contaBancaria = new ContaBancaria("João da Silva", 1123.35m);

            contaBancaria.Sacar(500, DateTime.Now, "Pagamento de aluguel");
            Console.WriteLine(contaBancaria.Saldo);
            contaBancaria.Depositar(100, DateTime.Now, "Um amigo me pagou um empréstimo");
            Console.WriteLine(contaBancaria.Saldo);

            Console.WriteLine(contaBancaria.ListarHistorico());
            Console.ReadLine();
        }
    }
}
