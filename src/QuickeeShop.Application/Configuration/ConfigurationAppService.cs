using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using QuickeeShop.Configuration.Dto;

namespace QuickeeShop.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : QuickeeShopAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
