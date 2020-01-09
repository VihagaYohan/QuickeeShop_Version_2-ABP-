using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickeeShop.Configuration;

namespace QuickeeShop.Web.Host.Startup
{
    [DependsOn(
       typeof(QuickeeShopWebCoreModule))]
    public class QuickeeShopWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QuickeeShopWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuickeeShopWebHostModule).GetAssembly());
        }
    }
}
