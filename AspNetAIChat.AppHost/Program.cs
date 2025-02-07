var builder = DistributedApplication.CreateBuilder(args);

var mongo = builder.AddMongoDB("mongo");

var chatDb = mongo.AddDatabase("chat");

var server = builder.AddProject<Projects.AspNetAIChat_Server>("server")
    .WithReference(chatDb)
    .WaitFor(chatDb);


builder.Build().Run();
