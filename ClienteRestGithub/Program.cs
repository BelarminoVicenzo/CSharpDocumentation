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
            ProcessarRepositorio().Wait();
        }

        private static async Task ProcessarRepositorio()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var serializador = new DataContractJsonSerializer(typeof(List<repo>));

            var streamTarefa = httpClient.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositorios = serializador.ReadObject(await streamTarefa) as List<repo>;

            foreach (var repositorio in repositorios)
                Console.WriteLine(repositorio.name);
        }
    }
}
