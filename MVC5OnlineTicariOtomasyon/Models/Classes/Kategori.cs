using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtomasyon.Models.Classes
{
	public class Kategori
	{
		[Key]
		public int KategoriId { get; set; }
		[Column(TypeName = "Varchar")]
		[StringLength(30)]
		public string KategoriAdi { get; set; }
		public ICollection<Urun>Uruns { get; set; }
	}
}