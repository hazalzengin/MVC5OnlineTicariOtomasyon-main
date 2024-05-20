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

            var deger10 = c.Uruns
                                .Where(x => x.Durum == true && x.UrunAd == "Buzdolabı")
                                .Sum(x => x.Stok);

            ViewBag.d10 = deger10.ToString();


            var deger11= c.Uruns
                                .Where(x => x.Durum == true && x.UrunAd == "Pc")
                                .Sum(x => x.Stok);
            ViewBag.d11 = deger11;

            var deger12 = (from x in c.Uruns.Where(x => x.Durum == true) orderby x.Satisfiyat ascending select x.Marka).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger14 = c.SatisHarekets
      .Where(x => x.ToplamTutar != null)
      .Sum(x => x.ToplamTutar)
      .ToString();
            ViewBag.d14 = deger14;
            DateTime today = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == today).ToString();

            if (deger15 == "0")
            {
                ViewBag.d15 = "Bugün hiç satış yapılmadı.";
            }
            else
            {
                ViewBag.d15 = deger15;
            }


            var deger16 = c.SatisHarekets.Where(x => x.Tarih == today).Sum(x => (decimal?)x.ToplamTutar) ?? 0;
            ViewBag.d16 = deger16.ToString();
            ViewBag.d16 = deger16;

            if (deger16 == 0)
            {
                ViewBag.d16 = "Bugün hiç satış yapılmadı.";
            }
            else
            {
                ViewBag.d16 = deger16;
            }

            var deger13 = c.Uruns.Where(u=>u.Urunid==(c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            return View(); 
        }

        public ActionResult KolayTablo()
        {
            var sorgu = from x in c.Caris
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            sehir = g.Key,
                            sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }


        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departmanid into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu3 = c.Caris.ToList();
            return PartialView(sorgu3);

        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(sorgu);
        }
    }
}