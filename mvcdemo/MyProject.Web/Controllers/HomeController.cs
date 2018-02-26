using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace MyProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}