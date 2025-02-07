using System.Collections.Concurrent;

namespace AspNetAIChat.Server;

public record ChatMessage(string Message);
public record UserChatMessage(string Message): ChatMessage(Message);
public record AssistantChatMess(string Message) : ChatMessage(Message);

public class ChatContext
{
}
