using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppHarborTemplate.Models;

namespace AppHarborTemplate.Controllers
{   
    public class DeedsController : Controller
    {
        private AppHarborTemplateContext context = new AppHarborTemplateContext();

        //
        // GET: /Deeds/

        public ViewResult Index()
        {
            return View(context.Deeds.Include(deed => deed.Person).Include(deed => deed.Acts).ToList());
        }

        //
        // GET: /Deeds/Details/5

        public ViewResult Details(int id)
        {
            Deed deed = context.Deeds.Single(x => x.Id == id);
            return View(deed);
        }

        //
        // GET: /Deeds/Create

        public ActionResult Create()
        {
            ViewBag.PossiblePeople = context.People;
            return View();
        } 

        //
        // POST: /Deeds/Create

        [HttpPost]
        public ActionResult Create(Deed deed)
        {
            if (ModelState.IsValid)
            {
                context.Deeds.Add(deed);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossiblePeople = context.People;
            return View(deed);
        }
        
        //
        // GET: /Deeds/Edit/5
 
        public ActionResult Edit(int id)
        {
            Deed deed = context.Deeds.Single(x => x.Id == id);
            ViewBag.PossiblePeople = context.People;
            return View(deed);
        }

        //
        // POST: /Deeds/Edit/5

        [HttpPost]
        public ActionResult Edit(Deed deed)
        {
            if (ModelState.IsValid)
            {
                context.Entry(deed).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossiblePeople = context.People;
            return View(deed);
        }

        //
        // GET: /Deeds/Delete/5
 
        public ActionResult Delete(int id)
        {
            Deed deed = context.Deeds.Single(x => x.Id == id);
            return View(deed);
        }

        //
        // POST: /Deeds/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Deed deed = context.Deeds.Single(x => x.Id == id);
            context.Deeds.Remove(deed);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}