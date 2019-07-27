using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CCode.Configuration.Dto;

namespace CCode.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CCodeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
