using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Dynamic_CV.Models.Entity;
using Mvc_Dynamic_CV.Repositories;

namespace Mvc_Dynamic_CV.Controllers
{
   
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
		[HttpGet]
		public ActionResult AdminEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AdminEkle(TblAdmin p)
		{
			repo.TAdd(p);
			return RedirectToAction("Index");//Ekleme işlemini yaptıktan sonra Indexe yönlendir.
		}
		public ActionResult AdminSil(int id)
		{
			TblAdmin t = repo.Find(x => x.ID == id); //Dışarıdan gönderdiğimiz id ye eşit olan kaydın bilgisini aldık
			repo.Tdelete(t);
			return RedirectToAction("Index");// İşlemden sonra Index sayfasına yönlendirir
		}
		[HttpGet]
		public ActionResult AdminDuzenle(int id)
		{
			TblAdmin t = repo.Find(x => x.ID == id);
			return View(t);

		}
		[HttpPost]
		public ActionResult AdminDuzenle(TblAdmin p)
		{
			TblAdmin t = repo.Find(x => x.ID == p.ID);
			t.KullaniciAdi = p.KullaniciAdi;
			t.Sifre = p.Sifre;
		
			repo.TUpdate(t);
			return RedirectToAction("Index");

		}
	}
}