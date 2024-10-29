using Mvc_Dynamic_CV.Models.Entity;
using Mvc_Dynamic_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Dynamic_CV.Controllers
{
    public class HakkimdaController : Controller
    {
		// GET: Hobilerim
		GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
		[HttpGet]
		public ActionResult Index()
		{
			var bilgi = repo.List();
			return View(bilgi);
		}
		[HttpPost]
		public ActionResult Index(TblHakkimda p)
		{
			var t = repo.Find(x => x.ID == 1);
			t.Ad = p.Ad;
			t.Soyad = p.Soyad;
			t.Ad = p.Ad;
			t.Adress = p.Adress;
			t.Telefon= p.Telefon;
			t.Mail = p.Mail;
			t.Aciklama = p.Aciklama;
			t.Foto = p.Foto;

			repo.TUpdate(t);
			return RedirectToAction("Index");
		}
	}
}