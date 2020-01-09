using Abp.AspNetCore.Mvc.ViewComponents;

namespace QuickeeShop.Web.Views
{
    public abstract class QuickeeShopViewComponent : AbpViewComponent
    {
        protected QuickeeShopViewComponent()
        {
            LocalizationSourceName = QuickeeShopConsts.LocalizationSourceName;
        }
    }
}
