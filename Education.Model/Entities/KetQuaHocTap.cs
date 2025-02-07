using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class KetQuaHocTap
    {
        public int MaSinhVien { get; set; }
        public int MaMh { get; set; }
        public String tenSV { get; set; }
        public String tenMH { get; set; }
        public double? DiemChuyenCan { get; set; }
        public double? DiemKt1 { get; set; }
        public double? DiemKt2 { get; set; }
        public double? DiemThi { get; set; }
        public double? DiemTrungBinh { get; set; }

        public virtual MonHoc MaMhNavigation { get; set; } = null!;
        public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;
    }
}
