using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class GiaoVienChuNhiem
    {
        public GiaoVienChuNhiem()
        {
            LichHenTuVans = new HashSet<LichHenTuVan>();
        }

        public int MaGv { get; set; }
        public string HoTen { get; set; } = null!;
        public int? UsersId { get; set; }
        public string? PhongBan { get; set; }
        public string? Khoa { get; set; }

        public virtual User? Users { get; set; }
        public virtual ICollection<LichHenTuVan> LichHenTuVans { get; set; }
    }
}
