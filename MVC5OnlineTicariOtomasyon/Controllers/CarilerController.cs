using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtomasyon.Models.Classes;
namespace MVC5OnlineTicariOtomasyon.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Caris.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
		{
            return View();
		}
        [HttpPost]
        public ActionResult YeniCari(Cari p)
		{
            p.Durum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
		}
        public ActionResult CariSil(int id)
		{
            var dep = c.Caris.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
		{
            var cari = c.Caris.Find(id);
            return View("CariGetir", cari);
		}
        public ActionResult CariGuncelle(Cari p)
		{
			if (!ModelState.IsValid)
			{
                return View("CariGetir");
			}
            var cari = c.Caris.Find(p.CariId);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult MusteriSatis(int id)
		{
            var deger = c.SatisHarekets.Where(x => x.Cariid==id).ToList();
            var cr = c.Caris.Where(x => x.CariId == id).Select(y => y.CariAd + " " +
                 y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(deger);
		}
    }
}