using Microsoft.EntityFrameworkCore;
using SecureShopAPI.Models;

namespace SecureShopAPI.Data;

public class SecureShopContext : DbContext
{
    public SecureShopContext(DbContextOptions<SecureShopContext>  options) : base(options){}

    #region DbSets

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Product> Products { get; set; }

    #endregion

    #region Config Dbsets


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Sequence

        modelBuilder.HasSequence<int>("ProductNumber", schema: "shared").StartsAt(500).IncrementsBy(1).HasMax(15500);

        #endregion

        #region User

        modelBuilder.Entity<User>(
            u =>
            {
                u.HasKey(k => k.Id);
                u.Property<string>("FullName").HasMaxLength(200);
                u.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                u.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                u.Property(p => p.Password).HasMaxLength(100).IsRequired();

                u.HasIndex(p => p.Email).IsUnique();
            });


        #endregion

        #region Role

        modelBuilder.Entity<Role>(
            r =>
            {
                r.HasKey(k => k.Id);
                r.Property(p => p.RoleTitle).HasMaxLength(100).IsRequired();
            });

        #endregion

        #region User Role

        modelBuilder.Entity<UserRole>(
            ur =>
            {
                ur.HasKey(k => k.Id);
                ur.HasOne(h => h.User).WithMany(e => e.UserRoles)
                    .HasForeignKey(f => f.UserId);
                ur.HasOne(h => h.Role).WithMany(w => w.UserRoles)
                    .HasForeignKey(f => f.RoleId);
            });

        #endregion

        #region Product

        modelBuilder.Entity<Product>(
            pr =>
            {
                pr.Property(p=>p.Id).UseSequence("ProductNumber", "shared");
                pr.Property(p => p.Name).HasMaxLength(300).IsRequired();
                pr.Property(p => p.Description).HasMaxLength(700);
                pr.Property(p => p.Price).HasColumnType("decimal(18,2)");
            });

        #endregion

        base.OnModelCreating(modelBuilder);
    }

    #endregion


}