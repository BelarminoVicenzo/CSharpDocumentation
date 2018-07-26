using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Teleprompt
{
    class Program
    {
        static void Main(string[] args)
        {
            ExibirTexto().Wait(); 
        }

        private static async Task ExibirTexto()
        {
            IEnumerable<string> palavras = LerArquivo("sampleQuotes.txt");

            foreach (string palavra in palavras)
            {
                Console.WriteLine(palavra);

                if (!string.IsNullOrEmpty(palavra))
                {
                    await Task.Delay(50);
                }
            }
        }

        static IEnumerable<string> LerArquivo(string nomeArquivo)
        {
            string linha;

            using (StreamReader streamReader = File.OpenText(nomeArquivo))
            {
                while ((linha = streamReader.ReadLine()) != null)
                {
                    string[] palavras = linha.Split(' ');

                    int comprimentoLinha = 0;

                    foreach (string palavra in palavras)
                    {
                        yield return palavra;

                        comprimentoLinha += palavra.Length + 1;

                        if (comprimentoLinha > 70)
                        {
                            yield return Environment.NewLine;
                            comprimentoLinha = 0;
                        }
                    }

                    //yield return Environment.NewLine;
                }
            }
        }
    }
}
