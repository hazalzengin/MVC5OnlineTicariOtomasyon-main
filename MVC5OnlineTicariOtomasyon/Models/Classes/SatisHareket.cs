﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtomasyon.Models.Classes
{
	public class SatisHareket
	{
		[Key]
		public int Satisid { get; set; }
		public DateTime Tarih { get; set; }
		public int Adet { get; set; }
		public decimal Fiyat { get; set; }
		public decimal ToplamTutar { get; set; }

		public virtual Urun Urun { get; set; }
		public virtual Personel Personel { get; set; }
		public virtual Cari Cari { get; set; }
		public int Urunid { get; set; }
		public int Cariid { get; set; }
		public int Personelid { get; set; }
	}
}