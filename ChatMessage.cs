using System.Text.Json;

namespace ChatCommon;

public enum Command
{
	Register,
	Message,
	Confirmation
}
public class ChatMessage
{
	public Command Command { get; set; }
	public int? Id { get; set; }
	public string FromName { get; set; }
	public string? ToName { get; set; }
	public string Text { get; set; }
	public string ToJson()
	{
		return JsonSerializer.Serialize(this);
	}
	public static ChatMessage FromJson(string json)
	{
		return JsonSerializer.Deserialize<ChatMessage>(json);
	}
}

