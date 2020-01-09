using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickeeShop.Authorization;

namespace QuickeeShop
{
    [DependsOn(
        typeof(QuickeeShopCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class QuickeeShopApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QuickeeShopAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QuickeeShopApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
