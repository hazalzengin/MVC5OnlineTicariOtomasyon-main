using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtomasyon.Models.Classes;

namespace MVC5OnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik

        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Where(x => x.Durum == true).Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Uruns.Where(x => x.Durum == true).Sum(y => y.Stok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Uruns.Where(x => x.Durum == true) orderby x.Satisfiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            //var dg = c.Uruns.Where(x => x.Durum == true).Min(y => y.Satisfiyat).ToString();
            //ViewBag.d9 = dg;

            var deger9 = (from x in c.Uruns.Where(x=>x.Durum==true) orderby x.Satisfiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = (from x in c.Uruns.Where(x => x.Durum == true) select x.UrunAd == "Buzdolabi").Count().ToString();
            ViewBag.d10 = deger10;

            var deger12 = (from x in c.Uruns.Where(x => x.Durum == true) orderby x.Satisfiyat ascending select x.Marka).FirstOrDefault();
            ViewBag.d12 = deger12;
            return View();
        }
    }
}