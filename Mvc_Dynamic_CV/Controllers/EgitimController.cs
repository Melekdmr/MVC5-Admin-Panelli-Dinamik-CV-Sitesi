using Mvc_Dynamic_CV.Models.Entity;
using Mvc_Dynamic_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Dynamic_CV.Controllers
{
    public class EgitimController : Controller
    {
		GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();

		// GET: Egitim
		[Authorize]
		public ActionResult Index()
        {
            var egitimlerim = repo.List();
            return View(egitimlerim);
        }
		[HttpGet]
		public ActionResult EgitimEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult EgitimEkle(TblEgitimlerim p)
		{
			if (!ModelState.IsValid) //validation da ki değeri geçersiz kılan bir eylem yapılırsa,
									 //eylemi gerçekleştirmeden EğitimEkle'yi geri döndür
			{
				return View("EgitimEkle");
			}
			repo.TAdd(p);
			return RedirectToAction("Index");
		}
		public ActionResult EgitimSil(int id)
		{
			var egitim = repo.Find(x => x.ID == id);
			repo.Tdelete(egitim);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult EgitimDuzenle(int id)
		{
			var egitim = repo.Find(x => x.ID == id);
			return View(egitim);
		}
		[HttpPost]
		public ActionResult EgitimDuzenle(TblEgitimlerim p)

		{
			if (!ModelState.IsValid) //validation da ki değeri geçersiz kılan bir eylem yapılırsa,
									 //eylemi gerçekleştirmeden EğitimEkle'yi geri döndür
			{
				return View("EgitimDuzenle");
			}
			var egitim = repo.Find(x => x.ID == p.ID);
			egitim.Baslik = p.Baslik;
			egitim.AltBaslik1 = p.AltBaslik1;
			egitim.AltBaslik2 = p.AltBaslik2;
			egitim.Tarih = p.Tarih;
			egitim.GNO = p.GNO;
			repo.TUpdate(egitim);
			return RedirectToAction("Index");
		}

	}
}