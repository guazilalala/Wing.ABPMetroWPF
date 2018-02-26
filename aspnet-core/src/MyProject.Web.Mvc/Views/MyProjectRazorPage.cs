using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MyProject.Web.Views
{
    public abstract class MyProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MyProjectRazorPage()
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
        }
    }
}
