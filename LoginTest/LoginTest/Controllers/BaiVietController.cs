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
            var congnghe = from a in db.BaiViets
                            where a.C_idTheLoai == 1
                            select a;
            ViewBag.FriendRequest = congnghe;

            return PartialView();
        }

        public ActionResult BaiVietStyle2Partial()
        {
            return PartialView();
        }

        public ActionResult BaiVietStyle3Partial()
        {
            return PartialView();
        }
        public ActionResult CommentStyle1Partial()
        {
            return PartialView();
        }
        public ActionResult CommentStyle2Partial()
        {
            return PartialView();
        }
        //public ActionResult AddCommentPartial()
        //{
           
        //    return PartialView();
        //}


        public ActionResult Index()
        {
            return View();
        }

        
    }
}