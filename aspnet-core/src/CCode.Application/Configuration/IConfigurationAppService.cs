using System.Threading.Tasks;
using CCode.Configuration.Dto;

namespace CCode.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
