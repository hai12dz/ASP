using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class ChuongTrinhDaoTao
{
    public string MaCtdt { get; set; } = null!;

    public string? TenCtdt { get; set; }

    public string? TenCtdttiengAnh { get; set; }

    public string? MaKhoa { get; set; }

    public string? NganhApDung { get; set; }

    public string? KhoaHocApDung { get; set; }

    public virtual ICollection<CtdtHocPhan> CtdtHocPhans { get; set; } = new List<CtdtHocPhan>();

    public virtual Khoa? MaKhoaNavigation { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
