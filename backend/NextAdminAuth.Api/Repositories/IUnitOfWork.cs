using NextAdminAuth.Api.Models;

namespace NextAdminAuth.Api.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Role> Roles { get; }
    IRepository<Company> Companies { get; }
    IRepository<Customer> Customers { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<MenuItem> MenuItems { get; }
    IRepository<VerificationToken> VerificationTokens { get; }
    Task<int> CompleteAsync();
}

