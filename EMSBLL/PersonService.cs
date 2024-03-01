using EMSENTITIES;
using EMSDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSBLL
{
    public class PersonService
    {
        public List<Person> GetPerson()
        {
            return new PersonRepository().GetPerson();
        }

        public Person GetPersonById(int id)
        {
            //TEMP. This can later be expanded with a full sql method to get an event by id
            return this.GetPerson().Where(x => x.PersonId == id).FirstOrDefault();
        }

        public bool CreatePersonService(Person person)
        {
            return new PersonRepository().CreatePerson(person);
        }

        public bool UpdatePersonService(Person person)
        {
            return new PersonRepository().UpdatePerson(person);
        }

        public bool DeletePersonService(int personId)
        {
            return new PersonRepository().DeletePerson(personId);
        }
    }
}
