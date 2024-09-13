# Modelo de comunicação básico

Nesse modelo trata-se de uma comunicação simples onde existe apenas um `Producer` e um `Consumer` enviando e recebendo a mensagem de texto através de uma fila chamada `Fila`.

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

E após executar o projeto da pasta `Consumer`

``` code
cd .\Consumer
dotnet run

Aguardando mensagens da fila...
Pressione qualquer tecla para finalizar
Recebido: [Olá] da fila!
```