using Microsoft.AspNetCore.Mvc;
using GSoft.AbpZeroTemplate.Web.Controllers;

namespace GSoft.AbpZeroTemplate.Web.Public.Controllers
{
    public class HomeController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}