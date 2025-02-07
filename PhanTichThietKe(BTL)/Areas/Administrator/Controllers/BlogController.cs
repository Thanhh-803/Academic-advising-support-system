using Education.Model.Entities;
using Education.Repository;
using Microsoft.AspNetCore.Mvc;
using PhanTichThietKe_BTL_.Controllers;

namespace PhanTichThietKe_BTL_.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class BlogController : Controller
    {
        private BlogRepository blogRepo;

        public BlogController()
        {
            blogRepo = new BlogRepository();
        }
        public IActionResult Index()
        {
            var blog = blogRepo.GetAll().ToList();
            return View(blog);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    blogRepo.Insert(blog);
                    return Redirect("/Administrator/Blog/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(blog);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blog = blogRepo.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    blogRepo.Update(blog);
                    return Redirect("/Administrator/Blog/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(blog);
        }
        public IActionResult Delete(int id) // Xóa sản phẩm
        {
            blogRepo.Delete(id);
            return Redirect("/Administrator/Blog/Index");

        }
    }
}
