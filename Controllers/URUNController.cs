﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;


namespace MVCSTOKTAKIP.Controllers
{
    public class URUNController : Controller
    {
        // GET: URUN
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()//tablo içinden kategorilerin listesini i değişkenine ata
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD, 
                                                 Value = i.KATEGORIID.ToString() //i nin kategori id ata
                                             }).ToList();
            ViewBag.dgr = degerler;  //diğer sayfaya taşıma işlemi yeni bir değer türettik
                                             
                                                    
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();// FirstorDefaul(liste içerisinde seçmiş olduğumuz ilk değeri getirir)
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");//işlem yaptıktan sonra index sayfasına tekrar atar
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}