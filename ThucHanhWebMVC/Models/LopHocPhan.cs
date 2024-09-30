using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class LopHocPhan
{
    public string MaHocPhan { get; set; } = null!;

    public string MaLopHocPhan { get; set; } = null!;

    public string? TenLopHocPhan { get; set; }

    public string? MaGiangVien { get; set; }

    public string? NamHoc { get; set; }

    public int? HocKy { get; set; }

    public int? DotHoc { get; set; }

    public virtual ICollection<LopHocPhanSinhVien> LopHocPhanSinhViens { get; set; } = new List<LopHocPhanSinhVien>();

    public virtual GiangVien? MaGiangVienNavigation { get; set; }

    public virtual HocPhan MaHocPhanNavigation { get; set; } = null!;
}
