using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class GiangVien
{
    public string MaGiangVien { get; set; } = null!;

    public string? HoDem { get; set; }

    public string? Ten { get; set; }

    public string? MaBoMon { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? HocHam { get; set; }

    public string? HocVi { get; set; }

    public string? ChucDanh { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<LopHocPhan> LopHocPhans { get; set; } = new List<LopHocPhan>();

    public virtual BoMon? MaBoMonNavigation { get; set; }
}
