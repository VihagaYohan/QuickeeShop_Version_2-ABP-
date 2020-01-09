using Abp.Authorization;
using QuickeeShop.Authorization.Roles;
using QuickeeShop.Authorization.Users;

namespace QuickeeShop.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
