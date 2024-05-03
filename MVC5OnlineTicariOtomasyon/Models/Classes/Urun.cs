using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtomasyon.Models.Classes
{
	public class Urun
	{
		[Key]
		public int Urunid { get; set; }

		[Column(TypeName="Varchar")]
		[StringLength(30)]
		public string UrunAd { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(30)]
		public string Marka { get; set; }
		public int Stok { get; set; }

		public decimal Alisfiyat { get; set; }
		public decimal Satisfiyat { get; set; }
		public bool Durum { get; set; }
		public string PersonelSoyad { get; set; }
		[Column(TypeName = "Varchar")]
		[StringLength(250)]
		public string UrunGorsel { get; set; }
		public virtual Kategori Kategori { get; set; }
		public int Kategoriid { get; set; }

		public ICollection<SatisHareket> SatisHarekets { get; set; }
	}
}