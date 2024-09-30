using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class SinhVien
{
    public string MaSinhVien { get; set; } = null!;

    public string? HoDem { get; set; }

    public string? Ten { get; set; }

    public string? MaCtdt { get; set; }

    public string? MaLop { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<LopHocPhanSinhVien> LopHocPhanSinhViens { get; set; } = new List<LopHocPhanSinhVien>();

    public virtual ChuongTrinhDaoTao? MaCtdtNavigation { get; set; }

    public virtual Lop? MaLopNavigation { get; set; }
}
