using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program {
    private const string QUEUE = "Fila";
    public static void Main(String[] args){
        var factory = new ConnectionFactory { HostName = "localhost" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        

        channel.QueueDeclare(
            queue: QUEUE,
            durable: false,
            arguments: null,
            exclusive: false
        );

        var costumer = new EventingBasicConsumer(channel);
        costumer.Received += (model, ea) => 
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Recebido: [{message}] da fila!");
        };

        channel.BasicConsume(
            queue: QUEUE,
            autoAck: true,
            consumer: costumer
        );

        Console.WriteLine("Aguardando mensagens da fila...");
        Console.WriteLine("Pressione qualquer tecla para finalizar");
        Console.ReadLine();
    }
}
