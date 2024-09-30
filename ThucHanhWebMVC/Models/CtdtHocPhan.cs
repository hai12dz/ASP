using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class CtdtHocPhan
{
    public string MaCtdt { get; set; } = null!;

    public string MaHocPhan { get; set; } = null!;

    public int? KyHoc { get; set; }

    public virtual ChuongTrinhDaoTao MaCtdtNavigation { get; set; } = null!;

    public virtual HocPhan MaHocPhanNavigation { get; set; } = null!;
}
