using System.Threading.Tasks;
using Brenoma.Configuration.Dto;

namespace Brenoma.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
