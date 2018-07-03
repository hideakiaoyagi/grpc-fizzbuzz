using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Fizzbuzz;

namespace fizzbuzz_server
{
    class FizzbuzzServiceImpl : FizzbuzzService.FizzbuzzServiceBase
    {
        public override Task<FizzbuzzResponse> GetFizzbuzzList(FizzbuzzRequest request, ServerCallContext context)
        {
            const String fizz = "Kuma";
            const String buzz = "Mon";

            var wordlist = new List<String>();

            for (int i = request.StartNumber; i <= request.EndNumber; i++)
            {
                String word;
                if (i % 15 == 0)
                {
                    word = fizz + buzz;
                }
                else if (i % 3 == 0)
                {
                    word = fizz;
                }
                else if (i % 5 == 0)
                {
                    word = buzz;
                }
                else
                {
                    word = i.ToString();
                }
                wordlist.Add(word);
            }

            return Task.FromResult(new FizzbuzzResponse { WordList = "[" + String.Join(" ", wordlist) + "]" });
        }
    }

    class Program
    {
        const String Host = "localhost";
        const int Port = 50051;

        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { FizzbuzzService.BindService(new FizzbuzzServiceImpl()) },
                Ports = { new ServerPort(Host, Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("gRPC server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
