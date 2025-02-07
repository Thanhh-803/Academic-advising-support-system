using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class HocPhi
    {
        public int MaSinhVien { get; set; }
        public string Ki { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public Decimal? MucHocPhi { get; set; }
        public string? Status { get; set; }
        public string? tenSV { get; set; }
        public Decimal? HocPhiDaNop { get; set; }

        public Decimal? ThuaThieu { get; set; }
        public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;
    }
}
