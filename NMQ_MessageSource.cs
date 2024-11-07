using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using NetMQ.Sockets;
using NetMQ;
using System.ServiceModel.Channels;

namespace ChatCommon;

internal class NMQ_MessageSource : IMessageSource<IPEndPoint>
{
	private ResponseSocket iServer;

	public NMQ_MessageSource()
	{
		iServer= new ResponseSocket();
		iServer.Bind("tcp://*:12345");
	}
	IPEndPoint IMessageSource<IPEndPoint>.CopyT(IPEndPoint t)
	{
		return new IPEndPoint(t.Address, t.Port);
	}

	IPEndPoint IMessageSource<IPEndPoint>.CreateNewT()
	{
		return new IPEndPoint(IPAddress.Any, 0);
	}

	ChatMessage IMessageSource<IPEndPoint>.Receive(ref IPEndPoint fromAddr)
	{
		string receivedData = iServer.ReceiveFrameString();
		return ChatMessage.FromJson(receivedData);
	}

	void IMessageSource<IPEndPoint>.Send(ChatMessage message, IPEndPoint toAddr)
	{
		iServer.SendFrame(message.ToJson());
	}
}

/*
private UdpClient udpClient;
public UdpMessageSource()
{
	udpClient = new UdpClient(12345);
}
public IPEndPoint CopyT(IPEndPoint t)
{
	return new IPEndPoint(t.Address, t.Port);
}
public IPEndPoint CreateNewT()
{
	return new IPEndPoint(IPAddress.Any, 0);
}
public ChatMessage Receive(ref IPEndPoint ep)
{
	byte[] receiveBytes = udpClient.Receive(ref ep);
	string receivedData = Encoding.ASCII.GetString(receiveBytes);
	return ChatMessage.FromJson(receivedData);
}
public void Send(ChatMessage message, IPEndPoint ep)
{
	byte[] forwardBytes = Encoding.ASCII.GetBytes(message.ToJson());
	udpClient.Send(forwardBytes, forwardBytes.Length, ep);
}
*/

