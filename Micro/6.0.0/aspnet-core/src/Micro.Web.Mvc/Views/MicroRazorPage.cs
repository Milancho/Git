using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Micro.Web.Views
{
    public abstract class MicroRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MicroRazorPage()
        {
            LocalizationSourceName = MicroConsts.LocalizationSourceName;
        }
    }
}
