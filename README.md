# Simulador-Fisica

>## Introdução
>
>Este projeto consiste na construçao de um simulador de fisica 2D na linha de comando em linguagem C#, Neste simulador é possivel adicionar varios projetos em que cada projeto tera as suas particulas cada uma delas com as suas forças.
>Tendo adicionado tudo para uma simulaçao é possível simular movimentos(Cinemática) e forças resultantes(Dinâmica)

>## Variaveis e Formulas
>>### GetResultantForce() -> Calculo da Força Resultante e Peso
>>Soma as componentes em X e as componentes em Y de todas as forças na particula
>>Se a gravidade estiver ligada fazemos a alteração no peso
>>Força resultante = somatorio de todas forças
>>Py = massa . gravidade
>>Justificação
>
>>### GetAccelaration() -> Segunda Lei de Newton
>>Dividimos a força resultante  em x e y obtida na função anterior e dividimos pela massa para obter a acelaração em x e y
>>ax = Força resultante em X / massa
>>ay = Força resultante em Y / massa
>>Estamos a aplicar a 2ª lei de Newton para descobrir a acelaração para descobrir a alteração na velocidade na simulação
>
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

