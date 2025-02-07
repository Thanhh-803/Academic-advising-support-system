using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class LichHenTuVan
    {
        public int Id { get; set; }
        public DateTime? ThoiGian { get; set; }
        public int? MaGiaoVien { get; set; }
        public int? MaSinhVien { get; set; }
        public string? DiaDiem { get; set; }
        public string? NoiDungTuVan { get; set; }
        public string? TrangThai { get; set; }
        public string tenSV { get; set; }
        public string tenGVCN { get; set; }

        public string phone { get; set; }

        public virtual GiaoVienChuNhiem? MaGiaoVienNavigation { get; set; }
        public virtual SinhVien? MaSinhVienNavigation { get; set; }
    }
}
