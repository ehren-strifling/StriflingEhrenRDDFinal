using EMSENTITIES;
using EMSBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StriflingEhrenRDDFinal.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            return View(new EMSBLL.EventsService().GetEvents());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Events events)
        {
            if (new EventsService().CreateEventsService(events))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Create failed";
            return View();
        }

        public ActionResult Edit(int eventId)
        {
            return View(new EMSBLL.EventsService().GetEventsById(eventId));
        }

        [HttpPost]
        public ActionResult Edit(Events events)
        {
            if (new EventsService().UpdateEventsService(events))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Edit failed";
            return View();
        }

        public ActionResult Delete(int eventId)
        {
            new EventsService().DeleteEventsService(eventId);
            return RedirectToAction("Index");
        }
    }
}