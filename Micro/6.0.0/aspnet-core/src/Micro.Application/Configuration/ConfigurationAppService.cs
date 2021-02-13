using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Micro.Configuration.Dto;

namespace Micro.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MicroAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
