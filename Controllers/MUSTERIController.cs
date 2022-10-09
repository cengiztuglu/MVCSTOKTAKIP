using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;

namespace MVCSTOKTAKIP.Controllers
{
    
    public class MUSTERIController : Controller
    {
        // GET: MUSTERI
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }
    }
}