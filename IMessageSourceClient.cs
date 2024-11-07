using ChatCommon;

public interface IMessageSourceClient<T>
{
	public void Send(ChatMessage message, T
	toAddr);
	public ChatMessage Receive(ref T fromAddr);
	public T CreateNewT();
	public T GetServer();
}

