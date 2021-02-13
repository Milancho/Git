using System.Threading.Tasks;
using Micro.Configuration.Dto;

namespace Micro.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
