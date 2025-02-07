using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class PhieuRenLuyen
    {
        public int MaSinhVien { get; set; }
        public string? HoTen { get; set; }
        public string NamHoc { get; set; } = null!;
        public string? Ki1 { get; set; }
        public string? Ki2 { get; set; }
        public string? Tong { get; set; }
        public string? XepLoai { get; set; }

        public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;
    }
}
