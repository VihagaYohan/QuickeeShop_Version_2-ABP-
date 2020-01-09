using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QuickeeShop.Configuration;
using QuickeeShop.Web;

namespace QuickeeShop.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class QuickeeShopDbContextFactory : IDesignTimeDbContextFactory<QuickeeShopDbContext>
    {
        public QuickeeShopDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<QuickeeShopDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            QuickeeShopDbContextConfigurer.Configure(builder, configuration.GetConnectionString(QuickeeShopConsts.ConnectionStringName));

            return new QuickeeShopDbContext(builder.Options);
        }
    }
}
