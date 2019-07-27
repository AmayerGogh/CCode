using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CCode.Controllers
{
    public abstract class CCodeControllerBase: AbpController
    {
        protected CCodeControllerBase()
        {
            LocalizationSourceName = CCodeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
