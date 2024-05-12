using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtomasyon.Models.Classes;

namespace MVC5OnlineTicariOtomasyon.Controllers
{
    
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay

        Context c = new Context();
        public ActionResult Index()
        {

            //var degerler = c.Uruns.Where(x => x.UrunId == 1).ToList();
            Class1 cs = new Class1();
            cs.Deger1 = c.Uruns.Where(x => x.Urunid == 4).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayId == 1).ToList();
            
            return View(cs);
        }
    }
}