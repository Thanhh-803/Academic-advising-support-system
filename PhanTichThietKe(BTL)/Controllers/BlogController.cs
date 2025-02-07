using Education.Model.Entities;
using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogRepository blogRepo;
        private readonly HocPhiRepository hocPhiRepo;
        private readonly feedbackRepository fbRepo;

        public BlogController()
        {
            blogRepo= new BlogRepository();
            hocPhiRepo= new HocPhiRepository();
            fbRepo = new feedbackRepository();
        }
        public IActionResult Content()
        {
            var blog = blogRepo.GetAll().OrderByDescending(p => p.Id).ToList();
            return View(blog);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Contact(feedback fb)
		{
			try
			{
				if (ModelState.IsValid)
				{
					fbRepo.Insert(fb);
					return Redirect("/Blog/Thongbao");
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
			}
			return View(fb);
		}

		public IActionResult TaiChinh()
        {
            var taiChinh = hocPhiRepo.GetAll().ToList();
            return View(taiChinh);
        }

        public IActionResult Thongbao()
        {
            return View();
        }
    }
}
