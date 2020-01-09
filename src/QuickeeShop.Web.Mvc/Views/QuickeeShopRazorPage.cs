using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace QuickeeShop.Web.Views
{
    public abstract class QuickeeShopRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected QuickeeShopRazorPage()
        {
            LocalizationSourceName = QuickeeShopConsts.LocalizationSourceName;
        }
    }
}
