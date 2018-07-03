using System;
using Grpc.Core;
using Fizzbuzz;

namespace fizzbuzz_client
{
    class Program
    {
        const String Host = "localhost";
        const int Port = 50051;

        public static void Main(string[] args)
        {
            int start = 1;
            int end   = 20;

            Channel channel = new Channel(Host + ":" + Port, ChannelCredentials.Insecure);

            var client = new FizzbuzzService.FizzbuzzServiceClient(channel);

            var reply = client.GetFizzbuzzList(new FizzbuzzRequest { StartNumber = start, EndNumber = end });
            Console.WriteLine("response OK!");

            Console.WriteLine(reply.WordList.Replace("[", "").Replace("]", "").Replace(" ", "\n"));

            channel.ShutdownAsync().Wait();
        }
    }
}
