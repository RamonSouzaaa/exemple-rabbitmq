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
        private const string EXCHANGE = "ExchangeFanout";
		
        static void Main(String[] args)
        {
			bool isFinalizar = false;
            var factory = new ConnectionFactory { HostName = "localhost" };
			var connection = factory.CreateConnection();
			var channel = connection.CreateModel();
			
            while(!isFinalizar)
            {
				channel.ExchangeDeclare(
					exchange: EXCHANGE,
					type: ExchangeType.Fanout
				);
				
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
                        exchange: EXCHANGE,
                        routingKey: string.Empty,
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
