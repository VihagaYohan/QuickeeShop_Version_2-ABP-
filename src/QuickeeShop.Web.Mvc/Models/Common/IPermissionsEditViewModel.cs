using System.Collections.Generic;
using QuickeeShop.Roles.Dto;

namespace QuickeeShop.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}