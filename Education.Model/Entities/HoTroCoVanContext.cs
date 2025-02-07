using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Education.Model.Entities
{
    public partial class HoTroCoVanContext : DbContext
    {
        public HoTroCoVanContext()
        {
        }

        public HoTroCoVanContext(DbContextOptions<HoTroCoVanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<DanhMuc> DanhMucs { get; set; } = null!;
        public virtual DbSet<GiaoVienChuNhiem> GiaoVienChuNhiems { get; set; } = null!;
        public virtual DbSet<HocPhi> HocPhis { get; set; } = null!;
        public virtual DbSet<KetQuaHocTap> KetQuaHocTaps { get; set; } = null!;
        public virtual DbSet<LichHenTuVan> LichHenTuVans { get; set; } = null!;
        public virtual DbSet<LopHocPhan> LopHocPhans { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<PhieuRenLuyen> PhieuRenLuyens { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<XepLoai> XepLoais { get; set; } = null!;
        public virtual DbSet<tenKhoa> TenKhoas { get; set; } = null!;
        public virtual DbSet<feedback> feedbacks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-B1P0DK29;Database=HoTroCoVan;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);
                entity.Property(e => e.CreateBy).HasMaxLength(250);
                entity.Property(e => e.CreateDate).HasMaxLength(250);
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.ToTable("DanhMuc");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.MoTa).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<GiaoVienChuNhiem>(entity =>
            {
                entity.HasKey(e => e.MaGv)
                    .HasName("PK__GiaoVien__7A3E2D7507020F21");

                entity.ToTable("GiaoVienChuNhiem");

                entity.Property(e => e.MaGv)
                    .ValueGeneratedNever()
                    .HasColumnName("maGV");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(250)
                    .HasColumnName("hoTen");

                entity.Property(e => e.Khoa).HasMaxLength(255);

                entity.Property(e => e.PhongBan)
                    .HasMaxLength(255)
                    .HasColumnName("phongBan");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.GiaoVienChuNhiems)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__GiaoVienC__Users__08EA5793");
            });

            modelBuilder.Entity<HocPhi>(entity =>
            {
                entity.HasKey(e => new { e.MaSinhVien, e.Ki, e.NamHoc })
                    .HasName("PK__HocPhi__7E69537B286302EC");

                entity.ToTable("HocPhi");

                entity.Property(e => e.MaSinhVien).HasColumnName("maSinhVien");

                entity.Property(e => e.Ki)
                    .HasMaxLength(500)
                    .HasColumnName("ki");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(500)
                    .HasColumnName("namHoc");

                entity.Property(e => e.MucHocPhi)
                    .HasColumnType("DECIMAL(18, 3)")
                    .HasColumnName("mucHocPhi");
                entity.Property(e => e.HocPhiDaNop)
                    .HasColumnType("DECIMAL(18, 3)")
                    .HasColumnName("hocPhiDaNop");
                entity.Property(e => e.ThuaThieu)
                    .HasColumnType("DECIMAL(18, 3)")
                    .HasColumnName("thuaThieu");
                entity.Property(e => e.Status)
                    .HasMaxLength(500)
                    .HasColumnName("status");

                entity.Property(e => e.tenSV)
                    .HasMaxLength(500)
                    .HasColumnName("tenSV");

                entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.HocPhis)
                    .HasForeignKey(d => d.MaSinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HocPhi__maSinhVi__2A4B4B5E");
            });

            modelBuilder.Entity<KetQuaHocTap>(entity =>
            {
                entity.HasKey(e => new { e.MaSinhVien, e.MaMh })
                    .HasName("PK__KetQuaHo__AE15039A1920BF5C");

                entity.ToTable("KetQuaHocTap");

                entity.Property(e => e.MaSinhVien).HasColumnName("maSinhVien");

                entity.Property(e => e.MaMh).HasColumnName("maMH");

                entity.Property(e => e.DiemChuyenCan).HasColumnName("diemChuyenCan");

                entity.Property(e => e.DiemKt1).HasColumnName("diemKT1");

                entity.Property(e => e.DiemKt2).HasColumnName("diemKT2");

                entity.Property(e => e.DiemThi).HasColumnName("diemThi");

                entity.Property(e => e.DiemTrungBinh).HasColumnName("diemTrungBinh");
                entity.Property(e => e.tenMH)
                    .HasMaxLength(250)
                    .HasColumnName("tenMH");
                entity.Property(e => e.tenSV)
                    .HasMaxLength(250)
                    .HasColumnName("teNSV");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.KetQuaHocTaps)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KetQuaHocT__maMH__1BFD2C07");

                entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.KetQuaHocTaps)
                    .HasForeignKey(d => d.MaSinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KetQuaHoc__maSin__1B0907CE");
            });

            modelBuilder.Entity<LichHenTuVan>(entity =>
            {
                entity.ToTable("LichHenTuVan");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DiaDiem)
                    .HasMaxLength(255)
                    .HasColumnName("diaDiem");

                entity.Property(e => e.MaGiaoVien).HasColumnName("maGiaoVien");

                entity.Property(e => e.MaSinhVien).HasColumnName("maSinhVien");

                entity.Property(e => e.NoiDungTuVan)
                    .HasMaxLength(255)
                    .HasColumnName("noiDungTuVan");

                entity.Property(e => e.ThoiGian)
                    .HasColumnType("date")
                    .HasColumnName("thoiGian");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(255)
                    .HasColumnName("trangThai");

                entity.Property(e => e.tenSV)
                    .HasMaxLength(255)
                    .HasColumnName("tenSV");

                entity.Property(e => e.tenGVCN)
                    .HasMaxLength(255)
                    .HasColumnName("tenGVCN");

                entity.Property(e => e.phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.HasOne(d => d.MaGiaoVienNavigation)
                    .WithMany(p => p.LichHenTuVans)
                    .HasForeignKey(d => d.MaGiaoVien)
                    .HasConstraintName("FK__LichHenTu__maGia__2F10007B");

                entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.LichHenTuVans)
                    .HasForeignKey(d => d.MaSinhVien)
                    .HasConstraintName("FK__LichHenTu__maSin__300424B4");
            });

            modelBuilder.Entity<LopHocPhan>(entity =>
            {
                entity.HasKey(e => e.MaLopHp)
                    .HasName("PK__LopHocPh__C157AC5B239E4DCF");

                entity.ToTable("LopHocPhan");

                entity.Property(e => e.MaLopHp)
                    .ValueGeneratedNever()
                    .HasColumnName("maLopHP");

                entity.Property(e => e.GiangVien)
                    .HasMaxLength(500)
                    .HasColumnName("giangVien");

                entity.Property(e => e.MaMh).HasColumnName("maMH");

                entity.Property(e => e.PhongHoc)
                    .HasMaxLength(500)
                    .HasColumnName("phongHoc");

                entity.Property(e => e.SoLuongSv)
                    .HasMaxLength(500)
                    .HasColumnName("soLuongSV");

                entity.Property(e => e.SoTinChi).HasColumnName("soTinChi");

                entity.Property(e => e.ThoiGianHoc)
                    .HasColumnType("date")
                    .HasColumnName("thoiGianHoc");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.LopHocPhans)
                    .HasForeignKey(d => d.MaMh)
                    .HasConstraintName("FK__LopHocPhan__maMH__25869641");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMonHoc)
                    .HasName("PK__MonHoc__990DDC6B15502E78");

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMonHoc)
                    .ValueGeneratedNever()
                    .HasColumnName("maMonHoc");

                entity.Property(e => e.SoTinChi).HasColumnName("soTinChi");

                entity.Property(e => e.TenMonHoc)
                    .HasMaxLength(255)
                    .HasColumnName("tenMonHoc");
            });

            modelBuilder.Entity<PhieuRenLuyen>(entity =>
            {
                entity.HasKey(e => new { e.MaSinhVien, e.NamHoc })
                    .HasName("PK__PhieuRen__965EE6A61ED998B2");

                entity.ToTable("PhieuRenLuyen");

                entity.Property(e => e.MaSinhVien).HasColumnName("maSinhVien");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(500)
                    .HasColumnName("namHoc");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("hoTen");

                entity.Property(e => e.Ki1)
                    .HasMaxLength(500)
                    .HasColumnName("ki_1");

                entity.Property(e => e.Ki2)
                    .HasMaxLength(500)
                    .HasColumnName("ki_2");

                entity.Property(e => e.Tong).HasMaxLength(500);

                entity.Property(e => e.XepLoai)
                    .HasMaxLength(500)
                    .HasColumnName("xepLoai");

                entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.PhieuRenLuyens)
                    .HasForeignKey(d => d.MaSinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuRenL__maSin__20C1E124");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv)
                    .HasName("PK__SinhVien__7A227A640BC6C43E");

                entity.ToTable("SinhVien");

                entity.Property(e => e.MaSv)
                    .ValueGeneratedNever()
                    .HasColumnName("maSV");

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(255)
                    .HasColumnName("diaChi");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(10)
                    .HasColumnName("gioiTinh");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("hoTen");

                entity.Property(e => e.Khoa)
                    .HasMaxLength(255)
                    .HasColumnName("khoa");

                entity.Property(e => e.Lop)
                    .HasMaxLength(255)
                    .HasColumnName("lop");
                entity.Property(e => e.trangThai)
                    .HasMaxLength(255)
                    .HasColumnName("trangThai");

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaySinh");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__SinhVien__Users___0DAF0CB0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(255)
                    .HasColumnName("matKhau");

                entity.Property(e => e.TenDangNhap)
                    .HasMaxLength(250)
                    .HasColumnName("tenDangNhap");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .HasColumnName("userType");
            });

            modelBuilder.Entity<XepLoai>(entity =>
            {
                entity.HasKey(e => new { e.MaSinhVien, e.Ki, e.NamHoc })
                    .HasName("PK__XepLoai__7E69537B108B795B");

                entity.ToTable("XepLoai");

                entity.Property(e => e.MaSinhVien).HasColumnName("maSinhVien");

                entity.Property(e => e.Ki).HasColumnName("ki");

                entity.Property(e => e.NamHoc).HasColumnName("namHoc");

                entity.Property(e => e.Diem).HasColumnName("diem");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("hoTen");

                entity.Property(e => e.XepLoai1)
                    .HasMaxLength(255)
                    .HasColumnName("xepLoai");

                entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.XepLoais)
                    .HasForeignKey(d => d.MaSinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__XepLoai__maSinhV__1273C1CD");
            });
            modelBuilder.Entity<tenKhoa>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tenKhoa__7A227A640BC6C43E");

                entity.ToTable("tenKhoa");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");


                entity.Property(e => e.TenKhoa)
                    .HasMaxLength(255)
                    .HasColumnName("tenKhoa");
            });
            modelBuilder.Entity<KetQuaHocTap>(entity =>
            {
                entity.HasKey(e => new { e.MaSinhVien, e.MaMh })
                    .HasName("PK__KetQuaHo__AE15039A1920BF5C");

                entity.ToTable("KetQuaHocTap");

                entity.Property(e => e.MaSinhVien).HasColumnName("maSinhVien");

                entity.Property(e => e.MaMh).HasColumnName("maMH");

                entity.Property(e => e.DiemChuyenCan).HasColumnName("diemChuyenCan");

                entity.Property(e => e.DiemKt1).HasColumnName("diemKT1");

                entity.Property(e => e.DiemKt2).HasColumnName("diemKT2");

                entity.Property(e => e.DiemThi).HasColumnName("diemThi");

                entity.Property(e => e.DiemTrungBinh).HasColumnName("diemTrungBinh");
                entity.Property(e => e.tenMH)
                    .HasMaxLength(250)
                    .HasColumnName("tenMH");
                entity.Property(e => e.tenSV)
                    .HasMaxLength(250)
                    .HasColumnName("teNSV");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.KetQuaHocTaps)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KetQuaHocT__maMH__1BFD2C07");

                entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.KetQuaHocTaps)
                    .HasForeignKey(d => d.MaSinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KetQuaHoc__maSin__1B0907CE");
            });
			modelBuilder.Entity<feedback>(entity =>
			{
				entity.ToTable("feedback");

				entity.HasNoKey();

				entity.Property(e => e.hoTen).HasMaxLength(250);
				entity.Property(e => e.address).HasMaxLength(250);
				entity.Property(e => e.monHoc).HasMaxLength(250);
				entity.Property(e => e.message).HasMaxLength(250);
			});

			OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
