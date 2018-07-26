# C# Documentation

Exemplos da documentação do C# disponibilizada em https://docs.microsoft.com/pt-br/dotnet/csharp/

# Estrutura de um programa C#

Os principais conceitos organizacionais em C# são programas, namespaces, tipos, membros e assemblies.

Tipos estão contidos em namespaces; classes e interfaces são exemplos de tipos; campos, métodos, propriedades e 
eventos são exemplos de membros. 

Quando os programas em C# são compilados, eles são empacotados fisicamente em assemblies que normalmente têm a 
extensão de arquivo .exe (aplicativos) ou .dll (bibliotecas).

## Compilação

O C# permite que o texto de origem (código fonte) de um programa seja armazenado em vários arquivos de origem
(arquivos .cs). Quando um programa em C# que possui vários arquivo é compilado, todos os arquivos de origem são 
processados juntos, é como se todos os arquivos de origem fossem concatenados em um arquivo grande antes de serem
processados.

## Tipos de referência e tipos de valor

Há dois tipos em C#: tipos de referência e tipos de valor. As variáveis de tipos de valor contêm diretamente seus
dados enquanto variáveis de tipos de referência armazenam referências a seus dados (objetos). Com tipos de 
referência, é possível que duas variáveis referenciem o mesmo objeto e, portanto, é possível que operações em uma
variável afetem o objeto referenciado por outra variável. Com tipos de valor, cada variável tem sua própria cópia
dos dados e não é possível que operações em uma variável afetem a outra (exceto no caso de variáveis de 
parâmetros `ref` e `out`).

## Classes

Uma classe é uma estrutura que combina ações (métodos) e estado (campos/propriedades) em uma única unidade, ela
fornece uma definição para instâncias da classe criadas dinamicamente, também conhecidas como objetos.

# Membros de classes

Os membros de uma classe podem ser estáticos ou de instância. 

>Os membros **estáticos pertencem às classes** e os membros de **instância pertencem aos objetos** (instâncias das classes).

### Acessibilidade/Visibilidade de membros

- `private`: visíveis apenas para a classe base e para classes derivadas aninhadas na mesma
- `protected`: visíveis apenas para classes derivadas
- `internal`: visíveis apenas para classe derivadas dentro do mesmo assembly da classe base

### Parâmetros de tipo

Uma classe pode especificar um conjunto de parâmetros de tipo (o nome da classe com colchetes angulares e uma 
lista de nomes de parâmetros de tipo separados por vírgulas) `public class Par<TPrimeiro,TSegundo>`. Os parâmetros 
podem ser usados no corpo da classe.

Um tipo de classe que é declarado para pegar parâmetros de tipo é chamado de *tipo de classe genérica*.

### Campos

Um campo é uma variável que está associada a estrutura de uma classe. Um campo declarado sem o modificador 
`static` define um campo de instância. Cada instância da classe terá cópia separada desse campo.

No caso de **campos estáticos**, não importa quantas instâncias da classe são criadas, sempre **haverá apenas 
uma cópia do campo** compartilhado entre todas as instâncias, pois este percente a classe e não a instancia da 
classe (objeto).

Campos `readonly` (somente leitura) só podem ser alterados na parte da declaração do campo ou no construtor da 
classe.

### Métodos

Métodos estáticos podem acessar diretamente apenas membros estáticos, métodos de instância podem acessar membros
estáticos e de instância. Observe o projeto *MetodosEstaticosInstancia* para ver o recurso na prática.

### Herança

Herança é um recurso das linguagens de programação orientadas a objeto que permite a definição de uma classe 
base (classe pai) que fornece funcionalidades (dados e comportamento) a classes derivadas (classes filhas) que 
herdam (reutiliza), estendem ou modificam tais funcionalidades.

A classe cujos membros são herdados é chamada de classe base. A classe que herda os membros da classe base é 
chamada de classe derivada.

A herança de classes expressa o relacionamento "é um" entre uma classe base e suas classes derivadas. Já a 
implementação múltipla de interfaces expressam o relacionamento "pode fazer", pois a interface define um conjunto
mínimo de funcionalidades.

*Herança implícita* denota o fato de que todas as classes no .Net herdam da classe base `Object` ou de algum tipo
derivado dele

### A palavra reservada this

A instância em que um método de instância foi invocado pode ser explicitamente acessada como `this`. É um erro se
referir a `this` em um método estático.

A classe *Constante* do projeto ClassesAbstratasMetodosVirtuais demonstra e explica a utilização desse recurso.

### Métodos virtuais

Para permitir a sobrescrita de um método da classe base em uma classe derivada, utilize a palavra `virtual` no
método da classe base. Esse recursos é muito utilizado quando queremos substituir ou estender implementação de um
método que foi definido na classe base. A palavra `override` deve ser utilizada na classe derivada. Sua utilização
é uma medida de segurança para evitar redefinições acidentais. É possível chamar o conteúdo do método da classe 
base na classe derivada através da palavra chave `base`

### Métodos abstratos

Para obrigar a sobrescrita de um método da classe base em uma classe derivada, utilize a palavra `abstract` no
método da classe base.

Um método abstrato é um método virtual sem implementação; é permitido somente em uma classe que também é 
declarada como abstrata.

Observe o projeto ClassesAbstratasMetodosVirtuais para entender melhor o conceito.

### Classes abstratas

São classes que servem apenas de modelo para classes que herdarão dela. Ela possui propriedades e apenas a 
assinatura de métodos.

Uma classe abstrata apesar de não poder ser instanciada, pode ter um ou mais construtores, uma vez que esses
construtores podem ser chamados por suas classes derivadas

# Instâncias de classes

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

### Construtores

Um construtor é declarado como um método sem nenhum tipo de retorno e o mesmo nome da classe que o contém.

Construtores de instância podem ser sobrecarregados, são invocados usando o operador `new` e não são herdados.

O C# dá suporte aos construtores estáticos e de instância. Um construtor de instância é um membro que implementa 
as ações necessárias para inicializar uma instância de uma classe. Um construtor estático é um membro que 
implementa as ações necessárias para inicializar uma classe quando ele for carregado pela primeira vez.

### Propriedades

As propriedades são uma extensão natural dos campos, diferentemente destes, as propriedades não denotam locais de
armazenamento, por isso elas têm acessadores que especificam as instruções a serem executadas quando os valores 
forem lidos ou gravados.

Uma propriedade é declarada como um campo, exceto quando a declaração termina com um acessador `get` e/ou um 
acessador `set` gravado entre os delimitadores { e } em vez de terminar com um ponto-e-vírgula `{ get; set; }`.

### Eventos
Um evento é um membro que permite que uma classe ou objeto forneça notificações. Um evento é declarado como um 
campo com a palavra chave `event` e seu tipo deverá ser um `delegate`.

### Delegates

Um Delegate representa referências a métodos, possibilitam o tratamento de métodos como entidades que podem ser 
atribuídas a variáveis e passadas como parâmetros.

São parecidos com o conceito de ponteiros de função em outras linguagens, mas ao contrário dos ponteiros de 
função, são orientados a objetos e fortemente tipados.

```
delegate double Funcao(double x);

class Multiplicador
{
    double fator;
    public Multiplicador(double fator) 
    {
        this.fator = fator;
    }
    public double Multiplicar(double x) 
    {
        return x * fator;
    }
}
```

O exemplo acima declara e usa um tipo delegado chamado Funcao. Nesse caso, uma instância do delegate Funcao pode 
fazer referência a qualquer método que usa um parâmetro `double` e retorna um valor `double`.

Delegates podem ser criados usando funções anônimas, que são "métodos embutidos" criados dinamicamente. Funções 
anônimas podem ver as variáveis locais dos métodos ao redor: 

```
double[] dobro =  Dobrar(a, (double x) => x * 2.0);
```

### Arrays (matrizes e vetores)

Matriz é uma estrutura de dados que contém algumas variáveis acessadas por meio de índices calculados, elas não 
precisam ser declaradas antes de serem usadas. Em vez disso, os tipos de matriz são construídos utilizando o nome
do tipo seguido de colchetes:

- `int[]` = matriz unidimensional
- `int[3]` = matriz unidimensional com três elementos do tipo `int`, cada elemento possui o valor inicial `null`
- `int[] a = new int[] {1, 2, 3}` = matriz unidimensional com três elementos, cada elemento possui seu valor definido
- `int[] a = {1, 2, 3}` = mesma estrutura do exemplo acima
- `int[,]` = matriz bidimensional
- `int[][]` = matriz unidimensional da matriz unidimensional

O operador `new` permite que os valores iniciais dos elementos da matriz sejam especificados através de um 
inicializador de matriz (uma lista de expressões entre chaves), observe o terceiro exemplo da lista acima, o 
tamanho da matriz é inferido do número de expressões entre chaves.

O número de dimensões de um tipo de matriz é o número um (1) mais (+) o número de vírgulas escrito entre os 
colchetes do tipo de matriz.

### Enumeradores

Enumeradores são tipos com um conjunto de constantes nomeadas. É utilizado quando você quer delimitar os valores
que o tipo pode ter. 

```
enum Alinhamento: sbyte
{
    Esquerda = -1,
    Centro = 0,
    Direira = 1
}
```

O código acima define um enumerador que possui o seu tipo subjacente `sbyte`

### Nullable types

Os tipos de valor anulável também não precisam ser declarados antes de serem usados.

## Aplicativo Console

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

Para usar caracteres de escape em strings interpoladas faça o seguinte:

- Para obter `{` informe `{{`
- Para obter `\`informe `\\`
- Para obter literalmente um string interpolada utilize `$@"expressao_interpolada"`. Nesse caso, os caracteres de 
  escape serão tratados como literais

Como os dois-pontos (:) têm um significado especial em um item com uma expressão interpolada, para usar um 
operador condicional ternario em uma expressão, coloque-a entre parênteses: 
`$"Você (Idade > 18 : "não", "") é maior de idade"`

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

# Atributos

Atributos fornecem uma maneira de associar informações ao código de forma declarativa, também fornecem um 
elemento reutilizável que pode ser aplicado a uma variedade de destinos: classes, structs, métodos, construtores 
e muito mais. As marcações de atributos são fáceis de identificar, pois sempre estão entre colchetes: `[Atributo]`

No C#, os atributos são classes que herdam da classe base Attribute. Seus construtores públicos controlam as 
informações que devem ser fornecidas quando o atributo é anexado a uma entidade. Informações adicionais podem ser
fornecidas ao através de propriedades públicas da classe do atributo

Um atributo também pode ser entendido como um modificador que controla alguns comportamentos de tipos e membros.

# Reflexão

A ideia básica de Reflexão é que você escreva um código que examine outro código.