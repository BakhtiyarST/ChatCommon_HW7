using System.Net.Sockets;
using System.Net;
using System.Text;
using ChatCommon;

namespace ChatCommon;

public class Program
{
	static void Main(string[] args)
	{
		if (args.Length == 0)
		{
			// var s = new Server<IPEndPoint>(new UdpMessageSource());
			var s = new Server<IPEndPoint>(new NMQ_MessageSource());
			s.Work();
		}
		else
		if (args.Length == 3)
		{
			// var c = new Client<IPEndPoint>(args[0], new UdpMessageSourceClient(int.Parse(args[2]), args[1], 12345));
			var c = new Client<IPEndPoint>(args[0], new NMQ_MessageSourceClient(int.Parse(args[2]), args[1], 12345));
			c.Start();
		}
		else
		{
			Console.WriteLine("Для запуска сервера введите ник-нейм как параметр запуска приложения");
			Console.WriteLine("Для запуска клиента введите ник-нейм и IP сервера как параметры запуска приложения");
		}
	}
}










