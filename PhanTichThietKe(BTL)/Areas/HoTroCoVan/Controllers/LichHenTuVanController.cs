using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Areas.HoTroCoVan.Controllers
{
    [Area("HoTroCoVan")]
    public class LichHenTuVanController : Controller
    {
        

        private LichHenTuVanRepository lichHenTuVanRepo;

        public LichHenTuVanController()
        {
            lichHenTuVanRepo = new LichHenTuVanRepository();
        }
        public IActionResult Index()
        {
            var lhtuvan = lichHenTuVanRepo.GetAll().ToList();
            return View(lhtuvan);
        }
    }
}
