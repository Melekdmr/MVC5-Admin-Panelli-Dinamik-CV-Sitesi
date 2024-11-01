﻿using Mvc_Dynamic_CV.Models.Entity;
using Mvc_Dynamic_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Mvc_Dynamic_CV.Controllers
{
    public class HobilerimController : Controller
    {
        // GET: Hobilerim
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
		public ActionResult Index(TblHobilerim p)
		{
			var t = repo.Find(x => x.ID == 1);
          t.Aciklama1 = p.Aciklama1;
           t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);
			return RedirectToAction("Index");
		}
	}
}