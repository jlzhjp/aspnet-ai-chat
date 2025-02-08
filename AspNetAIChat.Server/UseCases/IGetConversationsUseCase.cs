using AspNetAIChat.Server.Entities;

namespace AspNetAIChat.Server.UseCases;

public interface IGetConversationsUseCase
{
    public record ConversationInfoDTO(string Id, string Title);
    Task<List<ConversationInfoDTO>> GetConversations();
}