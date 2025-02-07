using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly  SinhVienRepository sinhVienRepo;

        public SinhVienController()
        {
            sinhVienRepo= new SinhVienRepository();
        }
        public IActionResult Index()
        {
            var sinhVien = sinhVienRepo.GetAll().ToList();
            return View();
        }
    }
}
