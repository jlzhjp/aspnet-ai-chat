namespace AspNetAIChat.Server.UseCases;

public interface IAddConversationUseCase
{
    public record Response(string Id);

    public Response AddConversation();
}
