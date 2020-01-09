using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace QuickeeShop.Controllers
{
    public abstract class QuickeeShopControllerBase: AbpController
    {
        protected QuickeeShopControllerBase()
        {
            LocalizationSourceName = QuickeeShopConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
