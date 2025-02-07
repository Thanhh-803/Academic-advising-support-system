using Education.Model.Entities;
using Education.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HeThongHoTroCoVan.Areas.HoTroCoVan.Controllers
{
    [Area("HoTroCoVan")]
    public class KetQuaHocTapController : Controller
    {
        private KetQuaHocTapRepository ketQuaHocTapRepo;
        private MonHocRepository monHocRepo;

        public KetQuaHocTapController()
        {
            ketQuaHocTapRepo = new KetQuaHocTapRepository();
            monHocRepo= new MonHocRepository();

        }
        public IActionResult Index()
        {
            var monHoc = monHocRepo.GetAll().ToList();
            return View(monHoc);
        }

        public IActionResult Grade(int id)
        {
            var grade = ketQuaHocTapRepo.GetAll().Where(p => p.MaMh == id).ToList();
            return View(grade);
        }
        [HttpGet]
        public IActionResult CreateGrade()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateGrade(KetQuaHocTap hocTap)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ketQuaHocTapRepo.Insert(hocTap);
                    return Redirect("/HoTroCoVan/KetQuaHocTap/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(hocTap);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sinhVien = ketQuaHocTapRepo.GetById(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            return View(sinhVien);
        }

        [HttpPost]
        public IActionResult Edit(KetQuaHocTap hocTap)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ketQuaHocTapRepo.Update(hocTap);
                    return Redirect("/HoTroCoVan/SinhVien/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(hocTap);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            ketQuaHocTapRepo.Delete(id);
            return Redirect("/HoTroCoVan/SinhVien/Index");

        }



    }
}
