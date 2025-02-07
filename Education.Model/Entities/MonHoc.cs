using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            KetQuaHocTaps = new HashSet<KetQuaHocTap>();
            LopHocPhans = new HashSet<LopHocPhan>();
        }

        public int MaMonHoc { get; set; }
        public string? TenMonHoc { get; set; }
        public int? SoTinChi { get; set; }

        public virtual ICollection<KetQuaHocTap> KetQuaHocTaps { get; set; }
        public virtual ICollection<LopHocPhan> LopHocPhans { get; set; }
    }
}
