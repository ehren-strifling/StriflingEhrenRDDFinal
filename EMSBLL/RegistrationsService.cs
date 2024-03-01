using EMSENTITIES;
using EMSDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSBLL
{
    public class RegistrationsService
    {
        public List<Registrations> GetRegistrations()
        {
            return new RegistrationsRepository().GetRegistrations();
        }

        //Returns a registration object that has details about the registree and event
        public List<EMSENTITIES.ViewModel.RegistrationsViewModel> GetRegistrationsViewModel()
        {
            return new RegistrationsRepository().GetRegistrationsViewModel();
        }

        public List<EMSENTITIES.ViewModel.RegistrationsViewModel> GetRegistrationsViewModelByEventId(int eventId)
        {
            return new RegistrationsRepository().GetRegistrationsViewModelByEventId(eventId);
        }

        public bool CreateRegistrationsService(Registrations registrations)
        {
            return new RegistrationsRepository().CreateRegistrations(registrations);
        }
        public bool CreateRegistrationsWithPersonService(EMSENTITIES.ViewModel.RegistrationsViewModel registrations)
        {
            return new RegistrationsRepository().CreateRegistrationsWithPerson(registrations);
        }

        public bool UpdateRegistrationsService(Registrations registrations)
        {
            return new RegistrationsRepository().UpdateRegistrations(registrations);
        }

        public bool DeleteRegistrationsService(int eventId, int personId)
        {
            return new RegistrationsRepository().DeleteRegistrations(eventId, personId);
        }
    }
}
