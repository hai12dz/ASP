using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class LopHocPhanSinhVien
{
    public string MaHocPhan { get; set; } = null!;

    public string MaLopHocPhan { get; set; } = null!;

    public string MaSinhVien { get; set; } = null!;

    public double? DiemQuaTrinh { get; set; }

    public double? DiemThiKthp { get; set; }

    public double? DiemTkhp { get; set; }

    public string? DiemHeChu { get; set; }

    public int? LanHoc { get; set; }

    public virtual LopHocPhan LopHocPhan { get; set; } = null!;

    public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;
}
