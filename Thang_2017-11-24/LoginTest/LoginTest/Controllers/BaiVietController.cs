using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;  

namespace LoginTest.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: SanPham
        //Su Dung partial view
        Model1 db = new Model1();
        //Tạo 2 partial view bai viet 1 và 2 để hiển thị bv theo 2 style khác nhau
        [ChildActionOnly]
        public ActionResult BaiVietStyle1Partial()
        {
            return PartialView();
        }

        public ActionResult BaiVietStyle2Partial()
        {
            return PartialView();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}