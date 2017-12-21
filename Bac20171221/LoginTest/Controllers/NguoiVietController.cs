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

        public ActionResult Index(int idBV)
        {
            var BaiViet = db.BaiViets.Where(x => x.C_idBaiViet == idBV).SingleOrDefault();
            var guser = db.BaiViets.ToList();
            return View(guser);
            //return RedirectToAction("HomeNguoiViet");
        }

        //HomeNguoiViet
        public ActionResult HomeNguoiViet(string idUser)
        {
            List<object> myModel = new List<object>();
            myModel.Add(db.Users.ToList());
            myModel.Add(db.BaiViets.ToList());

            User guser = db.Users.SingleOrDefault(n => n.C_idUser == idUser);

            //if (guser.Quyen == "3")
            //var guser = db.Users.Where(x => x.Quyen == "4").SingleOrDefault();

            if (guser == null)
            {
                return Redirect("/");
            }

            if (guser.Quyen == 4 || guser.Quyen == 5)
            {
                var BaiViet = db.BaiViets.Where(x => x.C_idUserDang == idUser).ToList();
                ViewBag.contentbelong = BaiViet;
                return View(BaiViet);
            }
           
            return Redirect("/");
        }

        public ActionResult DetailBaiViet (int idBaiViet,int? idBinhLuan)
        {
            var model = from a in db.BaiViets
                        join b in db.BinhLuans
                        on a.C_idBaiViet equals b.C_idBaiViet
                        where a.C_idBaiViet == idBaiViet
                        select new BaiViet_BinhLuanViewModels()
                        {
                            C_idBaiViet = a.C_idBaiViet,
                            TieuDe = a.TieuDe,
                            AnhBia = a.AnhBia,
                            NgayDang = a.NgayDang,
                            NgayChinhSua = a.NgayChinhSua,
                            NoiDung = a.NoiDung,
                            SoLanXem = a.SoLanXem,
                            TrangThaiBaiViet = a.TrangThaiBaiViet,
                            TomTatNoiDung = a.TomTatNoiDung,
                            ThoiDiemBinhLuan = b.ThoiDiemBinhLuan,
                            NoiDungBL = b.NoiDung,
                            CapBac = b.CapBac,
                            C_idBinhLuanGoc = b.C_idBinhLuanGoc

                        };
            var detail1 = db.BaiViets.SingleOrDefault(x => x.C_idBaiViet == idBaiViet);
            Session["DetailBV"] = detail1.C_idBaiViet;
            var Detail = db.BaiViets.Where(x => x.C_idBaiViet == idBaiViet).ToList();
            
            // User guser = db.Users.SingleOrDefault(n => n.idUser == idUser);
            var lstComment1 = model.FirstOrDefault(x => x.C_idBaiViet == idBaiViet);
            //if (lstComment1 != null)
            //{
            //    var lstComment = db.BinhLuans.Where(x => x.C_idBaiViet == idBaiViet).ToList();
            //    ViewBag.ListCM1 = lstComment;
            //}

            var lstComment = db.BinhLuans.Where(x => x.C_idBaiViet == idBaiViet && x.CapBac == 1 ).ToList();
            var lstCommentr = db.BinhLuans.Where(x => x.C_idBaiViet == idBaiViet && x.CapBac == 1).ToArray();
            ViewBag.ListCM1 = lstComment;

           // var lcm= db.BinhLuans.Where(x => x.C_idBaiViet == idBaiViet && x.CapBac == 1);
           //var tolist1 = lcm.Select(x => x.C_idBinhLuan);
           // Session["CommentCap1"] = tolist1.ToString();

            // var lstCommenttest = db.BinhLuans.Where(x => x.C_idBaiViet == idBaiViet && x.CapBac == 1 && x.C_idBinhLuanGoc == x.C_idBinhLuan).Select(x => x.C_idBinhLuan).ToList();
            //var dtlist = db.BinhLuans.FirstOrDefault(x => x.C_idBaiViet == idBaiViet && x.CapBac == 1 && x.C_idBinhLuanGoc == x.C_idBinhLuan);
            //var dtlist2 = db.BinhLuans.FirstOrDefault(y => y.C_idBaiViet == idBaiViet && y.CapBac == 2);
            var tolist = from a in lstCommentr
                         where a.C_idBaiViet == idBaiViet && a.CapBac == 1
                         select a;
            
            foreach (BinhLuan c in tolist)
            {
                // c.C_idBinhLuan.ToString();
                //var error = (List<BinhLuan>)Session["CommentCap1"];
                Session["CommentCap1"] = c.C_idBinhLuan;
                //var idBinhLuan1 = Session["CommentCap1"].ToString();
                //var idBinhLuan12 = c.C_idBinhLuan.ToList();
                int idBinhLuan1 = c.C_idBinhLuan;
                var lstComment2 = db.BinhLuans.Where(y => y.C_idBaiViet == idBaiViet && y.CapBac == 2 && idBinhLuan1 == y.C_idBinhLuanGoc).ToList();
                // var BaiViet = db.BaiViets.Where(x => x.C_idBaiViet == idBV).SingleOrDefault();
                // var guser = db.BaiViets.ToList();
                //new { @idBinhLuan = Session["CommentCap1"] };
                ViewBag.ListCM2 = lstComment2;

            }
            //var binhluan = new lstComment();

            //var b1 = tolist.SingleOrDefault(x => x.C_idBinhLuan == C_idBinhLuan);
            //var b2 = db.BinhLuans.Where(x => x.C_idBaiViet == idBaiViet && x.CapBac == 1).ToString();
            //Session["CommentCap1"] = b1.C_idBinhLuan.ToString();     
            //var tolist1 = tolist.DefaultIfEmpty().ToString();
            //var lstComment2 = db.BinhLuans.SingleOrDefault(y => y.C_idBaiViet == idBaiViet && y.CapBac == 2 && tolist1 == y.C_idBinhLuanGoc);

            //ViewBag.ListCM2 = lstComment2;


            return View(Detail);
        }
   
        [HttpGet]
        public ActionResult ThemBinhLuan()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ThemBinhLuan(BinhLuan BL, int? idBaiViet)
        {
            
            db.Entry(BL).State = System.Data.Entity.EntityState.Modified;
            BL.C_idBaiViet = (int)Session["DetailBV"];
            BL.C_idUserDoc = Session["QuyenID"].ToString();
            BL.ThoiDiemBinhLuan = DateTime.Now;
            BL.CapBac = 1;
            BL.C_idBinhLuanGoc = BL.C_idBinhLuan;
            //Session["CommentCap1"] = BL.C_idBinhLuan.ToString();
            db.BinhLuans.Add(BL);
            db.SaveChanges();
            return RedirectToAction("DetailBaiViet", "NguoiViet", new { @C_idBaiViet = Session["DetailBV"] });
        }


    }
}