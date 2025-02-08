namespace AspNetAIChat.Server.UseCases;

public interface IAddConversationUseCase
{
    public record Response(string Id);

    public Task<Response> AddConversationAsync();
}
