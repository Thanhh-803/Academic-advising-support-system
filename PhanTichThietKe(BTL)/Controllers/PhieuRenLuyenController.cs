using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Controllers
{
    public class PhieuRenLuyenController : Controller
    {
        public readonly PhieuRenLuyenRepository prlRepo;
        
        public PhieuRenLuyenController()
        {
            prlRepo = new PhieuRenLuyenRepository();
        }

        public IActionResult Index(string namHoc)
        {
            var PRL = prlRepo.GetAll().Where(prl => prl.NamHoc == namHoc).ToList();
            return View(PRL);
        }
    }
}
