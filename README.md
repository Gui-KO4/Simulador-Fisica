# Simulador-Fisica

>## Introdução
>
>Este projeto consiste na construçao de um simulador de fisica 2D na linha de comando em linguagem C#, Neste simulador é possivel adicionar varios projetos em que cada projeto tera as suas particulas cada uma delas com as suas forças.
>Tendo adicionado tudo para uma simulaçao é possível simular movimentos(Cinemática) e forças resultantes(Dinâmica)
>
>## Variaveis e Formulas
>>### GetResultantForce() -> Calculo da Força Resultante e Peso
>>Soma as componentes em X e as componentes em Y de todas as forças na particula
>>Se a gravidade estiver ligada fazemos a alteração no peso
>>Força resultante = somatorio de todas forças
>>Py = massa . gravidade
>>Estamos a aplicar a 2ª lei de Newton para descobrir a força total aplicada nas particulas no eixo do x e do y
>
>>### GetAccelerationX -> Obtem a aceleração no eixo do x
>>Calcula a acelaração no eixo do x
>>acelaração = força em X / massa
>>Estamos a aplicar a 2ª lei de Newton para descobrir a acelaração para descobrir a alteração na velocidade na simulação no eixo do x
>
>>### GetAccelerationX -> Obtem a aceleração no eixo do y
>>Calcula a acelaração no eixo do y
>>acelaração = força em y / massa
>>Estamos a aplicar a 2ª lei de Newton para descobrir a acelaração para descobrir a alteração na velocidade na simulação no eixo do y

>>### CalculatePOS() -> Calculo da posição num instante de tempo
>>Calcula a posiçao com base num tempo t. Utilizamos a formula do MRUV(movimento Retilíneo Uniformemente Variado) porque se a acelaraçao for equal a 0 ela fica equivalente a formula do MRU (Movimento Retilíneo Uniform)
>>posição(tempo) = posicao no instante(0) + velocidade no instante (0) . tempo + 1/2.acelaração.t^2
>>Utilizamos esta formula para descobrir a posição da particula num intervalo de tempo nas simulações
>
>>### CalculateVel() -> Equação da velocidade
>>Calcula da particula num instante de tempo
>>velocidade(t) = velocidade no instante(0) + acelaração . t
>>Determina como a velocidade varia ao longo do tempo nas simulações
>
>>### GetMagnitude() -> Obtem a magnitude
>>|V| = raíz quadrada(X^2 + Y^2)
>>
>>### AngleInDegrees() -> Obtem o angulo em graus 
>>0(teta) = arctan(y/x) . 180/pi
>>GetMagnitude e AngleInDegrees sao usados para transformarmos as nossas componentes de cartesianas(X,Y) para cordenadas polares(módulo, ângulo)
>
>>### Distance() -> Obtem a deslocamento percorrido
>>Calcula todo o deslocamente feito pela particula
>>distancia = raíz quadrada((X2 - X1)^2 + (Y2-Y1)^2)
>>Usamos esta função para mostrar o deslocamento percorrido pela particula na simulação
>>

>## Caso de estudo
>Para este caso de estudo vamos primeiro resolver um problema a lapis e caneta e depois verificar se os resultados batem certo no programa
>Este estudo de caso esta realizado no ficheiro -> estudoCasoFPA.docx

>## Testes Unitarios
>>Para os testes unitarios fizemos uma abordagem diferente, em vez de usar um Library de testes como o NUnit ou xUnit, optamos por criar as nossas proprias funções para testar a funcionalidade do programa. Pois quando testamos usar as libraries mencionadas, tivemos problemas com a execução dos testes, além de adicionar a necessidade de instalar os packages e configurar o ambiente de testes, o que poderia ser um problema para a professora correr os testes.
>>>### Como correr os testes
>>>Correr o Programa normalmente, e colocar o comando "Test" para correr todos os testes ou "Test [Nome do Teste]" para correr um teste específico.
>>>O Nome do teste é o nome do metodo de teste.
>>>>Nota: Tentamos manter os nomes dos metodos de teste o mais descritivo possível para facilitar a identificação e o que fazem.

>## Motivo de escolha de tipo de variaveis
>> - Usamos doubles para as variaveis numericas, pois permite o uso de casas decimais e é mais preciso para os calculos de fisica, onde a precisão é importante.
>> - Nos usamos um Dictionary para armazenar os projetos, pois permite o acesso rapido sem ter de iterar por uma lista, podendo acessar o projeto que queremos por um nome unico que é a chave.
>> - Usamos um OrderedDictionary para armazenar as particulas, pois é mais eficiente para acessar as particulas diretamente por um nome em vez de iterar por uma lista, por ser um OrderedDictionary, ele organiza os elementos Alfabeticamente como pedido no enunciado.
>> - Para as forças usamos uma List, pois nos não vimos necessidade de acessar as forças individualmente, pois as forças são usadas em conjunto.

