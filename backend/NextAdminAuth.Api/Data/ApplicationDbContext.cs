using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NextAdminAuth.Api.Models;

namespace NextAdminAuth.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Screen> Screens { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<VerificationToken> VerificationTokens { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Menu Items Configuration
        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(m => m.Parent)
                  .WithMany(m => m.Children)
                  .HasForeignKey(m => m.ParentId)
                  .OnDelete(DeleteBehavior.Cascade); // Ana menü silinirse alt menüler de silinsin mi? Genelde Restrict veya Cascade
        });

        // Seed Initial Menu Items
        var dashboardId = Guid.NewGuid();
        var usersMenuId = Guid.NewGuid();
        var settingsMenuId = Guid.NewGuid();

        modelBuilder.Entity<MenuItem>().HasData(
            // Ana Menüler
            new MenuItem { Id = dashboardId, Title = "Ana Sayfa", Path = "/dashboard", Icon = "LayoutDashboard", Order = 1, ParentId = null },
            new MenuItem { Id = usersMenuId, Title = "Yönetim", Path = "#", Icon = "Users", Order = 2, ParentId = null }, // Parent menu genelde path'siz olur
            new MenuItem { Id = settingsMenuId, Title = "Ayarlar", Path = "/dashboard/settings", Icon = "Settings", Order = 3, ParentId = null },
            
            // Alt Menüler (Yönetim altı)
            new MenuItem { Id = Guid.NewGuid(), Title = "Kullanıcılar", Path = "/dashboard/users", Icon = "User", Order = 1, ParentId = usersMenuId },
            new MenuItem { Id = Guid.NewGuid(), Title = "Müşteriler", Path = "/dashboard/customers", Icon = "Users", Order = 2, ParentId = usersMenuId }
        );

        // Seed Roles
        var superAdminRoleId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1c9858b");
        var adminRoleId = Guid.Parse("c7b013f0-5201-4317-a5d4-9d0a5198f2f4");
        var userRoleId = Guid.Parse("72f8c5a2-9b1e-4239-847e-123456789abc");

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = superAdminRoleId, Name = "SuperAdmin" },
            new Role { Id = adminRoleId, Name = "Admin" },
            new Role { Id = userRoleId, Name = "User" }
        );

        // Seed Screens
        var customerScreenId = Guid.NewGuid();
        modelBuilder.Entity<Screen>().HasData(
            new Screen { Id = customerScreenId, Name = "Customers", Code = "PAGE_CUSTOMERS" }
        );

        // Seed Permissions
        modelBuilder.Entity<Permission>().HasData(
            // SuperAdmin - Customers - Full Access
            new Permission { Id = Guid.NewGuid(), RoleId = superAdminRoleId, ScreenId = customerScreenId, CanRead = true, CanCreate = true, CanUpdate = true, CanDelete = true },
            // Admin - Customers - Full Access
            new Permission { Id = Guid.NewGuid(), RoleId = adminRoleId, ScreenId = customerScreenId, CanRead = true, CanCreate = true, CanUpdate = true, CanDelete = true },
            // User - Customers - Read Only
            new Permission { Id = Guid.NewGuid(), RoleId = userRoleId, ScreenId = customerScreenId, CanRead = true, CanCreate = false, CanUpdate = false, CanDelete = false }
        );

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(c => c.Company)
                  .WithMany()
                  .HasForeignKey(c => c.CompanyId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique();
            
            entity.HasOne(u => u.Company)
                  .WithMany(c => c.Users)
                  .HasForeignKey(u => u.CompanyId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(u => u.Role)
                  .WithMany(r => r.Users)
                  .HasForeignKey(u => u.RoleId);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(p => p.Role).WithMany(r => r.Permissions).HasForeignKey(p => p.RoleId);
            entity.HasOne(p => p.Screen).WithMany().HasForeignKey(p => p.ScreenId);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<VerificationToken>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Email, e.Token }).IsUnique();
        });
    }
}

