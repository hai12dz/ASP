using ThucHanhWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ThucHanhWebMVC.Repository;
namespace ThucHanhWebMVC.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        //DI da cau hinh o file program.cs
        private readonly ILoaiSpRepository _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }

        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x=>x.Loai);
            //return View("MyCustomView", loaisp); thay doi ten view dua vao cu phap nay 
            // mac dinh asp tim trong Views/Shared/Components/ten cua view component /Default.cshtml

            return View(loaisp);
        }

    }
}
