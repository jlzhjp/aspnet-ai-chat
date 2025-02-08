var builder = DistributedApplication.CreateBuilder(args);

var mongo = builder.AddMongoDB("mongo")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithMongoExpress();

var chatDb = mongo.AddDatabase("chat");

var server = builder.AddProject<Projects.AspNetAIChat_Server>("server")
    .WithReference(chatDb)
    .WaitFor(chatDb);


builder.Build().Run();
