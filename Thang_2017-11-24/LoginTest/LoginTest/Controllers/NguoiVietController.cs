using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;

namespace LoginTest.Controllers
{
    public class NguoiVietController : Controller
    {
        // GET: NguoiViet
        Model1 db = new Model1();

        public object CommonConstants { get; private set; }

        public ActionResult Index(string idBV)
        {
            var BaiViet = db.BaiViets.Where(x => x.C_idBaiViet == idBV).SingleOrDefault();
            var guser = db.BaiViets.ToList();
            return View(guser);
            //return RedirectToAction("HomeNguoiViet");
        }

        public ActionResult HomeNguoiViet(string idUser, string idBV)
        {
            
            User guser = db.Users.SingleOrDefault(n => n.idUser == idUser);
            //if (guser.Quyen == "3")
            //var guser = db.Users.Where(x => x.Quyen == "4").SingleOrDefault();
            if (guser.Quyen == "4")
            {
                var BaiViet = db.BaiViets.Where(x => x.C_idUserDang == idUser).ToList();
                return View(BaiViet);
            }
            //var guser = db.Users.ToList();
            // return View();
            return Redirect("/");
        }

        public ActionResult DetailBaiViet (string idBaiViet)
        {
            var Detail = db.BaiViets.Where(x => x.C_idBaiViet == idBaiViet).ToList();
            return View(Detail);
        }
    }
}