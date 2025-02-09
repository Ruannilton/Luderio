var builder = DistributedApplication.CreateBuilder(args);

var dbContainer = builder.AddPostgres("luderiaDbContainer")
    .WithPgAdmin()
    .WithDataVolume("luderiaDbVolume");

var catalogDb = dbContainer.AddDatabase("catalogDb");

var costumerDb = dbContainer.AddDatabase("customerDb");

var orderDb = dbContainer.AddDatabase("orderDb");

var luderiaApi = builder
    .AddProject<Projects.Luderia_Presentation>("luderiaApi")
    .WithReference(catalogDb)
    .WithReference(orderDb)
    .WithReference(costumerDb);

builder.Build().Run();
