# Modelo de comunicação fanout

Nesse modelo trata-se de uma comunicação simples onde existe apenas um `Producer` e dois `Consumer` enviando e recebendo a mensagem de texto através de uma exchange chamada `ExchangeFanout`. Para esse tipo de comunicação todas as filas anexadas a exchange receberam a mensagem, conforme o exemplo abaixo

Para executar esse modelo deverá ser executado primeiramente o projeto da pasta `Producer` para que seja possível enviar a mensagem.

``` code
cd .\Producer
dotnet run

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

Fila: amq.gen-ysbSaiLH1yrpQlCiNMqHlw
Aguardando mensagens da fila...
Pressione qualquer tecla para finalizar
Recebido: [Olá] da fila!
```

E após executar o projeto da pasta `ConsumerTwo`
``` code
cd .\ConsumerTwo
dotnet run

Fila: amq.gen-KTTyltHhvC2al57CmBfHNA
Aguardando mensagens da fila...
Pressione qualquer tecla para finalizar
Recebido: [Olá] da fila!
```
