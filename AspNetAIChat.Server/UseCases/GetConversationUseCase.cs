using AspNetAIChat.Server.Repositories;

namespace AspNetAIChat.Server.UseCases;

public class GetConversationUseCase(IConversationRepository conversationRepository) : IGetConversationsUseCase
{
    public async Task<List<IGetConversationsUseCase.ConversationInfoDTO>> GetConversations()
    {
        var conversations = await conversationRepository.FindConversationsAsync();
        return conversations
            .Select(conversation =>
                new IGetConversationsUseCase.ConversationInfoDTO(conversation.Id.ToString(), conversation.Title))
            .ToList();
    }
}