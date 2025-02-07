using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Education.Model.Entities
{
    public partial class User
    {
        public User()
        {
            GiaoVienChuNhiems = new HashSet<GiaoVienChuNhiem>();
            SinhViens = new HashSet<SinhVien>();
        }

        public int Id { get; set; }
        [Required]
        public string TenDangNhap { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string? MatKhau { get; set; }
        public string? UserType { get; set; }

        public virtual ICollection<GiaoVienChuNhiem> GiaoVienChuNhiems { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
