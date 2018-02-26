using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyProject.Web.Views
{
    public abstract class MyProjectViewComponent : AbpViewComponent
    {
        protected MyProjectViewComponent()
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
        }
    }
}
