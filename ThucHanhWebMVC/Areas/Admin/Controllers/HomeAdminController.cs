using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThucHanhWebMVC.Models;
using X.PagedList;

namespace ThucHanhWebMVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]

    public class HomeAdminController : Controller
    {
        MasterContext db = new MasterContext();
        [Route("")]
        [Route("index")]

        public IActionResult Index()
        {
            return View();
        }

        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {//list khong phan trang
         //var lstSanPham = db.TDanhMucSps.ToList();
         //return View(lstSanPham);


            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);


            return View(lst);
         
        }





    }
}
