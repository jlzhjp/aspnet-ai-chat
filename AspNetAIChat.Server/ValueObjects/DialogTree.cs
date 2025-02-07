using MongoDB.Bson;

namespace AspNetAIChat.Server.ValueObjects;

public record DialogTreeNode(
    ObjectId Id,
    string Content,
    List<DialogTreeNode> Children,
    DateTime CreatedAt)
{
    public static DialogTreeNode Create(string content, out ObjectId id)
    {
        id = ObjectId.GenerateNewId();
        return new DialogTreeNode(
            Id: id,
            Content: content,
            Children: [],
            CreatedAt: DateTime.UtcNow);
    }

    public static DialogTreeNode Create(string content) => Create(content, out _);

}

public record UserMessage(
    ObjectId Id,
    string Content,
    List<DialogTreeNode> Children,
    DateTime CreatedAt) : DialogTreeNode(Id, Content, Children, CreatedAt)
{
    public new static UserMessage Create(string content, out ObjectId id)
    {
        id = ObjectId.GenerateNewId();
        return new UserMessage(
            Id: id,
            Content: content,
            Children: [],
            CreatedAt: DateTime.UtcNow);
    }

    public new static UserMessage Create(string content) => Create(content, out _);
}

public record AssistantMessage(
    ObjectId Id,
    string Content,
    List<DialogTreeNode> Children,
    DateTime CreatedAt) : DialogTreeNode(Id, Content, Children, CreatedAt)
{
    public new static AssistantMessage Create(string content, out ObjectId id)
    {
        id = ObjectId.GenerateNewId();
        return new AssistantMessage(
        Id: id,
        Content: content,
        Children: [],
        CreatedAt: DateTime.UtcNow);
    }

    public new static AssistantMessage Create(string content) => Create(content, out _);
}

