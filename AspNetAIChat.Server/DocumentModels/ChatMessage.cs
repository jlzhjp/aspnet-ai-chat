using MongoDB.Bson;

namespace AspNetAIChat.Server.DocumentModels;

public class ChatMessage
{
    public enum Role
    {
        System,
        Assistant,
        User,
    }

    public ObjectId Id { get; set; }

    public ObjectId ParentId { get; set; }

    public Role SenderRole { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
