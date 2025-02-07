using Education.Model.Entities;
using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Controllers
{
	public class LichHenController : Controller
	{
		private readonly LichHenRepository lichHenRepo;

		public LichHenController()
		{
			lichHenRepo= new LichHenRepository();
		}

        public IActionResult XemLichHen()
        {
            var lichHen = lichHenRepo.GetAll().ToList();
            return View(lichHen);
        }

        [HttpGet]
        public IActionResult DatLichHen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DatLichHen(LichHenTuVan lichHen)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lichHenRepo.Insert(lichHen);
                    return Redirect("/LichHen/XemLichHen"); 
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("không thể thêm lịch hẹn", ex.Message);
            }
            return View(lichHen);
        }
        
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            lichHenRepo.Delete(id);
            return Redirect("/LichHen/XemLichHen");

        }
    }
}
