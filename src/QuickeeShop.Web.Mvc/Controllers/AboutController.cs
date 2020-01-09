using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using QuickeeShop.Controllers;

namespace QuickeeShop.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : QuickeeShopControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
