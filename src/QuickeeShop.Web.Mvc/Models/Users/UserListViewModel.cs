using System.Collections.Generic;
using QuickeeShop.Roles.Dto;
using QuickeeShop.Users.Dto;

namespace QuickeeShop.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
