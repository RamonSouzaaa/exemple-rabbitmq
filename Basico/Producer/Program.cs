using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoRabbitMQ.Basico
{
    public class Producer
    {
        private const string QUEUE = "Fila";
		
        static void Main(String[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            bool isFinalizar = false;

            channel.QueueDeclare(
                queue: QUEUE,
                durable: false,
                arguments: null,
				exclusive: false
            );

            while(!isFinalizar)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("1- Enviar mensagem");
                Console.WriteLine("2- Sair");
                Console.WriteLine("===============================");
                char c = Console.ReadLine().Trim()[0];
                if(c == '2')
                {
                    isFinalizar = true;
                }
                else
                {
                    Console.WriteLine("Informe a mensagem que deseja enviar: ");
                    string message = Console.ReadLine().Trim();

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(
                        exchange: string.Empty,
                        routingKey: QUEUE,
                        basicProperties: null,
                        body: body);

                    Console.WriteLine($"Enviado '{message}' para a fila!");
                    Console.WriteLine();
                }
            }
			
			channel.Close();
			connection.Close();
        }
    }
}
