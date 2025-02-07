using Education.Model.Entities;
using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Areas.HoTroCoVan.Controllers
{
    [Area("HoTroCoVan")]
    public class PhieuRenLuyenController : Controller
    {
        private PhieuRenLuyenRepository phieuRenLuyenRepo;

        public PhieuRenLuyenController()
        {
            phieuRenLuyenRepo = new PhieuRenLuyenRepository();
        }
        public IActionResult Index(string namHoc)
        {
            var PRL = phieuRenLuyenRepo.GetAll().Where(prl => prl.NamHoc == namHoc).ToList();
            return View(PRL);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PhieuRenLuyen prl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    phieuRenLuyenRepo.Insert(prl);
                    return RedirectToAction("Index", new { namHoc = prl.NamHoc });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(prl);
        }
    }
}
