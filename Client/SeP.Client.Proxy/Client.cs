using System.Threading.Tasks;
using Grpc.Net.Client;
using SeP.Core.Proto;

namespace SeP.Client.Proxy
{
	public class Client
	{
        public async Task<string> SayHelloAsync(string name)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Greeter.GreeterClient(channel);
            var result = await client.SayHelloAsync(new HelloRequest { Name = name });
            
            return result.Message;
        }
    }
}
