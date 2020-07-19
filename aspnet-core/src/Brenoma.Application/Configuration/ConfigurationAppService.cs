using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Brenoma.Configuration.Dto;

namespace Brenoma.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BrenomaAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
