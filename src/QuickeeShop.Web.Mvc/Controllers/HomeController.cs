using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using QuickeeShop.Controllers;

namespace QuickeeShop.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : QuickeeShopControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
