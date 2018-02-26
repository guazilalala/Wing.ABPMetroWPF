using System.Web.Mvc;

namespace MyProject.Web.Controllers
{
    public class AboutController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}