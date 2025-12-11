using NextAdminAuth.Api.Data;
using NextAdminAuth.Api.Models;

namespace NextAdminAuth.Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IRepository<User> Users { get; private set; }
    public IRepository<Role> Roles { get; private set; }
    public IRepository<Company> Companies { get; private set; }
    public IRepository<Customer> Customers { get; private set; }
    public IRepository<Permission> Permissions { get; private set; }
    public IRepository<MenuItem> MenuItems { get; private set; }
    public IRepository<VerificationToken> VerificationTokens { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new Repository<User>(_context);
        Roles = new Repository<Role>(_context);
        Companies = new Repository<Company>(_context);
        Customers = new Repository<Customer>(_context);
        Permissions = new Repository<Permission>(_context);
        MenuItems = new Repository<MenuItem>(_context);
        VerificationTokens = new Repository<VerificationToken>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
