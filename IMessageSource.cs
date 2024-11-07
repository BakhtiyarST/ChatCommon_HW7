using ChatCommon;
using System.Net;

public interface IMessageSource<T>
{
	void Send(ChatMessage message, T toAddr);
	ChatMessage Receive(ref T fromAddr);
	public T CreateNewT();
	public T CopyT(T t);
}
/*
public interface IMessageSource
{
	void Send(ChatMessage message, IPEndPoint ep);
	ChatMessage Receive(ref IPEndPoint ep);
}
*/
