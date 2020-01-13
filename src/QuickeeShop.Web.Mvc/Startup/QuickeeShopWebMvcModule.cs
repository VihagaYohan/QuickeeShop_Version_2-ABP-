using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickeeShop.Configuration;
using QuickeeShop.Entity;
using Abp.Domain.Repositories;

namespace QuickeeShop.Web.Startup
{
    [DependsOn(typeof(QuickeeShopWebCoreModule))]
    public class QuickeeShopWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QuickeeShopWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<QuickeeShopNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuickeeShopWebMvcModule).GetAssembly());
            IocManager.Register<IRepository<CustomerDL>>();
            IocManager.Register<IRepository<ProductDL>>();
            IocManager.Register<IRepository<OrderDL>>();
        }
    }
}
