using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using QuickeeShop.Authorization.Roles;
using QuickeeShop.Authorization.Users;
using QuickeeShop.MultiTenancy;
using QuickeeShop.Entity;

namespace QuickeeShop.EntityFrameworkCore
{
    public class QuickeeShopDbContext : AbpZeroDbContext<Tenant, Role, User, QuickeeShopDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<CustomerDL> Customers { get; set; }
        public DbSet<ProductDL> Products { get; set; }
        public DbSet<OrderDL> Orders { get;set; }
        public DbSet<OrderItemDL> OrderItems { get; set; }
        public QuickeeShopDbContext(DbContextOptions<QuickeeShopDbContext> options)
            : base(options)
        {
        }
    }
}
