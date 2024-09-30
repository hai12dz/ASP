using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class HocPhan
{
    public string MaHocPhan { get; set; } = null!;

    public string? TenHocPhan { get; set; }

    public string? TenTiengAnh { get; set; }

    public string? MaBoMon { get; set; }

    public int? SoTinChi { get; set; }

    public double? TrongSoDiemQuaTrinh { get; set; }

    public double? TrongSoDiemThiKthp { get; set; }

    public virtual ICollection<CtdtHocPhan> CtdtHocPhans { get; set; } = new List<CtdtHocPhan>();

    public virtual ICollection<HocPhanTienQuyet> HocPhanTienQuyetMaHocPhanNavigations { get; set; } = new List<HocPhanTienQuyet>();

    public virtual ICollection<HocPhanTienQuyet> HocPhanTienQuyetMaHocPhanTienQuyetNavigations { get; set; } = new List<HocPhanTienQuyet>();

    public virtual ICollection<LopHocPhan> LopHocPhans { get; set; } = new List<LopHocPhan>();

    public virtual BoMon? MaBoMonNavigation { get; set; }
}
