using Microsoft.AspNetCore.Mvc;
using GSoft.AbpZeroTemplate.Web.Controllers;

namespace GSoft.AbpZeroTemplate.Web.Public.Controllers
{
    public class AboutController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}