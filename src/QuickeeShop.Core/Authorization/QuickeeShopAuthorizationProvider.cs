using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace QuickeeShop.Authorization
{
    public class QuickeeShopAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Customers, L("Customer"));
            context.CreatePermission(PermissionNames.Pages_Products, L("Product"));
            context.CreatePermission(PermissionNames.Pages_Orders, L("Order"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, QuickeeShopConsts.LocalizationSourceName);
        }
    }
}
