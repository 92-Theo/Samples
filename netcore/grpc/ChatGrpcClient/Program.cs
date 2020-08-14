using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using ChatGrpc;
using Grpc.Core;
using Grpc.Net.Client;
namespace ChatGrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
			//AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

			var customer = new Customer
			{
				ColorInConsole = GetRandomChatColor(),
				Id = Guid.NewGuid().ToString(),
				Name = args.Length > 0 ? args[0] : "TheHulk"
			};

			//var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { Credentials = ChannelCredentials.Insecure });
			var channel = GrpcChannel.ForAddress("https://localhost:5001");
			var client = new CustomerService.CustomerServiceClient(channel);
			var joinCustomerReply = await client.JoinCustomerChatAsync(new JoinCustomerRequest
			{
				Customer = customer
			});

			client.

			using (var streaming = client.SendMessageToChatRoom(new Metadata { new Metadata.Entry("CustomerName", customer.Name) }))
			{
				CancellationTokenSource cts = new CancellationTokenSource();
				var response = Task.Run(async () =>
				{
					while (await streaming.ResponseStream.MoveNext())
					{
						Console.ForegroundColor = Enum.Parse<ConsoleColor>(streaming.ResponseStream.Current.Color);
						Console.WriteLine($"{streaming.ResponseStream.Current.CustomerName}: {streaming.ResponseStream.Current.Message}");
						Console.ForegroundColor = Enum.Parse<ConsoleColor>(customer.ColorInConsole);
					}

					Console.WriteLine("Exit Task.Run");
				}, cts.Token);

				

				await streaming.RequestStream.WriteAsync(new ChatMessage
				{
					CustomerId = customer.Id,
					Color = customer.ColorInConsole,
					Message = "",
					RoomId = joinCustomerReply.RoomId,
					CustomerName = customer.Name
				});
				Console.ForegroundColor = Enum.Parse<ConsoleColor>(customer.ColorInConsole);
				Console.WriteLine($"Joined the chat as {customer.Name}");

				var line = Console.ReadLine();
				DeletePrevConsoleLine();
				while (!string.Equals(line, "qw!", StringComparison.OrdinalIgnoreCase))
				{

					if (line == "wqwq")
					{
						Console.WriteLine($"Joined the chat as {customer.Name}");
					}

					await streaming.RequestStream.WriteAsync(new ChatMessage
					{
						Color = customer.ColorInConsole,
						CustomerId = customer.Id,
						CustomerName = customer.Name,
						Message = line,
						RoomId = joinCustomerReply.RoomId
					});
					line = Console.ReadLine();
					DeletePrevConsoleLine();
				}




				await streaming.RequestStream.CompleteAsync();
			}
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		private static string GetRandomChatColor()
		{
			var colors = Enum.GetValues(typeof(ConsoleColor));
			var rnd = new Random();
			return colors.GetValue(rnd.Next(1, colors.Length - 1)).ToString();
		}

		private static void DeletePrevConsoleLine()
		{
			if (Console.CursorTop == 0) return;
			Console.SetCursorPosition(0, Console.CursorTop - 1);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, Console.CursorTop - 1);
		}
	}
}
