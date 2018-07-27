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

Há dois tipos em C#: tipos de referência e tipos de valor. 

Variáveis de tipos de valor contêm diretamente seus dados enquanto variáveis de tipos de referência armazenam 
referências a seus dados (objetos). Com tipos de referência, é possível que duas variáveis referenciem o mesmo 
objeto e, portanto, é possível que operações em uma variável afetem o objeto referenciado por outra variável. 
Com tipos de valor, cada variável tem sua própria cópia dos dados e não é possível que operações em uma variável
afetem a outra (exceto no caso de variáveis de parâmetros `ref` e `out`).

Um tipo que é definido como uma classe, delegate, matriz ou interface é um tipo de referência.

Structs são tipos de referência assim, uma variável do tipo struct guarda uma cópia do objeto inteiro.

## Classes

Uma classe é uma estrutura que combina ações (métodos) e estado (campos/propriedades) em uma única unidade, ela
fornece uma definição para instâncias da classe criadas dinamicamente, também conhecidas como objetos.

## Classes X Objetos

Embora eles sejam usados algumas vezes de maneira intercambiável, uma classe e um objeto são coisas diferentes:

- A classe define um tipo de objeto, mas não é um objeto em si.
- O objeto é uma entidade concreta com base em uma classe, conhecido como instância de uma classe. Um objeto é 
basicamente um bloco de memória que foi alocado e configurado de acordo com o esquema (classe).

### Comparação de objetos e igualdade de valor

Em primeiro lugar, precisamos distinguir se queremos saber se duas ou mais variáveis representam o mesmo objeto 
na memória ou se os valores de um ou mais de seus campos são iguais:

- Para determinar se duas instâncias de classe se referem ao mesmo local na memória, use o método `Equals` estático;
- Para determinar se os campos das instâncias têm os mesmos valores, use o método `Equals` da instância

```
Pessoa p1 = new Pessoa("Wallace", 37);
Pessoa p2;
p2.Nome = "Wallace";
p2.Idade = 37;

if (p2.Equals(p1))
    Console.WriteLine("p2 e p1 possuem os mesmo valores");
```

### Classes abstratas

Você pode declarar uma classe como abstrata se quiser impedir a instanciação direta usando a palavra-chave new. 
São classes que servem apenas de modelo para classes que herdarão dela. Ela possui propriedades e apenas a 
assinatura de métodos sem sua implementação.

Uma classe abstrata apesar de não poder ser instanciada, pode ter um ou mais construtores, uma vez que esses
construtores podem ser chamados por suas classes derivadas. Elas só podem ser usadas por meio de classes 
derivadas que implementam seus métodos abstratos.

Uma classe abstrata não precisa conter membros abstratos. No entanto, se uma classe contiver um membro abstrato,
ela deverá ser declarada como abstrata.

# Membros de classes

Campos, propriedades, métodos e eventos em uma classe são denominados de membros de classe

Os membros de uma classe podem ser estáticos ou de instância. 

>Os membros **estáticos pertencem às classes** e os membros de **instância pertencem aos objetos** (instâncias das classes).

### Acessibilidade/Visibilidade de membros

- `private`: visíveis apenas para a classe base e para classes derivadas aninhadas na mesma
- `protected`: visíveis apenas para classes derivadas
- `internal`: visíveis apenas para classe derivadas dentro do mesmo assembly da classe base

### Parâmetros de tipo

Uma classe pode especificar um conjunto de *parâmetros de tipo* identicado com uma lista de nome dos tipos
separados por vírgula e entre colchetes angulares:  `public class Par<TPrimeiro,TSegundo>`. Esses parâmetros
servem como um espaço reservado para o tipo real (o tipo concreto) que o código cliente fornecerá ao criar uma 
instância da classe. Os parâmetros podem ser usados no corpo da classe.

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

A classe cujos membros são herdados é chamada de classe base, a classe que herda os membros da classe base é 
chamada de classe derivada.

A herança de classes expressa o relacionamento "é um" entre uma classe base e suas classes derivadas. Já a 
implementação múltipla de interfaces expressam o relacionamento "pode fazer", pois a interface define um conjunto
mínimo de funcionalidades.

Conceitualmente, uma classe derivada é uma especialização da classe base. Por exemplo, se tiver uma classe base 
Animal, você terá uma classe derivada chamada Mamífero e outra classe derivada chamada Reptil. Mamífero e Réptil 
são tipos mais específicos que Animal. Cada classe derivada representa especializações diferentes da classe base.

*Herança implícita* denota o fato de que todas as classes no .Net herdam da classe base `Object` ou de algum tipo
derivado dele.

Uma classe derivada pode ocultar membros da classe base declarando membros com mesmo nome e assinatura. O 
modificador new pode ser usado para indicar explicitamente que o membro não pretende ser uma substituição do 
membro base: 

```
public class BaseClass
{
    public void DoWork() { WorkField++; }
    public int WorkField;
    public int WorkProperty
    {
        get { return 0; }
    }
}

public class DerivedClass : BaseClass
{
    public new void DoWork() { WorkField++; }
    public new int WorkField;
    public new int WorkProperty
    {
        get { return 0; }
    }
}
```

### Polimorfismo

O polimorfismo pode ser expresso de duas formas: 

- Em tempo de execução, os objetos de uma classe derivada podem ser tratados como objetos de uma classe base
- Classes base podem definir e implementar métodos virtuais e classes derivadas podem substituí-los, o que 
significa que elas fornecem sua própria definição e implementação.

### A palavra reservada this

A instância em que um método de instância foi invocado pode ser explicitamente acessada como `this`. É um erro se
referir a `this` em um método estático.

A classe *Constante* do projeto ClassesAbstratasMetodosVirtuais demonstra e explica a utilização desse recurso.

### Métodos virtuais e métodos abstratos

Quando uma classe base declara um método como virtual, uma classe derivada **PODE** substituir o método por sua 
própria implementação. Se uma classe base declarar um membro como abstrato, esse método **DEVE** ser substituído
em qualquer classe não abstrata que herdar diretamente da classe.

Para permitir a sobrescrita de um método da classe base em uma classe derivada, utilize a palavra `virtual` no
método da classe base. Esse recursos é muito utilizado quando queremos substituir ou estender a implementação de 
um método que foi definido na classe base. A palavra `override` deve ser utilizada na classe derivada. Sua 
utilização é uma medida de segurança para evitar redefinições acidentais. É possível chamar o conteúdo do método
da classe base na classe derivada através da palavra chave `base`

Para obrigar a sobrescrita de um método da classe base em uma classe derivada, utilize a palavra `abstract` no
método da classe base. Um método abstrato é um método virtual sem implementação; é permitido somente em uma 
classe que também é declarada como abstrata.

Observe o projeto ClassesAbstratasMetodosVirtuais para entender melhor o conceito.

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

O C# dá suporte aos construtores estáticos e de instância. 

Um construtor de instância é um membro que implementa as ações necessárias para inicializar uma instância de uma
classe. 

Um construtor estático é um membro que implementa as ações necessárias para inicializar uma classe quando ele for 
carregado pela primeira vez. Esse construtor é chamado uma vez, automaticamente, antes de uma instância da classe
ser criada ou algum de seus membros referenciado.

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

### Tipos anônimos

Em alguns casos, é inconveniente criar uma classe para conjuntos simples de valores que você não pretende 
armazenar ou transmitir fora dos limites de método. Você pode criar *tipos anônimos* para isso.

### Tipo dinâmico

Na maioria dos casos, dynamic funciona como se tivesse o tipo object. O tipo dynamic dá suporte a qualquer 
operação, se código for inválido os erros serão capturados em tempo de execução.

Assim como `null`, a maior parte de operações que usam dynamic retornam dynamic.

### Tuplas

É comum querer retornar mais de um valor de um método. Você pode criar tipos de tupla que retornam vários valores
em uma única chamada de método.

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

Namespaces são delimitados por ponto "."

A diretiva `using` também pode ser usada para criar um apelido para um namespace. 

`using Co = Company.Proj.Nested;`

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