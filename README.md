# C# Documentation

Exemplos da documentação do C# disponibilizada em https://docs.microsoft.com/pt-br/dotnet/csharp/

# Estrutura de um programa C#

Os principais conceitos organizacionais em C# são programas, namespaces, tipos, membros e assemblies.

Tipos estão contidos em namespaces; classes e interfaces são exemplos de tipos; campos, métodos, propriedades e 
eventos são exemplos de membros. 

Quando os programas em C# são compilados, eles são empacotados fisicamente em assemblies que normalmente têm a 
Quando os programas em C# são compilados, eles são empacotados fisicamente em assemblies que normalmente têm a 
extensão de arquivo .exe (aplicativos) ou .dll (bibliotecas).

## Aplicativo Console

O Visual Studio usa um modelo de aplicativo para criar seu projeto. O modelo de aplicativo Console define
automaticamente uma classe `Program` que contém um único método `Main` que usa um array de string como um
parâmetro.

O método `Main` é o ponto de entrada de um aplicativo C#. Esse método é chamado automaticamente pelo tempo de 
execução quando o aplicativo é iniciado. O array de strings definido como seu parâmetro define os parâmetros
de linha de comando fornecidos.

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

## Namespaces

O C# usa namespaces para organizar tipos; namespaces são como pastas virtuais ou lógicas, onde as classes/tipos
são organizados.

Observe que o namespace padrão da aplicação é baseado no diretório físico onde a mesma se encontra.

Namespaces são delimitados por ponto "."

A diretiva `using` também pode ser usada para criar um apelido para um namespace. 

`using Co = Company.Proj.Nested;`

# Classes

Uma classe é uma estrutura que combina ações (métodos) e estado (campos/propriedades) em uma única unidade, ela
fornece uma definição para instâncias da classe criadas dinamicamente, também conhecidas como objetos.

## Classes X Objetos

Embora eles sejam usados algumas vezes de maneira intercambiável, uma classe e um objeto são coisas diferentes:

- A classe define um tipo de objeto, mas não é um objeto em si.
- O objeto é uma entidade concreta com base em uma classe, conhecido como instância de uma classe. Um objeto é 
basicamente um bloco de memória que foi alocado e configurado de acordo com o esquema (classe).

## Instâncias de classes

O operador `new Classe()` transmite a ideia de um novo objeto, por exemplo a abertura de uma *nova* conta
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

## Membros de classes

Campos, propriedades, métodos e eventos em uma classe são denominados de *membros de classe*, esses membros
representam os dados e comportamento da classe.

### Modificadores de acesso/visibilidade de membros

- `public`: acessíveis por qualquer outro código no mesmo assembly ou em outro assembly que faz referência a ele
- `private`: acessíveis apenas para a classe container e para classes derivadas **aninhadas** na mesma
- `protected`: acessíveis apenas para a classe container e classes derivadas
- `internal`: acessíveis apenas para a classe container e  classes derivadas dentro do mesmo assembly

Classes derivadas não podem ter acessibilidade maior do que seus tipos base.

### Membros estáticos e de instância

Os membros de uma classe podem ser estáticos ou de instância. 

>Os membros **estáticos pertencem às classes** e os membros de **instância pertencem aos objetos** (instâncias 
>das classes).

Confira abaixo uma descrição de cada membro de classe:

### Campos

Campos nada mais são que variáveis declaradas diretamente em uma classe, estando dessa forma, disponível no 
escopo da classe. Um campo é uma variável que está associada a estrutura de uma classe. 

>Os campos normalmente armazenam os dados que devem estar acessíveis a mais de um método na classe e devem ser 
>armazenados por mais tempo que o tempo de vida de qualquer método único, as variáveis que não são usadas fora 
>do escopo de um método único devem ser declaradas como variáveis locais dentro do próprio corpo do método.

Você só deve usar campos para variáveis que têm acessibilidade private ou protected. A classe deve expor os dados
para o código externo de maneira segura, fornecendo-os por meio de propriedades e métodos, atavés deles você pode
proteger a classe contra valores de entrada inválidos.

Um campo declarado sem o modificador `static` define um campo de instância. Cada instância da classe terá cópia 
separada desse campo.

No caso de **campos estáticos**, não importa quantas instâncias da classe serão criadas, sempre **haverá apenas 
uma cópia do campo** compartilhado entre todas as instâncias, pois este percente a classe e não a instancia da 
classe (instância/objeto).

>Campos `readonly` (somente leitura) só podem ser alterados na parte da declaração do campo ou no construtor da 
>classe.

### Propriedades

**Propriedades são métodos** de uma classe **acessados como se fossem campos** dessa classe.

As propriedades têm muitos usos: 

- Validar os dados antes de permitir uma alteração; 
- Expor os dados em uma classe em que esses dados são recuperados de outra fonte/origem, como um banco de dados; 
- Executar uma ação quando os dados são alterados, como acionar um evento ou alterar o valor de outros campos.

Uma responsabilidade das propriedades é fornecer proteção para um campo a fim evitar que ele seja alterado sem o
conhecimento do objeto.

As propriedades são uma extensão natural dos campos e diferentemente destes, as propriedades não denotam locais 
de armazenamento, por isso elas têm acessadores que especificam as instruções a serem executadas quando os 
valores forem lidos ou gravados.

Uma propriedade é declarada como um campo, exceto quando a declaração termina com um acessador `get` e/ou um 
acessador `set` gravado entre os delimitadores { e } em vez de terminar com um ponto-e-vírgula `{ get; set; }`.

#### Propriedades autoimplementadas

Em alguns casos, os acessadores `get` e `set` da propriedade apenas atribuem ou recuperam um valor de um campo 
sem incluir nenhuma lógica adicional, nesses casos, você pode usar propriedades autoimplementadas: o compilador 
cria campos privados e anônimos que podem ser acessados somente pelos acessadores `get`e `set` da propriedade, 
assim não é necessário declarar os campos explicitamente no corpo da classe.

Você define uma propriedade autoimplementada usando as palavras-chave `get` e `set` sem fornecer qualquer 
implementação. 

### Métodos

Métodos definem ações que uma classe pode executar.

>Parâmetros são definições de tipo e nome de dados de entrada na assinatura do método
>Argumentos são os valores concretos fornecidos pelo código externo na chamada do método

Por padrão, quando um tipo de valor é passado para um método, é passada uma cópia em vez do objeto propriamente 
dito, assim alterações no argumento não têm nenhum efeito sobre a cópia original. Você pode alterar esse 
comportamento passando um tipo de valor por referência usando a palavra-chave `ref`.

Métodos estáticos podem acessar diretamente apenas membros estáticos, métodos de instância podem acessar membros
estáticos e de instância. Observe o projeto *MetodosEstaticosInstancia* para ver o recurso na prática.

#### Métodos virtuais e métodos abstratos

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

#### Métodos iteradores

Um iterador realiza uma iteração personalizada em uma coleção, como uma lista ou uma matriz. Um iterador usa a 
instrução `yield return` para retornar um elemento da coleção de cada vez.

Os métodos iteradores ou enumeradores retornam sequências que são avaliadas lentamente, isso significa que cada 
item na sequência é gerado conforme a solicitação do código que está consumindo a sequência. Os métodos 
enumeradores contêm uma ou mais instruções `yield return`.

O tipo de retorno de um iterador pode ser `IEnumerable`, `IEnumerable<T>`, `IEnumerator` ou `IEnumerator<T>`.

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

#### Funções locais ou métodos aninhados

Funções locais são métodos privados de um tipo que estão aninhados em outro membro. Eles só podem ser chamados do membro que os contém.

### Construtores

Construtores são métodos chamados automaticamente quando o objeto é criado/instanciado pela primeira vez. 
Geralmente, eles são usados para inicializar os dados de um objeto.

Um construtor é declarado como um método sem nenhum tipo de retorno e o mesmo nome da classe que o contém.

Construtores de instância podem ser sobrecarregados, são invocados usando o operador `new` e não são herdados.

O C# dá suporte aos construtores estáticos e de instância. 

Um construtor de instância é um membro que implementa as ações necessárias para inicializar uma instância de uma
classe. 

Um construtor estático é um membro que implementa as ações necessárias para inicializar uma classe quando ele for 
carregado pela primeira vez. Esse construtor é chamado uma vez, automaticamente, antes de uma instância da classe
ser criada ou algum de seus membros referenciado.

### Eventos

Evento é um membro que permite que uma classe ou objeto forneça notificações sobre ocorrências (como cliques de 
botão ou a conclusão bem-sucedida de um método) na classe container a outras classes e objetos . Um evento é 
declarado como um campo com a palavra chave `event` e seu tipo deverá ser um `delegate`.

Eventos são definidos e disparados por *delegates*.

### Constantes 

Constantes são campos ou propriedades com valores imutáveis, definidos em tempo de compilação e que não são 
alterados durante a vida útil do programa.

### Classes abstratas

Você pode declarar uma classe como abstrata se quiser impedir a instanciação direta usando a palavra-chave new. 
São classes que servem apenas de modelo para classes que herdarão dela. Ela possui propriedades e apenas a 
assinatura de métodos sem sua implementação.

Uma classe abstrata apesar de não poder ser instanciada, pode ter um ou mais construtores, uma vez que esses
construtores podem ser chamados por suas classes derivadas. Elas só podem ser usadas por meio de classes 
derivadas que implementam seus métodos abstratos.

Uma classe abstrata não precisa conter membros abstratos. No entanto, se uma classe contiver um membro abstrato,
ela deverá ser declarada como abstrata.

### Classes estáticas

Uma classe estática não pode ser instanciada, em outras palavras, você não pode usar a palavra-chave `new` para 
criar uma variável do tipo de classe. Como não há nenhuma variável de instância, você acessa os membros de uma 
classe estática usando o próprio nome de classe.

Uma classe estática pode ser usada como um contêiner de métodos que realizam operações (como cálculos) e não 
precisam guardar os dados.

As informações da classe estática são carregadas quando o programa que faz referência à mesma é carregado. O 
programa não pode especificar exatamente quando a classe será carregada, porém é garantido que ela será carregada
e terá seus campos inicializados e seu construtor estático chamado antes que a classe seja referenciada pela 
primeira vez em seu programa. 

Um construtor estático é chamado apenas uma vez e uma classe estática permanece na memória pelo tempo de vida do
do programa.

É mais comum declarar uma classe não estática com alguns membros estáticos do que declarar uma classe inteira 
como estática. 

Métodos estáticos podem ser sobrecarregados, mas não substituídos, porque pertencem à classe e não a qualquer 
instância da classe.

Propriedades e métodos estáticos não podem acessar eventos e campos não estáticos no tipo que os contêm e não 
podem acessar uma variável de instância de nenhum objeto, a menos que esta seja passada explicitamente em um 
parâmetro de método.

Membros estáticos são inicializados antes que o membro estático seja acessado pela primeira vez e antes que o 
construtor estático seja chamado.

>Dois usos comuns dos campos estáticos são manter uma contagem do número de objetos que foram instanciados ou 
>armazenar um valor que deve ser compartilhado entre todas as instâncias.

### Parâmetros de tipo

Uma classe pode especificar um conjunto de *parâmetros de tipo* identicado com uma lista de nome dos tipos
separados por vírgula e entre colchetes angulares:  `public class Par<TPrimeiro,TSegundo>`. Esses parâmetros
servem como um espaço reservado para o tipo real (o tipo concreto) que o código cliente fornecerá ao criar uma 
instância da classe. Os parâmetros podem ser usados no corpo da classe.

Um tipo de classe que é declarado para pegar parâmetros de tipo é chamado de *tipo de classe genérica*.

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

### A palavra reservada this

A instância em que um método de instância foi invocado pode ser explicitamente acessada como `this`. É um erro se
referir a `this` em um método estático.

A classe *Constante* do projeto ClassesAbstratasMetodosVirtuais demonstra e explica a utilização desse recurso.

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

## Adição de dependências em projetos/assemblies distintos

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

# Programação assíncrona

## Métodos assíncronos

Usando `async`, você pode invocar métodos assíncronos sem usar retornos de chamada explícitos (return). 

Se marcar um método com o modificador `async`, você poderá usar o operador `await` no método que o chamou. Quando
o fluxo atinge uma expressão `await` no método assíncrono, ele retorna para o método que o chamou e o progresso 
no método é suspenso até a tarefa aguardada ser concluída. Quando a tarefa for concluída, a execução poderá ser 
retomada no método chamador.

Um método assíncrono retorna para o método chamador quando encontra o primeiro objeto esperado que ainda não está
completo ou chega ao final do método assíncrono, o que ocorrer primeiro.

Um método assíncrono pode conter os tipos de retorno `Task<T>`, `Task` ou `null`. O tipo de retorno `null é usado
principalmente para definir manipuladores de eventos, em que um tipo de retorno nulo é necessário. Um método 
assíncrono que retorna nulo não pode ser aguardado e o chamador de um método de retorno nulo não pode capturar as
exceções que esse método gera.

Apesar de retornar uma `Task`, um método assíncrono não faz uso de `return Task`. Em vez disso, esse objeto `Task`
é criado pelo código gerado pelo compilador quando você usa o operador `await`.

Você pode imaginar que esse método retorna quando atinge um `await`, porém a task retornada indica que o trabalho
não foi concluído, que ainda está em andamento. O método será retomado quando a tarefa em espera for concluída. 
Após a execução completa, a task retornada indicará a conclusão.
