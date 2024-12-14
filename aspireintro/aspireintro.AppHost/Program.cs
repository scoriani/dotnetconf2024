using Projects;

var builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<Aspire.Hosting.Azure.AzurePostgresFlexibleServerResource> postgresAzure;
IResourceBuilder<Aspire.Hosting.Azure.AzurePostgresFlexibleServerDatabaseResource> dbAzure;
IResourceBuilder<ProjectResource> webapi;

if (builder.ExecutionContext.IsPublishMode)
{
    postgresAzure = builder.AddAzurePostgresFlexibleServer("postgres").WithPasswordAuthentication();
    dbAzure = postgresAzure.AddDatabase("aspireintro");

    webapi = builder.AddProject<aspireintro_WebApi>("webapi")
    .WithExternalHttpEndpoints()
    .WithReference(dbAzure)
    .WaitFor(dbAzure);
}
else
{
    var postgres = builder.AddPostgres("postgres")
        .WithPgAdmin();
    var db = postgres.AddDatabase("aspireintro");

    webapi = builder.AddProject<aspireintro_WebApi>("webapi")
    .WithExternalHttpEndpoints()
    .WithReference(db)
    .WaitFor(db);
}

builder.Build().Run();

