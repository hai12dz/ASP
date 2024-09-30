using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class BoMon
{
    public string MaBoMon { get; set; } = null!;

    public string? TenBoMon { get; set; }

    public string? TenTiengAnh { get; set; }

    public string? MaKhoa { get; set; }

    public string? TruongBoMon { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<GiangVien> GiangViens { get; set; } = new List<GiangVien>();

    public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();

    public virtual Khoa? MaKhoaNavigation { get; set; }
}
