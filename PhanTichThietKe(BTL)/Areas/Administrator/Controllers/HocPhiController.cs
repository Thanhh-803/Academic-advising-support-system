using Education.Model.Entities;
using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HocPhiController : Controller
    {
        private HocPhiRepository hocPhiRePo;
        public HocPhiController()
        {
            hocPhiRePo= new HocPhiRepository();
        }
        public IActionResult Index()
        {
            var hocPhi = hocPhiRePo.GetAll().ToList();

            return View(hocPhi);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HocPhi hocPhi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    hocPhiRePo.Insert(hocPhi);
                    return Redirect("/Administrator/HocPhi/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(hocPhi);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            hocPhiRePo.Delete(id);
            return Redirect("/Administrator/HocPhi/Index");

        }
    }
}
