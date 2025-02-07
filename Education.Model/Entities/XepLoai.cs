using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class XepLoai
    {
        public int MaSinhVien { get; set; }
        public string? HoTen { get; set; }
        public double? Diem { get; set; }
        public string? XepLoai1 { get; set; }
        public int Ki { get; set; }
        public int NamHoc { get; set; }

        public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;
    }
}
