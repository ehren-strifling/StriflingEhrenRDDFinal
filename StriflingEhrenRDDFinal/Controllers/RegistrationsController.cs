using EMSBLL;
using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StriflingEhrenRDDFinal.Controllers
{

    //Registration controller has no edit view since we can't just let people switch what event they're registered to.
    //If a person wants to change the event they are regestered to, they must delete the existing one and register for the new event
    public class RegistrationsController : Controller
    {
        //We make use of registration view models to make the data readable since it's just ids otherwise
        public ActionResult Index()
        {
            return View(new EMSBLL.RegistrationsService().GetRegistrationsViewModel());
        }

        //This action will only show registrations that belong to a given event,
        public ActionResult EventRegistrations(int eventId)
        {
            ViewBag.eventId = eventId;
            return View(new EMSBLL.RegistrationsService().GetRegistrationsViewModelByEventId(eventId));
        }

        //eventId is optional. If eventId is passed then an event with that id will be selected by default
        public ActionResult Create(int? eventId = null)
        {
            ViewBag.EventId = eventId;
            ViewBag.Events = new EMSBLL.EventsService().GetEvents();
            return View();
        }

        [HttpPost]
        public ActionResult Create(EMSENTITIES.ViewModel.RegistrationsViewModel registrations)
        {
            if (new RegistrationsService().CreateRegistrationsWithPersonService(registrations))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Create failed";
            return View();
        }

        public ActionResult Delete(int eventId, int personId)
        {
            new RegistrationsService().DeleteRegistrationsService(eventId, personId);
            return RedirectToAction("Index");
        }
    }
}