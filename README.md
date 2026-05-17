# Simulador de Física 2D
 
---
 
## Introdução
 
Este projeto consiste na construção de um simulador de física 2D na linha de comando em linguagem C#. Neste simulador é possível adicionar vários projetos em que cada projeto terá as suas partículas, cada uma delas com as suas forças.
 
Tendo adicionado tudo para uma simulação, é possível simular movimentos (**Cinemática**) e forças resultantes (**Dinâmica**).
 
---

## Comandos do Projeto
 
| Comando | Descrição | 
|---------|-----------:|
| `RPJ`   | Registar Projeto |
| `LPJ`   | Listar Projetos |
| `SPJ`   | Selecionar Projeto |
| `RP`    | Registar Partícula |
| `RF`    | Registar Força |
| `LP`    | Listar Partículas |
| `TG`    | Toggle Gravidade |
| `SMC`   | Simulação Cinemática |
| `SMD`   | Simulação Dinâmica |
| `Test`  | Correr Testes Unitários (Extra) |
| `Exit`  | Terminar o Programa |

---
 
## Variáveis e Fórmulas
 
### `GetResultantForce()` — Cálculo da Força Resultante e Peso
 
Soma as componentes em X e as componentes em Y de todas as forças na partícula.  
Se a gravidade estiver ligada, é feita a alteração no peso.
 
```
Força Resultante = somatório de todas as forças
Py = massa × gravidade
```
 
> Estamos a aplicar a **2ª Lei de Newton** para descobrir a força total aplicada nas partículas no eixo do X e do Y.
 
---
 
### `GetAccelerationX()` — Obtem a Aceleração no Eixo do X
 
Calcula a aceleração no eixo do X.
 
```
aceleração = força em X / massa
```
 
> Estamos a aplicar a **2ª Lei de Newton** para descobrir a aceleração e a alteração na velocidade da simulação no eixo do X.
 
---
 
### `GetAccelerationY()` — Obtem a Aceleração no Eixo do Y
 
Calcula a aceleração no eixo do Y.
 
```
aceleração = força em Y / massa
```
 
> Estamos a aplicar a **2ª Lei de Newton** para descobrir a aceleração e a alteração na velocidade da simulação no eixo do Y.
 
---
 
### `CalculatePOS()` — Calcula a Posição num Instante de Tempo
 
Calcula a posição com base num tempo *t*. É utilizada a fórmula do **MRUV** (Movimento Retilíneo Uniformemente Variado), pois quando a aceleração é igual a 0, fica equivalente à fórmula do **MRU** (Movimento Retilíneo Uniforme).
 
```
posição(t) = posição(0) + velocidade(0) × t + ½ × aceleração × t²
```
 
> Usada para descobrir a posição da partícula num intervalo de tempo nas simulações.
 
---
 
### `CalculateVel()` — Equação da Velocidade
 
Calcula a velocidade da partícula num instante de tempo.
 
```
velocidade(t) = velocidade(0) + aceleração × t
```
 
> Determina como a velocidade varia ao longo do tempo nas simulações.
 
---
 
### `GetMagnitude()` — Magnitude de um Vetor
 
```
|V| = √(X² + Y²)
```
 
---
 
### `AngleInDegrees()` — Ângulo em Graus
 
```
θ = arctan(Y / X) × (180 / π)
```
 
> `GetMagnitude` e `AngleInDegrees` são usados para transformar as componentes de coordenadas **cartesianas** (X, Y) para **coordenadas polares** (módulo, ângulo).
 
---
 
### `Distance()` — Obtem o Deslocamento Percorrido
 
Calcula o deslocamento total feito pela partícula.
 
```
distância = √((X2 - X1)² + (Y2 - Y1)²)
```
 
> Usada para mostrar o deslocamento percorrido pela partícula na simulação.
 
---
 
## Caso de Estudo
 
Para este caso de estudo, nós resolvemos o problema em lápis e caneta (Usamos OneNote), sendo depois verificado se os resultados correspondem aos do programa.
 
O estudo de caso está realizado no ficheiro `estudoCasoFPA.pdf`.
 
---
 
## Testes Unitários
 
Para os testes unitários usamos uma abordagem diferente, em vez de usar uma biblioteca de testes como o **NUnit** ou **xUnit**, foram criadas funções próprias para testar a funcionalidade do programa. As bibliotecas mencionadas apresentaram problemas na execução dos testes, quando as tentamos usar, além de exigirem a instalação de packages e configuração do ambiente, o que poderia ser um obstáculo para correr os testes no computador da professora.
 
### Como Correr os Testes
 
Correr o programa normalmente e utilizar um dos seguintes comandos:
 
| Comando                | Descrição                                          |
|------------------------|----------------------------------------------------|
| `Test`                 | Corre todos os testes                              |
| `Test [Nome do Teste]` | Corre um teste específico pelo nome do método      |
 
> **Nota:** Os nomes dos métodos de teste foram mantidos o mais descritivos possível para facilitar a identificação e compreensão do que testam.
 
---
 
| Tipo                | Justificação |
|---------------------|--------------|
| `double`            | Usamos doubles para as variaveis numericas, pois permite o uso de casas decimais e é mais preciso para os calculos de fisica, onde a precisão é importante. |
| `Dictionary`        | Nos usamos um Dictionary para armazenar os projetos, pois permite o acesso rapido sem ter de iterar por uma lista, podendo acessar o projeto que queremos por um nome unico que é a chave. |
| `OrderedDictionary` | Usamos um OrderedDictionary para armazenar as particulas, pois é mais eficiente para acessar as particulas diretamente por um nome em vez de iterar por uma lista, por ser um OrderedDictionary, ele organiza os elementos Alfabeticamente como pedido no enunciado. |
| `List`              | Para as forças usamos uma List, pois nos não vimos necessidade de acessar as forças individualmente, pois as forças são usadas em conjunto. |

---
## Membros do Grupo: 
- Leandro Santos 20252147
- Henrique Carvalho 20250852
- Guilherme Soares 20252152
- Henrique Metelo 20252138
---

## Nota sobre README

O README foi escrito por todos nós mas usamos o Claude para ajudar a formatar o texto e deixar o design mais bonito em Markdown. 