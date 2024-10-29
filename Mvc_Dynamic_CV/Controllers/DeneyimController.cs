using Mvc_Dynamic_CV.Models.Entity;
using Mvc_Dynamic_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Dynamic_CV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();  // GenericRepository sınfıına ait olan tüm metotları kullanabiliyoruz.
                                                           // Çünkü DeneyimRepository GenericRepository'den kalıtım aldı
        public ActionResult Index()
        {

            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");//Ekleme işlemini yaptıktan sonra Indexe yönlendir.
        }
        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id); //Dışarıdan gönderdiğimiz id ye eşit olan kaydın bilgisini aldık
            repo.Tdelete(t);
            return RedirectToAction("Index");// İşlemden sonra Index sayfasına yönlendirir
		}
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
			TblDeneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);

		}
        [HttpPost]
		public ActionResult DeneyimGetir(TblDeneyimlerim p)
		{
			TblDeneyimlerim t = repo.Find(x => x.ID ==p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
			return RedirectToAction("Index");

		}
	}
}