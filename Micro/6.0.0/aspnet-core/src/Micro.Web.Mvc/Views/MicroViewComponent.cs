using Abp.AspNetCore.Mvc.ViewComponents;

namespace Micro.Web.Views
{
    public abstract class MicroViewComponent : AbpViewComponent
    {
        protected MicroViewComponent()
        {
            LocalizationSourceName = MicroConsts.LocalizationSourceName;
        }
    }
}
