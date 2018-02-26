using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyProject.Controllers;

namespace MyProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
