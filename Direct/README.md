
# Modelo de comunicação direct

Nesse modelo trata-se de uma comunicação onde existe apenas um `Producer` e dois `Consumer` enviando e recebendo a mensagem de texto através de uma exchange chamada `ExchangeDirect`. Para esse tipo de comunicação é necessário informar qual `routingKey` via parâmetro de inicialização para a exchange enviar a mensagem para a fila correspondente.

Para executar esse modelo deverá ser executado primeiramente o projeto da pasta `Producer` utilizando o paramêtro de inicialização correspondente ao `routingKey` da fila para que seja possível enviar a mensagem.

``` code
cd .\Producer
dotnet run consumerOne

===============================
1- Enviar mensagem
2- Sair
===============================
1
Informe a mensagem que deseja enviar:
Olá
Enviado 'Olá' para a fila!
```

E após executar o projeto da pasta `ConsumerOne`

``` code
cd .\ConsumerOne
dotnet run

Fila: consumerOne
Aguardando mensagens da fila...
Pressione qualquer tecla para finalizar
Recebido: [Olá] da fila!
```

O mesmo deverá ser feito para utilizar o `consumerTwo`

``` code
cd .\Producer
dotnet run consumerTwo

===============================
1- Enviar mensagem
2- Sair
===============================
1
Informe a mensagem que deseja enviar:
Olá
Enviado 'Olá' para a fila!
```

``` code
cd .\ConsumerTwo
dotnet run

Fila: consumerTwo
Aguardando mensagens da fila...
Pressione qualquer tecla para finalizar
Recebido: [Olá] da fila!
```

É importante ressaltar que não poderá ser iniciado dois projetos `Producer` ao mesmo tempo, devido a exchange ter o mesmo nome, isso causará um erro durante a execução.