using System.Text;
using RabbitMQ.Client;
using RundeService.Model;
using System.Runtime.Serialization.Json;
using System.IO;

namespace RundeService
{
    public class Publish
    {
        public static void Runde(Runde runde)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "Runde", type: "fanout");

                //serializer Runde til json og gør det til string til sidst
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Runde));
                MemoryStream msObj = new MemoryStream();
                js.WriteObject(msObj, runde);
                msObj.Position = 0;
                StreamReader sr = new StreamReader(msObj);
                string json = sr.ReadToEnd();                // "{\"Description\":\"Share Knowledge\",\"Name\":\"C-sharpcorner\"}"  
                

                //gør string til byte så det kan sendes
                var body = Encoding.UTF8.GetBytes(json);
                //publish det op til Runde køen
                channel.BasicPublish(exchange: "Runde",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }

        }

        public static void Delete(long id)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "Delete", type: "fanout");

                //gør string til byte så det kan sendes
                var body = Encoding.UTF8.GetBytes(id.ToString());

                //publish det op til Runde køen
                channel.BasicPublish(exchange: "Delete",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
