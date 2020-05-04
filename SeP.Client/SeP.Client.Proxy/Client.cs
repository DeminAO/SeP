using System.Threading.Tasks;
using Grpc.Net.Client;
using SeP.Core.Proto;

namespace SeP.Client.Proxy
{
    public class Client
    {
        private Greeter.GreeterClient _client;

        public Client()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            _client = new Greeter.GreeterClient(channel);
        }

        public async Task<HelloReply> SayHelloAsync(HelloRequest request)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            _client = new Greeter.GreeterClient(channel);

            return await _client.SayHelloAsync(request);
        }

        public async Task<ReplingDataBase> SignInAsync(SignInRequest request)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            _client = new Greeter.GreeterClient(channel);
            
            return await _client.SignInAsync(request);
        }

        public async Task<SignUpReplingData> SignUpAsync(SignUpRequest request)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            _client = new Greeter.GreeterClient(channel);

            return await _client.SignUpAsync(request);
        }
    }
}
