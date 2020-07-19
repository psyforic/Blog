using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Brenoma.Controllers
{
    public abstract class BrenomaControllerBase: AbpController
    {
        protected BrenomaControllerBase()
        {
            LocalizationSourceName = BrenomaConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
