using AspNetAIChat.Server.Entities;
using MongoDB.Bson;

namespace AspNetAIChat.Server.Repositories;

public interface IConversationRepository
{
    Task<List<Conversation>> FindConversationsAsync();
    
    Task<Conversation> FindConversationByIdAsync(ObjectId conversationId);
    
    Task<long> DeleteConversationAsync(ObjectId id);
    
    Task<long> UpdateConversationTitleAsync(ObjectId id, string title);
    
    Task SaveConversationAsync(Conversation conversation);
}
