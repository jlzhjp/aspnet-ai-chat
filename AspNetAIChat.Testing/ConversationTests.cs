using AspNetAIChat.Server.Entities;
using AspNetAIChat.Server.ValueObjects;

namespace AspNetAIChat.Testing;

public class ConversationTests
{
    [Fact]
    public void AddNode_ShouldMaintainCorrectStructure()
    {
        var conversation = Conversation.Create();

        conversation.AddMessage(null, UserMessage.Create("Message 1", out var id0));
        conversation.AddMessage(id0, AssistantMessage.Create("Message 2", out var id00));
        conversation.AddMessage(id00, UserMessage.Create("Message 3", out var id000));
        conversation.AddMessage(id0, AssistantMessage.Create("Message 4", out var id01));

        Assert.True(conversation.DialogTree is
        {
            Content: "Message 1",
            Children:
            [
                {
                    Content: "Message 2",
                    Children:
                    [
                        {
                            Content: "Message 3",
                            Children: []
                        }
                    ]
                },
                {
                    Content: "Message 4",
                    Children: []
                },
            ]
        });
    }

    [Fact]
    public void SelectBranch_ShouldSelectCorrectBranch()
    {
        var conversation = Conversation.Create();

        conversation.AddMessage(null, UserMessage.Create("Message 1", out var id0));
        conversation.AddMessage(id0, AssistantMessage.Create("Message 2", out var id00));
        conversation.AddMessage(id00, UserMessage.Create("Message 3", out var id000));
        conversation.AddMessage(id0, AssistantMessage.Create("Message 4", out var id01));

        var result1 = conversation.SelectBranch([id00]);
        Assert.True(result1 is
            [
                { Content: "Message 1" },
                { Content: "Message 2" },
                { Content: "Message 3" },
            ]);
        
        var result2 = conversation.SelectBranch([id01]);
        Assert.True(result2 is 
            [
                { Content: "Message 1" },
                { Content: "Message 4" },
            ]);
    }
}
