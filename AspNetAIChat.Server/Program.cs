var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSignalR();

// builder.Services.AddScoped<IAddConversationUseCase, AddConversationUseCase>();
// builder.Services.AddScoped<IGetConversationsUseCase, GetConversationUseCase>();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapFallbackToFile("/index.html");

app.Run();
