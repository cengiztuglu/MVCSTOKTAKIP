using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MVCSTOKTAKIP.Controllers
{
    public class URUNController : Controller
    {
        // GET: URUN
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLURUNLER.ToList().ToPagedList(sayfa, 3);
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
        public ActionResult UrünGetir(int id)
        {
            var ktgr = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()//tablo içinden kategorilerin listesini i değişkenine ata
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString() //i nin kategori id ata
                                             }).ToList();
            ViewBag.dgr = degerler;  //diğer sayfaya taşıma işlemi yeni bir değer türettik


            return View("UrünGetir", ktgr);


        }

        public ActionResult Güncelle(TBLURUNLER p1)
        {
            var urun = db.TBLURUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();// FirstorDefaul(liste içerisinde seçmiş olduğumuz ilk değeri getirir)
            urun.URUNKATEGORI=ktg.KATEGORIID;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}