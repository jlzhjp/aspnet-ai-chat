using AspNetAIChat.Server.Entities;
using MongoDB.Bson;

namespace AspNetAIChat.Server.Repositories;

public interface IConversationRepository
{
    Task<(ObjectId id, string title)> FindConversationsAsync();
    
    Task<Conversation> FindConversationByIdAsync(ObjectId conversationId);
    
    Task<ObjectId> AddConversationAsync(string title = "New Conversation");
    
    Task<long> DeleteConversationAsync(ObjectId id);
    
    Task<long> UpdateConversationTitleAsync(ObjectId id, string title);
}
