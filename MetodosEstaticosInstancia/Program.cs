using System;

namespace MetodosEstaticosInstancia
{
    class Program
    {
        static void Main(string[] args)
        {
            //O método estático define o valor para o membro estático proximoNumeroSerie
            //Assim esse valor será compartilhado por todas as instancias que serão criadas pois o valor
            //pertence a classe e não a instancia
            Bateria.DefinirSequenciaInicial(1000);

            //Nesse momento o construtor incrementa o membro de classe proximoNumeroSerie em 1 e passa o seu 
            //valor incrementado para o membro de instância NumeroSerie
            Bateria bateria1 = new Bateria();

            //A próxima instância repete o passo anterior compartilhando os membros de classe com a primeira
            //instancia
            Bateria bateria2 = new Bateria();

            Console.WriteLine(bateria1.ObterNumeroSerie());       // Exibe 1000
            Console.WriteLine(bateria2.ObterNumeroSerie());       // Exibe 1001
            Console.WriteLine(Bateria.ObterProximoNumeroSerie()); // Exibe 1002
        }
    }
}
