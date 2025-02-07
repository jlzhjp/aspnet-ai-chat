using AspNetAIChat.Server.ValueObjects;
using MongoDB.Bson;

namespace AspNetAIChat.Server.Entities;

public class Conversation
{
    public ObjectId Id { get; private set; } = ObjectId.GenerateNewId();

    public string Title { get; private set; } = "New Conversation";

    public DialogTreeNode? DialogTree { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private Conversation() { }

    public static Conversation Create()
    {
        return new Conversation();
    }

    public static Conversation Create(string title)
    {
        return new Conversation
        {
            Title = title
        };
    }

    internal static Conversation Create(ObjectId id, string title, DialogTreeNode root, DateTime createdAt)
    {
        return new Conversation
        {
            Id = id,
            Title = title,
            DialogTree = root,
            CreatedAt = createdAt,
        };
    }

    private static bool AddMessageVisitor(DialogTreeNode root, ObjectId parentId, DialogTreeNode node)
    {
        if (root.Id == parentId)
        {
            root.Children.Add(node);
            return true;
        }

        return root.Children.Any(child => AddMessageVisitor(child, parentId, node));
    }


    public void AddMessage(ObjectId? parentId, DialogTreeNode node)
    {
        if (DialogTree is null && parentId is null)
        {
            DialogTree = node;
            return;
        }

        if (DialogTree is null) throw new InvalidOperationException("`parentId` not null while tree is empty");

        if (parentId is null) throw new ArgumentNullException(nameof(parentId));

        AddMessageVisitor(DialogTree, parentId.Value, node);
    }

    private static void SelectBranchVisitor(List<DialogTreeNode> root, HashSet<ObjectId> restChoices, List<DialogTreeNode> branch)
    {
        var selectedNode =
            root.SingleOrDefault(child => restChoices.Contains(child.Id)) ??
            root.FirstOrDefault();

        if (selectedNode is null) return;
        
        branch.Add(selectedNode);
        restChoices.Remove(selectedNode.Id);
        SelectBranchVisitor(selectedNode.Children, restChoices, branch);
    }

    public List<DialogTreeNode> SelectBranch(HashSet<ObjectId> choices)
    {
        if (DialogTree is null) return [];
        List<DialogTreeNode> branch = [];
        SelectBranchVisitor([DialogTree], choices, branch);
        return branch;
    }
}
