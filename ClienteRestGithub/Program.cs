using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ClienteWebApi
{
    class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            List<Repositorio> repositorios = ProcessarRepositorio().Result;

            foreach (Repositorio repositorio in repositorios)
            {
                Console.WriteLine(repositorio.Nome);
                Console.WriteLine(repositorio.Descricao);
                Console.WriteLine(repositorio.GitHubHomeUrl);
                Console.WriteLine(repositorio.Homepage);
                Console.WriteLine(repositorio.Seguidores);
                Console.WriteLine(repositorio.UltimoPush);
                Console.WriteLine();
            }
        }

        private static async Task<List<Repositorio>> ProcessarRepositorio()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var serializador = new DataContractJsonSerializer(typeof(List<Repositorio>));

            var streamTarefa = httpClient.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositorios = serializador.ReadObject(await streamTarefa) as List<Repositorio>;
            return repositorios;
        }
    }
}
