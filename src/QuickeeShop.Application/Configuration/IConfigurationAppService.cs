using System.Threading.Tasks;
using QuickeeShop.Configuration.Dto;

namespace QuickeeShop.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
