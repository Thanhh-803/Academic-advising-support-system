using Education.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PhanTichThietKe_BTL_.Controllers
{
    public class UserController : Controller
    {
        private UserRepository userRepo;

        public UserController()
        {
            userRepo= new UserRepository();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public enum UserRole
        {
            Admin,
            GVCN,
            Sinhvien,
            Sinhvienn
        }

        public IActionResult NavigateToUserRole(UserRole role)
        {
            switch (role)
            {
                case UserRole.Admin:
                    return Redirect("/Administrator/Home/Index");
                case UserRole.GVCN:
                    return Redirect("/HoTroCoVan/Home/Index");
                case UserRole.Sinhvien:
                    return Redirect("/Home/Index");
                case UserRole.Sinhvienn:
                    return Redirect("/HoTroCoVan/Home/Index");
                default:
                    return RedirectToAction("/Home/Index");
            }
        }

        public UserRole GetRoleForUser(int Id, string matKhau)
        {
            var user = userRepo.GetAll().FirstOrDefault(u => u.Id == Id && u.MatKhau == matKhau);

            if (user != null)
            {
                
                if (user.UserType == "Admin")
                {
                    return UserRole.Admin;
                }
                else if (user.UserType == "GVCN")
                {
                    return UserRole.GVCN;
                }
                else if (user.UserType == "Sinhvien")
                {
                    return UserRole.Sinhvien;
                }
                else if (user.UserType == "Sinhvienn")
                {
                    return UserRole.Sinhvienn;
                }
            }

            return UserRole.Sinhvienn; // Default to Student if role is not found
        }

        [HttpPost]
        public IActionResult Login(int Id, string matKhau)
        {
            if (string.IsNullOrEmpty(matKhau) || Id <= 0)
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin đăng nhập");
                return View();
            }

            var userRole = GetRoleForUser(Id, matKhau);

            if (userRole == UserRole.Sinhvienn)
            {
                ModelState.AddModelError("", "Thông tin đăng nhập không chính xác");
                return View();
            }


            //return Redirect("/Home/Index");

            return NavigateToUserRole(userRole);
        }

    }
}
