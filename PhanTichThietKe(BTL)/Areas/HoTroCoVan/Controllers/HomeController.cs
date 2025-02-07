using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Areas.HoTroCoVan.Controllers
{
    [Area("HoTroCoVan")]
    public class HomeController : Controller
    {

        

        public IActionResult Index()
        {
            return View();
        }
    }
}
