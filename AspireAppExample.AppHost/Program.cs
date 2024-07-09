var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("db").WithPgAdmin();

var apiService = builder.AddProject<Projects.AspireAppExample_ApiService>("apiservice")
                 .WithReference(db);

builder.AddProject<Projects.AspireAppExample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
