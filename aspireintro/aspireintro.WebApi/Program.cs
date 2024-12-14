using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.AddNpgsqlDbContext<dbContext>(connectionName: "aspireintro", configureDbContextOptions: dbContextOptionsBuilder =>
{
        dbContextOptionsBuilder.UseNpgsql(builder =>
        { }).UseSnakeCaseNamingConvention()
        .UseSeeding((ctx, _) => { SeedDatabase(ctx); });
});

var app = builder.Build();

// Get an instance of the dbContext to initialize the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<dbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/customer", (dbContext db) =>
{    
    return db.Customers.ToList();
})
.WithName("GetCustomers");


app.Run();

void SeedDatabase(DbContext context)
{
    // Check if the database is already seeded
    if (!context.Set<Customer>().Any())
    {
        // Add seed data
        context.Set<Customer>().AddRange(
            new Customer { Id = 1, Name = "John Doe" },
            new Customer { Id = 2, Name = "Jane Smith" }
        );
        context.SaveChanges();
    }
}