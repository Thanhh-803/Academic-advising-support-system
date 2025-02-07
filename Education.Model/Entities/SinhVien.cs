using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            HocPhis = new HashSet<HocPhi>();
            KetQuaHocTaps = new HashSet<KetQuaHocTap>();
            LichHenTuVans = new HashSet<LichHenTuVan>();
            PhieuRenLuyens = new HashSet<PhieuRenLuyen>();
            XepLoais = new HashSet<XepLoai>();
        }

        public int MaSv { get; set; }
        public string? HoTen { get; set; }
        public int? UsersId { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? Lop { get; set; }
        public string? Khoa { get; set; }
        public string? trangThai { get; set; }

        public virtual User? Users { get; set; }
        public virtual ICollection<HocPhi> HocPhis { get; set; }
        public virtual ICollection<KetQuaHocTap> KetQuaHocTaps { get; set; }
        public virtual ICollection<LichHenTuVan> LichHenTuVans { get; set; }
        public virtual ICollection<PhieuRenLuyen> PhieuRenLuyens { get; set; }
        public virtual ICollection<XepLoai> XepLoais { get; set; }
    }
}
