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
            IEnumerable<string> linhas = LerArquivo("sampleQuotes.txt");

            foreach (string linha in linhas)
            {
                Console.WriteLine(linha);

                if (!string.IsNullOrEmpty(linha))
                {
                    var pausa = Task.Delay(50);
                    pausa.Wait();
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
