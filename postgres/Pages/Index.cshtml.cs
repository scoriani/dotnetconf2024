using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using postgres;

namespace postgres.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SalesContext _context;

    public IndexModel(ILogger<IndexModel> logger, SalesContext context)
    {
        _logger = logger;
         
        _context = context;
    }

  public IList<Customer> Customers { get; set; } = new List<Customer>();

    public async Task OnGetAsync()
    {
        Customers = await _context.Customers.ToListAsync();
    }
}
