using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThucHanhWebMVC.Models;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BoMon> BoMons { get; set; }

    public virtual DbSet<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; }

    public virtual DbSet<CtdtHocPhan> CtdtHocPhans { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<HocPhan> HocPhans { get; set; }

    public virtual DbSet<HocPhanTienQuyet> HocPhanTienQuyets { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<LopHocPhan> LopHocPhans { get; set; }

    public virtual DbSet<LopHocPhanSinhVien> LopHocPhanSinhViens { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<TAnhChiTietSp> TAnhChiTietSps { get; set; }

    public virtual DbSet<TAnhSp> TAnhSps { get; set; }

    public virtual DbSet<TChatLieu> TChatLieus { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietSanPham> TChiTietSanPhams { get; set; }

    public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; }

    public virtual DbSet<THangSx> THangSxes { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TKichThuoc> TKichThuocs { get; set; }

    public virtual DbSet<TLoaiDt> TLoaiDts { get; set; }

    public virtual DbSet<TLoaiSp> TLoaiSps { get; set; }

    public virtual DbSet<TMauSac> TMauSacs { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TQuocGium> TQuocGia { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HAI\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoMon>(entity =>
        {
            entity.HasKey(e => e.MaBoMon).HasName("pk_BoMon");

            entity.ToTable("BoMon");

            entity.Property(e => e.MaBoMon)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenBoMon).HasMaxLength(200);
            entity.Property(e => e.TenTiengAnh)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TruongBoMon)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.BoMons)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK_BoMon_Khoa");
        });

        modelBuilder.Entity<ChuongTrinhDaoTao>(entity =>
        {
            entity.HasKey(e => e.MaCtdt).HasName("pk_ChuongTrinhDaoTao");

            entity.ToTable("ChuongTrinhDaoTao");

            entity.Property(e => e.MaCtdt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("MaCTDT");
            entity.Property(e => e.KhoaHocApDung)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NganhApDung).HasMaxLength(200);
            entity.Property(e => e.TenCtdt)
                .HasMaxLength(200)
                .HasColumnName("TenCTDT");
            entity.Property(e => e.TenCtdttiengAnh)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TenCTDTTiengAnh");

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.ChuongTrinhDaoTaos)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK_ChuongTrinhDaoTao_Khoa");
        });

        modelBuilder.Entity<CtdtHocPhan>(entity =>
        {
            entity.HasKey(e => new { e.MaCtdt, e.MaHocPhan }).HasName("pk_CTDT_HocPhan");

            entity.ToTable("CTDT_HocPhan");

            entity.Property(e => e.MaCtdt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("MaCTDT");
            entity.Property(e => e.MaHocPhan)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.MaCtdtNavigation).WithMany(p => p.CtdtHocPhans)
                .HasForeignKey(d => d.MaCtdt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTDT_HocPhan_ChuongTrinhDaoTao");

            entity.HasOne(d => d.MaHocPhanNavigation).WithMany(p => p.CtdtHocPhans)
                .HasForeignKey(d => d.MaHocPhan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTDT_HocPhan_HocPhan");
        });

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.MaGiangVien).HasName("pk_GiangVien");

            entity.ToTable("GiangVien");

            entity.Property(e => e.MaGiangVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ChucDanh).HasMaxLength(20);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoDem).HasMaxLength(35);
            entity.Property(e => e.HocHam).HasMaxLength(20);
            entity.Property(e => e.HocVi).HasMaxLength(20);
            entity.Property(e => e.MaBoMon)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ten).HasMaxLength(35);

            entity.HasOne(d => d.MaBoMonNavigation).WithMany(p => p.GiangViens)
                .HasForeignKey(d => d.MaBoMon)
                .HasConstraintName("FK_GiangVien_BoMon");
        });

        modelBuilder.Entity<HocPhan>(entity =>
        {
            entity.HasKey(e => e.MaHocPhan).HasName("pk_HocPhan");

            entity.ToTable("HocPhan");

            entity.Property(e => e.MaHocPhan)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MaBoMon)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenHocPhan).HasMaxLength(200);
            entity.Property(e => e.TenTiengAnh).HasMaxLength(200);
            entity.Property(e => e.TrongSoDiemThiKthp).HasColumnName("TrongSoDiemThiKTHP");

            entity.HasOne(d => d.MaBoMonNavigation).WithMany(p => p.HocPhans)
                .HasForeignKey(d => d.MaBoMon)
                .HasConstraintName("FK_HocPhan_BoMon");
        });

        modelBuilder.Entity<HocPhanTienQuyet>(entity =>
        {
            entity.HasKey(e => new { e.MaHocPhan, e.MaHocPhanTienQuyet }).HasName("pk_HocPhanTienQuyet");

            entity.ToTable("HocPhanTienQuyet");

            entity.Property(e => e.MaHocPhan)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MaHocPhanTienQuyet)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.MaHocPhanNavigation).WithMany(p => p.HocPhanTienQuyetMaHocPhanNavigations)
                .HasForeignKey(d => d.MaHocPhan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HocPhanTienQuyet_HocPhan");

            entity.HasOne(d => d.MaHocPhanTienQuyetNavigation).WithMany(p => p.HocPhanTienQuyetMaHocPhanTienQuyetNavigations)
                .HasForeignKey(d => d.MaHocPhanTienQuyet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HocPhanTienQuyet_HocPhan1");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("pk_Khoa");

            entity.ToTable("Khoa");

            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenKhoa).HasMaxLength(200);
            entity.Property(e => e.TenTiengAnh).HasMaxLength(200);
            entity.Property(e => e.Website).HasColumnType("ntext");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("pk_Lop");

            entity.ToTable("Lop");

            entity.Property(e => e.MaLop)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.KhoaHoc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenLop).HasMaxLength(200);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK_Lop_Khoa");
        });

        modelBuilder.Entity<LopHocPhan>(entity =>
        {
            entity.HasKey(e => new { e.MaHocPhan, e.MaLopHocPhan }).HasName("pk_LopHocPhan");

            entity.ToTable("LopHocPhan");

            entity.Property(e => e.MaHocPhan)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MaLopHocPhan)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MaGiangVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NamHoc)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenLopHocPhan).HasMaxLength(200);

            entity.HasOne(d => d.MaGiangVienNavigation).WithMany(p => p.LopHocPhans)
                .HasForeignKey(d => d.MaGiangVien)
                .HasConstraintName("FK_LopHocPhan_GiangVien");

            entity.HasOne(d => d.MaHocPhanNavigation).WithMany(p => p.LopHocPhans)
                .HasForeignKey(d => d.MaHocPhan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LopHocPhan_HocPhan");
        });

        modelBuilder.Entity<LopHocPhanSinhVien>(entity =>
        {
            entity.HasKey(e => new { e.MaHocPhan, e.MaLopHocPhan, e.MaSinhVien }).HasName("pk_LopHocPhan_SinhVien");

            entity.ToTable("LopHocPhan_SinhVien");

            entity.Property(e => e.MaHocPhan)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MaLopHocPhan)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MaSinhVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DiemHeChu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DiemThiKthp).HasColumnName("DiemThiKTHP");
            entity.Property(e => e.DiemTkhp).HasColumnName("DiemTKHP");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.LopHocPhanSinhViens)
                .HasForeignKey(d => d.MaSinhVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LopHocPhan_SinhVien_SinhVien");

            entity.HasOne(d => d.LopHocPhan).WithMany(p => p.LopHocPhanSinhViens)
                .HasForeignKey(d => new { d.MaHocPhan, d.MaLopHocPhan })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LopHocPhan_SinhVien_LopHocPhan");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien).HasName("pk_SinhVien");

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaSinhVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DiaChi).HasMaxLength(250);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoDem).HasMaxLength(35);
            entity.Property(e => e.MaCtdt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("MaCTDT");
            entity.Property(e => e.MaLop)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Ten).HasMaxLength(35);

            entity.HasOne(d => d.MaCtdtNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaCtdt)
                .HasConstraintName("FK_SinhVien_ChuongTrinhDaoTao");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK_SinhVien_Lop");
        });

        modelBuilder.Entity<TAnhChiTietSp>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietSp, e.TenFileAnh });

            entity.ToTable("tAnhChiTietSP");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.TenFileAnh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TAnhChiTietSps)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhChiTietSP_tChiTietSanPham");
        });

        modelBuilder.Entity<TAnhSp>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.TenFileAnh });

            entity.ToTable("tAnhSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.TenFileAnh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TAnhSps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhSP_tDanhMucSP");
        });

        modelBuilder.Entity<TChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu);

            entity.ToTable("tChatLieu");

            entity.Property(e => e.MaChatLieu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChatLieu).HasMaxLength(150);
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaChiTietSp });

            entity.ToTable("tChiTietHDB");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.GhiChu).HasMaxLength(100);

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tChiTietSanPham");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tHoaDonBan");
        });

        modelBuilder.Entity<TChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSp);

            entity.ToTable("tChiTietSanPham");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaMauSac)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.Slton).HasColumnName("SLTon");
            entity.Property(e => e.Video)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK_tChiTietSanPham_tKichThuoc");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaMauSac)
                .HasConstraintName("FK_tChiTietSanPham_tMauSac");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK_tChiTietSanPham_tDanhMucSP");
        });

        modelBuilder.Entity<TDanhMucSp>(entity =>
        {
            entity.HasKey(e => e.MaSp);

            entity.ToTable("tDanhMucSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GiaLonNhat).HasColumnType("money");
            entity.Property(e => e.GiaNhoNhat).HasColumnType("money");
            entity.Property(e => e.GioiThieuSp)
                .HasMaxLength(255)
                .HasColumnName("GioiThieuSP");
            entity.Property(e => e.MaChatLieu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaDacTinh)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaDt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDT");
            entity.Property(e => e.MaHangSx)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHangSX");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNuocSx)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNuocSX");
            entity.Property(e => e.Model).HasMaxLength(55);
            entity.Property(e => e.NganLapTop).HasMaxLength(55);
            entity.Property(e => e.TenSp)
                .HasMaxLength(150)
                .HasColumnName("TenSP");
            entity.Property(e => e.Website)
                .HasMaxLength(155)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaChatLieu)
                .HasConstraintName("FK_tDanhMucSP_tChatLieu");

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaDt)
                .HasConstraintName("FK_tDanhMucSP_tLoaiDT");

            entity.HasOne(d => d.MaHangSxNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaHangSx)
                .HasConstraintName("FK_tDanhMucSP_tHangSX");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_tDanhMucSP_tLoaiSP");

            entity.HasOne(d => d.MaNuocSxNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaNuocSx)
                .HasConstraintName("FK_tDanhMucSP_tQuocGia");
        });

        modelBuilder.Entity<THangSx>(entity =>
        {
            entity.HasKey(e => e.MaHangSx);

            entity.ToTable("tHangSX");

            entity.Property(e => e.MaHangSx)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHangSX");
            entity.Property(e => e.HangSx)
                .HasMaxLength(100)
                .HasColumnName("HangSX");
            entity.Property(e => e.MaNuocThuongHieu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");
            entity.Property(e => e.ThongTinThue).HasMaxLength(250);
            entity.Property(e => e.TongTienHd)
                .HasColumnType("money")
                .HasColumnName("TongTienHD");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_tHoaDonBan_tKhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_tHoaDonBan_tNhanVien");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhanhHang);

            entity.ToTable("tKhachHang");

            entity.Property(e => e.MaKhanhHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TKhachHangs)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_tKhachHang_tUser");
        });

        modelBuilder.Entity<TKichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc);

            entity.ToTable("tKichThuoc");

            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.KichThuoc)
                .HasMaxLength(150)
                .IsFixedLength();
        });

        modelBuilder.Entity<TLoaiDt>(entity =>
        {
            entity.HasKey(e => e.MaDt);

            entity.ToTable("tLoaiDT");

            entity.Property(e => e.MaDt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDT");
            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<TLoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("tLoaiSP");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Loai).HasMaxLength(100);
        });

        modelBuilder.Entity<TMauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac);

            entity.ToTable("tMauSac");

            entity.Property(e => e.MaMauSac)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenMauSac).HasMaxLength(100);
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien);

            entity.ToTable("tNhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SoDienThoai2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNhanVien).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TNhanViens)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_tNhanVien_tUser");
        });

        modelBuilder.Entity<TQuocGium>(entity =>
        {
            entity.HasKey(e => e.MaNuoc);

            entity.ToTable("tQuocGia");

            entity.Property(e => e.MaNuoc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNuoc).HasMaxLength(100);
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("tUser");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
