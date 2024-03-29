using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using QuickeeShop.Roles.Dto;
using QuickeeShop.Users.Dto;

namespace QuickeeShop.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
