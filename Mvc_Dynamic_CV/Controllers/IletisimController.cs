using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Dynamic_CV.Models.Entity;
using Mvc_Dynamic_CV.Repositories;

namespace Mvc_Dynamic_CV.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();

        public ActionResult Index()
        {
            var mesaj = repo.List();
            return View(mesaj);
        }

    }
}