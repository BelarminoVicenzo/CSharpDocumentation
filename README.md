# C# Documentation

Exemplos da documentação do C# disponibilizada em https://docs.microsoft.com/pt-br/dotnet/csharp/

## Introdução

O Visual Studio usa um modelo de aplicativo para criar seu projeto. O modelo de aplicativo Console define
automaticamente uma classe `Program` que contém um único método `Main` que usa um array de string como um
parâmetro.

O método `Main` é o ponto de entrada de um aplicativo C#. Esse método é chamado automaticamente pelo tempo de 
execução quando o aplicativo é iniciado. O array de strings definido como seu parâmetro define os parâmetros
de linha de comando fornecidos.

## Métodos iteradores

Os métodos iteradores ou enumeradores retornam sequências que são avaliadas lentamente, isso significa que cada 
item na sequência é gerado conforme a solicitação do código que está consumindo a sequência. Os métodos 
enumeradores contêm uma ou mais instruções `yield return`.

```
static IEnumerable<string> LerArquivo(string arquivo)
{
    string linha;
    using (StreamReader streamReader = File.OpenText(arquivo))
    {
        while ((linha = streamReader.ReadLine()) != null)
        {
            yield return linha;
        }
    }
}
```

O objeto retornado pelo método LerArquivo contém o código para gerar cada item em sequência. Neste exemplo, isso 
envolve a leitura da próxima linha de texto do arquivo de origem e o retorno dessa cadeia de caracteres. Toda vez
que o código de chamada solicita o próximo item da sequência, o código lê a próxima linha de texto do arquivo e a
retorna. Após a leitura completa do arquivo, a sequência indicará que não há mais itens.

A instrução `using` nesse método gerencia a limpeza de recursos. A variável inicializada na instrução `using` 
(streamReader) deve implementar a interface `IDisposable`. Essa interface define um único método (Dispose) que 
deve ser chamado quando o recurso for liberado. O compilador gera essa chamada quando a execução atingir a chave
de fechamento da instrução `using`. O código gerado pelo compilador garante que o recurso seja liberado, mesmo se
uma exceção for lançada do código no bloco definido pela instrução `using`.

## Herança

A herança de classes expressa o relacionamento "é um" entre uma classe base e suas classes derivadas. Já a 
implementação múltipla de interfaces expressam o relacionamento "pode fazer", pois a interface define um conjunto
mínimo de funcionalidades.

*Herança implícita* denota o fato de que todas as classes no .Net herdam da classe base `Object` ou de algum tipo
derivado dele


### Visibilidade de membros

- `private`: visíveis apenas para a classe base e para classes derivadas aninhadas na mesma
- `protected`: visíveis apenas para classes derivadas
- `internal`: visíveis apenas para classe derivadas dentro do mesmo assembly da classe base

### virtual

Para permitir a sobrescrita de um método da classe base em uma classe derivada, utilize a palavra `virtual` no
método da classe base, muito utilizado quando queremos substituir a implementação de um método na classe base. A
palavra override deve ser utilizada na classe derivada. É uma abordagem para evitar redefinições acidentais. É
possível chamar o conteúdo do método na classe base através da palavra chave `base`

Para obrigar a sobrescrita de um método da classe base em uma classe derivada, utilize a palavra `abstract` no
método da classe base.

### Classes abstratas

São classes que servem apenas de modelo para classes que herdarão dela. Ela possui propriedades e apenas a 
assinatura de métodos.

Uma classe abstrata apesar de não poder ser instanciada, pode ter um ou mais construtores, uma vez que esses
construtores podem ser chamados por suas classes derivadas