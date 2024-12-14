using Microsoft.EntityFrameworkCore;
public class dbContext : DbContext
{
    public dbContext(DbContextOptions<dbContext> options, IConfiguration configuration) : base(options)
    {
    }

    public required DbSet<Customer> Customers { get; set; }
}