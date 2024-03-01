using EMSENTITIES;
using EMSBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StriflingEhrenRDDFinal.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            return View(new PersonService().GetPerson());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (new PersonService().CreatePersonService(person))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Create failed";
            return View();
        }

        public ActionResult Edit(int personId)
        {
            return View(new PersonService().GetPersonById(personId));
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (new PersonService().UpdatePersonService(person))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Edit failed";
            return View();
        }

        public ActionResult Delete(int personId)
        {
            new PersonService().DeletePersonService(personId);
            return RedirectToAction("Index");
        }
    }
}