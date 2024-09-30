using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ThucHanhWebMVC.Models;
using ThucHanhWebMVC.ViewModels;
using X.PagedList;

namespace ThucHanhWebMVC.Controllers
{
    public class HomeController : Controller
    {
        MasterContext db = new MasterContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //method Index trong controller home se goi den view tuong ung
        public IActionResult Index(int? page)
        {
            //lay danh sach san pham theo list  co phan trang

            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            //lay danh sach san pham theo list khong co phan trang
            // var lstsanpham = db.TDanhMucSps.ToList();
            //  return View(lstsanpham);
            return View(lst);

        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult SanPhamTheoLoai(String maloai, int? page)
        {
            //lay danh sach loai san pham dua vao maloai truyen tu url vao` hoac tu ben Default.cshtml
            //List<TDanhMucSp> lstsanpham = db.TDanhMucSps.Where(x=>x.MaLoai==maloai).OrderBy(x=>x.TenSp).ToList();
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maloai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }

        //cach 1 su dung view bag 
        public IActionResult ChiTietSanPham(string maSp)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }



        public IActionResult ProductDetail(string maSp)
        {


            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();

            var homeProductDetailViewModel = new HomeProductDetailViewModel
            {
                danhMucSp = sanPham,
                anhSps = anhSanPham
            }; 


            return View(homeProductDetailViewModel);

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
/*
cach dung viewbag, viewdata, tempdata
public IActionResult Index()
{
    ViewBag.Message = "Hello from ViewBag!";
    return View();
}
< h1 > @ViewBag.Message</h1>*/

/*public IActionResult Index()
{
    ViewData["Message"] = "Hello from ViewData!";
    return View();
}
< h1 > @ViewData["Message"] </ h1 >*/

/*
 
 public class HomeController : Controller
{
    public IActionResult RedirectToAnotherAction()
    {
        TempData["Message"] = "Hello from TempData!";
        return RedirectToAction("AnotherAction");
    }

    public IActionResult AnotherAction()
    {
        return View();
    }
}
//file view anotheraction 
@{
    ViewData["Title"] = "Another Action Page";
}

<h1>@TempData["Message"]</h1>


 */
