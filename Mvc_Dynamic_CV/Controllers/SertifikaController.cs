using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Dynamic_CV.Models.Entity;
using Mvc_Dynamic_CV.Repositories;


namespace Mvc_Dynamic_CV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;

			return View(sertifika);
        }
		[HttpPost]
		public ActionResult SertifikaGetir(TblSertifikalarım t)
		{
            
			var sertifika = repo.Find(x => x.ID == t.ID);
			sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
			return RedirectToAction("Index");
		}
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
		[HttpPost]
		public ActionResult SertifikaEkle(TblSertifikalarım p)
		{
            repo.TAdd(p);
			return RedirectToAction("Index");
		}
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);

            repo.Tdelete(sertifika);
            return RedirectToAction("Index");

        }
	}
}
