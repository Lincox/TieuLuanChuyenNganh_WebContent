using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaveContent.Models;
using System.IO;
using System.Data.Entity.Validation;

namespace SaveContent.Controllers
{
    public class BaiVietsController : Controller
    {
        private WebChiaSeNoiDungEntities1 db = new WebChiaSeNoiDungEntities1();

        // GET: BaiViets
        public ActionResult Index()
        {
            var baiViets = db.BaiViets.Include(b => b.TheLoai).Include(b => b.User);
            return View(baiViets.ToList());
        }

        // GET: BaiViets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: BaiViets/Create
        public ActionResult Create()
        {
            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1");
            ViewBag.C_idUserDang = new SelectList(db.Users, "C_idUser", "HoTen");
            return View();
        }
        // POST: BaiViets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "C_idBaiViet,C_idTheLoai,C_idUserDang,TieuDe,TomTatNoiDung,AnhBia,NgayDang,NgayChinhSua,NoiDung,SoLanXem,TrangThaiBaiViet")]
        BaiViet baiViet, HttpPostedFileBase NoiDung, HttpPostedFileBase aAnhBia)
        {
            if (ModelState.IsValid)
            {
                if (aAnhBia != null)
                {
                    baiViet.AnhBia = new byte[aAnhBia.ContentLength];
                    aAnhBia.InputStream.Read(baiViet.AnhBia, 0, aAnhBia.ContentLength);
                }
                baiViet.NgayDang = DateTime.Now;
                baiViet.NgayChinhSua = DateTime.Now;
                db.BaiViets.Add(baiViet);
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                return RedirectToAction("Index");
            }
            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1", baiViet.C_idTheLoai);
            ViewBag.C_idUserDang = new SelectList(db.Users, "C_idUser", "HoTen", baiViet.C_idUserDang);
            return View(baiViet);
        }

        // GET: BaiViets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1", baiViet.C_idTheLoai);
            ViewBag.C_idUserDang = new SelectList(db.Users, "C_idUser", "HoTen", baiViet.C_idUserDang);
            return View(baiViet);
        }

        // POST: BaiViets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "C_idBaiViet,C_idTheLoai,C_idUserDang,TieuDe,TomTatNoiDung,AnhBia,NgayDang,NgayChinhSua,NoiDung,SoLanXem,TrangThaiBaiViet")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                baiViet.NgayChinhSua = DateTime.Now;
                db.Entry(baiViet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1", baiViet.C_idTheLoai);
            ViewBag.C_idUserDang = new SelectList(db.Users, "C_idUser", "HoTen", baiViet.C_idUserDang);
            return View(baiViet);
        }

        // GET: BaiViets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // POST: BaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BaiViet baiViet = db.BaiViets.Find(id);
            db.BaiViets.Remove(baiViet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
