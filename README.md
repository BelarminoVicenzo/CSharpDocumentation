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

## Adição de dependências em projetos distintos

O aplicativo console OlaMundo, consome uma função programada na *class library* (biblioteca de funções) 
BibliotecaString. Para fazer uso da função:

- Adicionamos o **PROJETO** *BibliotecaString* a lista de dependencias do projeto *OlaMundo* clicando com o botão
  direito do mouse sobre Dependencies

- Fazemos uso do **NAMESPACE** da classe *UteisString* através do comando `@using UteisString`

- Chamamos a **FUNÇÃO** especificando a sua classe container dentro do namespace : 
  `UteisString.ComecaComMaiuscula` 

# Interpolação de strings

É possível formatar a exibição de um dado em uma string interpolada adicionado dois pontos ":" após a expressão
interpolada:

```
string item = "berinjela";
DateTime data = DateTime.Now;
decimal preco = 1.99m;
string unidade = "kg";

Console.WriteLine($"Em {data:d}, o preço da {item} é {preco:C2} por {unidade}.");
```

Para fixar o tamanho da saída de uma expressão interpolada, utilize a vírgula "," após a expressão interpolada
e designe a largura do campo. 

```
string nomeItem = "bola";

Console.WriteLine($"*{nomeItem,6}"); // Resulta em *  bola	
Console.WriteLine($"{nomeItem,-6}*"); // Result em bola  *
``` 

É possível combinar um especificador de alinhamento e de formato em uma única expressão interpolada. Para fazer 
isso, especifique o alinhamento primeiro, seguido por dois-pontos e pela cadeia de caracteres de formato: 

``` 
decimal precoItem = 2.9m;

Console.WriteLine($"*{precoItem,7:C2}"); //Resulta em *  $2.90
Console.WriteLine($"{precoItem,-7:C2}*");//Resulta em $2.90  *
``` 

## Listas genéricas

Você especifica o tipo do dado armazenado na lista entre os símbolos maior e menor `List<string>`

É possível acessar um item da lista individualmente através do seu índice 

``` 
var nomes = new List<string> {"José", "João", "Maria"};

Console.WriteLine(nomes[2]);
``` 

## Namespaces

O C# usa namespaces para organizar tipos; namespaces são como pastas virtuais ou lógicas, onde as classes/tipos
são organizados.

Observe que o namespace padrão da aplicação é baseado no diretório físico onde a mesma se encontra.

## Classes

O operador `new AlgumaClasse()` transmite a ideia de um novo objeto, por exemplo a abertura de uma *nova* conta
bancária. Quando um cliente vai a um banco para abrir uma nova conta bancária, esta deve conter os dados do seu
titular, bem como um saldo inicial. Isso denota o comportamento de um construtor, que em termos práticos de 
programação seria:

```
public class ContaBancaria 
{
	public string Titular { get; set; }
	public decimal Saldo { get; set; }
}

//Abrindo uma nova conta
var novaConta = new ContaBancaria("João da Silva", 0.0m);
```

Construtores são usados para inicializar objetos desse tipo de classe, eles são chamados quando você cria um 
objeto usando `new`. 

# Programação assíncrona

Apesar de retornar uma `Task`, um método assíncrono não faz uso de `return Task`. Em vez disso, esse objeto `Task`
é criado pelo código gerado pelo compilador quando você usa o operador `await`.

Você pode imaginar que esse método retorna quando atinge um `await`, porém a task retornada indica que o trabalho
não foi concluído, que ainda está em andamento. O método será retomado quando a tarefa em espera for concluída. 
Após a execução completa, a task retornada indicará a conclusão.

# Fazendo solicitações da Web

Para fazer solicitações da Web usamos a classe `HttpClient`, um objeto dessa classe manipula a solicitação e as
respostas

# Observações gerais importantes

Os métodos que manipulam cadeias de caracteres (strings) retornam novos objetos string, em vez de fazer 
modificações no objeto local.
