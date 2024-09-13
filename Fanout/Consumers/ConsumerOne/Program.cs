using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program {
    private const string EXCHANGE = "ExchangeFanout";

    public static void Main(String[] args){
        var factory = new ConnectionFactory { HostName = "localhost" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        

        channel.ExchangeDeclare(
            exchange: EXCHANGE,
            type: ExchangeType.Fanout
        );

        string queueName = channel.QueueDeclare().QueueName;
        
        channel.QueueBind(
            queue: queueName,
            exchange: EXCHANGE,
            routingKey: String.Empty
        );

        Console.WriteLine($"Fila: {queueName}");
        var costumer = new EventingBasicConsumer(channel);
        costumer.Received += (model, ea) => 
        {
            byte[] body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Recebido: [{message}] da fila!");
        };

        channel.BasicConsume(
            queue: queueName,
            autoAck: true,
            consumer: costumer
        );

        Console.WriteLine("Aguardando mensagens da fila...");
        Console.WriteLine("Pressione qualquer tecla para finalizar");
        Console.ReadLine();

        channel.Close();
        connection.Close();
    }
}
