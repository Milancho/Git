using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Micro.Controllers
{
    public abstract class MicroControllerBase: AbpController
    {
        protected MicroControllerBase()
        {
            LocalizationSourceName = MicroConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
