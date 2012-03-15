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
    public class ActsController : Controller
    {
        private AppHarborTemplateContext context = new AppHarborTemplateContext();

        //
        // GET: /Acts/

        public ViewResult Index()
        {
            return View(context.Acts.Include(act => act.Deed).ToList());
        }

        //
        // GET: /Acts/Details/5

        public ViewResult Details(int id)
        {
            Act act = context.Acts.Single(x => x.Id == id);
            return View(act);
        }

        //
        // GET: /Acts/Create

        public ActionResult Create()
        {
            ViewBag.PossibleDeeds = context.Deeds;
            return View(new Act());
        } 

        //
        // POST: /Acts/Create

        [HttpPost]
        public ActionResult Create(Act act)
        {
            if (ModelState.IsValid)
            {
                context.Acts.Add(act);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleDeeds = context.Deeds;
            return View(act);
        }
        
        //
        // GET: /Acts/Edit/5
 
        public ActionResult Edit(int id)
        {
            Act act = context.Acts.Single(x => x.Id == id);
            ViewBag.PossibleDeeds = context.Deeds;
            return View(act);
        }

        //
        // POST: /Acts/Edit/5

        [HttpPost]
        public ActionResult Edit(Act act)
        {
            if (ModelState.IsValid)
            {
                context.Entry(act).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleDeeds = context.Deeds;
            return View(act);
        }

        //
        // GET: /Acts/Delete/5
 
        public ActionResult Delete(int id)
        {
            Act act = context.Acts.Single(x => x.Id == id);
            return View(act);
        }

        //
        // POST: /Acts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Act act = context.Acts.Single(x => x.Id == id);
            context.Acts.Remove(act);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}