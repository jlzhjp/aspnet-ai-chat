using AspNetAIChat.Server.Entities;
using AspNetAIChat.Server.Repositories;

namespace AspNetAIChat.Server.UseCases;

public class AddConversationUseCase(IConversationRepository conversationRepository) : IAddConversationUseCase
{
    public async Task<IAddConversationUseCase.Response> AddConversationAsync()
    {
        var conversation = Conversation.Create();
        await conversationRepository.SaveConversationAsync(conversation);
        return new IAddConversationUseCase.Response(conversation.Id.ToString());
    }
}