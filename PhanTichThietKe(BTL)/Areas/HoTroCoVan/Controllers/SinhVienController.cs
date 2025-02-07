using Education.Model.Entities;
using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Areas.HoTroCoVan.Controllers
{
    [Area("HoTroCoVan")]
    public class SinhVienController : Controller
    {
        private SinhVienRepository sinhVienRepo;

        public SinhVienController()
        {
            sinhVienRepo = new SinhVienRepository();
        }

        public IActionResult Index()
        {
            var sinhVien = sinhVienRepo.GetAll().ToList();
            return View(sinhVien);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SinhVien sinhVien)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sinhVienRepo.Insert(sinhVien);
                    return Redirect("/HoTroCoVan/SinhVien/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(sinhVien);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sinhVien = sinhVienRepo.GetById(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            return View(sinhVien);
        }

        [HttpPost]
        public IActionResult Edit(SinhVien sinhVien)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sinhVienRepo.Update(sinhVien);
                    return Redirect("/HoTroCoVan/SinhVien/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(sinhVien);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            sinhVienRepo.Delete(id);
            return Redirect("/HoTroCoVan/SinhVien/Index");

        }
    }
}
