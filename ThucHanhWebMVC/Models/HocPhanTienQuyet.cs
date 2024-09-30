using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class HocPhanTienQuyet
{
    public string MaHocPhan { get; set; } = null!;

    public string MaHocPhanTienQuyet { get; set; } = null!;

    public bool? RangBuoc { get; set; }

    public virtual HocPhan MaHocPhanNavigation { get; set; } = null!;

    public virtual HocPhan MaHocPhanTienQuyetNavigation { get; set; } = null!;
}
