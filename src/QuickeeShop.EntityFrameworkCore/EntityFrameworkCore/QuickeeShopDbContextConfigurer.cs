using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace QuickeeShop.EntityFrameworkCore
{
    public static class QuickeeShopDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QuickeeShopDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QuickeeShopDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
