using System;
using System.Collections.Generic;

namespace ThucHanhWebMVC.Models;

public partial class Khoa
{
    public string MaKhoa { get; set; } = null!;

    public string? TenKhoa { get; set; }

    public string? TenTiengAnh { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<BoMon> BoMons { get; set; } = new List<BoMon>();

    public virtual ICollection<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; } = new List<ChuongTrinhDaoTao>();

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}
