using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class LopHocPhan
    {
        public int MaLopHp { get; set; }
        public int? MaMh { get; set; }
        public int? SoTinChi { get; set; }
        public string? GiangVien { get; set; }
        public string? PhongHoc { get; set; }
        public DateTime? ThoiGianHoc { get; set; }
        public string? SoLuongSv { get; set; }

        public virtual MonHoc? MaMhNavigation { get; set; }
    }
}
