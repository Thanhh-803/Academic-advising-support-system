using Education.Model.Entities;
using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HomeController : Controller
    {
        private UserRepository userRepo;

        public HomeController()
        {
            userRepo= new UserRepository();
        }
        public IActionResult Index()
        {
            var user = userRepo.GetAll().ToList();
            return View(user);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepo.Insert(user);
                    return Redirect("/Administrator/Home/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = userRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepo.Update(user);
                    return Redirect("/Administrator/Home/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(user);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            userRepo.Delete(id);
            return Redirect("/Administrator/Home/Index");

        }
    }
}