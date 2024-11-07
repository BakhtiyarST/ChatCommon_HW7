using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatCommon;

internal class NMQ_MessageSourceClient : IMessageSourceClient<IPEndPoint>
{
	private RequestSocket iClient;
	private IPEndPoint ep;

	public NMQ_MessageSourceClient(int p, string ip, int r)
	{
		iClient = new RequestSocket();
		iClient.Connect("tcp://" + ip + ":" + r.ToString());
		ep = new IPEndPoint(IPAddress.Parse(ip), r);
	}
	IPEndPoint IMessageSourceClient<IPEndPoint>.CreateNewT()
	{
		return new IPEndPoint(IPAddress.Any, 0);
	}

	IPEndPoint IMessageSourceClient<IPEndPoint>.GetServer()
	{
		return ep;
	}

	ChatMessage IMessageSourceClient<IPEndPoint>.Receive(ref IPEndPoint fromAddr)
	{
		string receivedData = iClient.ReceiveFrameString();
		var messageReceived = ChatMessage.FromJson(receivedData);
		return messageReceived;
	}

	void IMessageSourceClient<IPEndPoint>.Send(ChatMessage message, IPEndPoint toAddr)
	{
		var json = message.ToJson();
		iClient.SendFrame(json);
	}
}

/*
private UdpClient client;
private IPEndPoint ep;
public UdpMessageSourceClient(int p, string ip, int r)
{
	client = new UdpClient(p);
	ep = new IPEndPoint(IPAddress.Parse(ip), r);
}
public IPEndPoint CreateNewT()
{
	return new IPEndPoint(IPAddress.Any, 0);
}
public IPEndPoint GetServer()
{
	return ep;
}
public ChatMessage Receive(ref IPEndPoint iPEndPoint)
{
	byte[] receiveBytes = client.Receive(ref iPEndPoint);
	string receivedData = Encoding.ASCII.GetString(receiveBytes);
	var messageReceived = ChatMessage.FromJson(receivedData);
	return messageReceived;
}
public void Send(ChatMessage message, IPEndPoint iPEndPoint)
{
	var json = message.ToJson();
	var b = Encoding.ASCII.GetBytes(json);
	client.Send(b, b.Length, iPEndPoint);
}
*/

