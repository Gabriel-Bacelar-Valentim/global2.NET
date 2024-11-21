# gs2.NET

<h1>Integrantes:</h1>
Lucas dos Santos Lopes RM:550790
Murilo Machado RM:550718
Victor Taborda Rodrigues RM:97900
Gustavo Marques Catelan RM:551823
Gabriel Bacelar Valentim RM:97901

<h1>Explicação da Arquitetura:</h1>

A arquitetura do projeto segue um modelo de microsserviços, onde a aplicação é dividida em múltiplos serviços independentes, cada um responsável por uma função específica e com sua própria base de dados. Cada microsserviço é desenvolvido, implantado e escalado de forma independente, o que proporciona maior flexibilidade, resiliência e facilidade de manutenção. Embora cada serviço opere de maneira autônoma, eles se comunicam entre si através de APIs, permitindo a integração entre as diferentes partes do sistema, de forma descentralizada e escalável. Esse modelo promove uma maior modularização e permite a adaptação rápida às mudanças e necessidades do negócio.

<h1>Justificativa da escolha:</h1>

Optou-se por uma arquitetura de microsserviços para garantir escalabilidade, flexibilidade e facilidade de manutenção no longo prazo. Este modelo permite que os diferentes componentes da aplicação sejam desenvolvidos, implantados e escalados de forma independente, o que é essencial em ambientes dinâmicos e de rápido crescimento. A escolha pela arquitetura de microsserviços é especialmente vantajosa em cenários que exigem alta disponibilidade, agilidade no desenvolvimento e maior resiliência a falhas. Além disso, ela favorece a adoção de tecnologias e ferramentas específicas para cada serviço, otimizando o desempenho e a adaptabilidade da solução conforme as necessidades do negócio evoluem.

<h1>Instruções para rodar a API</h1>

1- Clone o repositório ou extraia os arquivos zipados dentro do Visual Studio 2022.
2- No Visual Studio, selecione o modo de execução https.
3- Clique em Run para iniciar a API.
4- Você será direcionado automaticamente para o Swagger no endereço:
https://localhost:7201/swagger/index.html
Esse será o ambiente onde você poderá testar as requisições da API.

<h1>Testes das Controllers</h1>
Os testes das controllers garantem o correto funcionamento dos métodos de cada uma, assegurando que os comportamentos esperados sejam cumpridos para as operações CRUD (Create, Read, Update, Delete) e respostas HTTP adequadas.

1- Verifica se o método de adicionar os objetos chama o repositório corretamente e retorna um status HTTP 201 (Created).
2- Garante que o método para obter os objetos do repositório retorna uma lista com status HTTP 200 (OK).
3- Verifica se a atualização de cada objeto é feita corretamente e retorna HTTP 204 (No Content).
4- Confirma que a atualização de um objeto sem um ID válido retorna erro HTTP 400 (Bad Request).
5- Garante que a exclusão de um dos objetos seja realizada corretamente, retornando HTTP 204 (No Content).
6- Verifica que a tentativa de excluir um objeto inexistente retorna HTTP 404 (Not Found).

Esses testes asseguram que todas as operações sejam executadas corretamente, com as respostas adequadas em cada cenário.

<h1>Funcionalidade da IA</h1>

Nós desenvolvemos uma IA preditiva que com base nos dados do csv, que fora implementado, ela irá prever o consumo medio de energia do usuario a partir de dados coletados anualmente.

<h1>Praticas de Clean Code</h1>

-Nomes Significativos
-Estruturacao Consistente
-Codigo Autoexplicativo
-Organizacao do Codigo
-Principio DRY
