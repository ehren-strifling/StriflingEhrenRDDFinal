using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSENTITIES.ViewModel;

namespace EMSDAL
{
    public class RegistrationsRepository
    {

        public List<Registrations> GetRegistrations()
        {
            List<Registrations> Registrations = new List<Registrations>();
            // 1. connect to db
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {


                // 2. fire sql query
                const string commandText = "usp_GetAllRegistrations";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand); // at this point, ADO.NET will fire query using command

                DataTable dt = new DataTable();
                adapter.Fill(dt); // at this point, query is filed and the data table has been filled with data/records

                // Fill method does below 5 things :
                // 1. Open to connection
                // 2. Execute the command
                // 3. Retrieve the result
                // 4. Fill the datatable
                // 5. Close the connection

                //'3. convert ADO.NET object to Entities (Trip)
                foreach (DataRow dr in dt.Rows)
                {
                    Registrations newRegistration = new Registrations
                    {
                        EventId = Convert.ToInt32(dr["EventID"]),
                        PersonId = Convert.ToInt32(dr["PersonID"]),
                        DateRegistered = Convert.ToDateTime(dr["DateRegistered"])
                    };
                    Registrations.Add(newRegistration);
                }
            }
            return Registrations;
        }

        public List<RegistrationsViewModel> GetRegistrationsViewModel()
        {
            List<RegistrationsViewModel> Registrations = new List<RegistrationsViewModel>();
            // 1. connect to db
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {


                // 2. fire sql query
                const string commandText = "usp_GetAllRegistrationsViewModel";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand); // at this point, ADO.NET will fire query using command

                DataTable dt = new DataTable();
                adapter.Fill(dt); // at this point, query is filed and the data table has been filled with data/records

                //'3. convert ADO.NET object to Entities (Trip)
                foreach (DataRow dr in dt.Rows)
                {
                    RegistrationsViewModel newEvent = new RegistrationsViewModel
                    {
                        EventId = Convert.ToInt32(dr["EventID"]),
                        PersonId = Convert.ToInt32(dr["PersonID"]),
                        DateRegistered = Convert.ToDateTime(dr["DateRegistered"]),
                        EventName = Convert.ToString(dr["EventName"]),
                        EventDescription = Convert.ToString(dr["EventDescription"]),
                        EventStartTime = Convert.ToDateTime(dr["StartTime"]),
                        EventEndTime = Convert.ToDateTime(dr["EndTime"]),
                        PersonFirstName = Convert.ToString(dr["FirstName"]),
                        PersonLastName = Convert.ToString(dr["LastName"]),
                        PersonEmailAddress = Convert.ToString(dr["EmailAddress"]),

                    };
                    Registrations.Add(newEvent);
                }
            }
            return Registrations;
        }

        //This is getting ridiculous... I'm sure there's a way to mass produce these functions. Maybe by passing the command text parameter?, Oh wait, parameters are needed too
        public List<RegistrationsViewModel> GetRegistrationsViewModelByEventId(int eventId)
        {
            List<RegistrationsViewModel> Registrations = new List<RegistrationsViewModel>();
            // 1. connect to db
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {

                // 2. fire sql query
                const string commandText = "usp_GetAllRegistrationsViewModelByEventId";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EventID", eventId);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand); // at this point, ADO.NET will fire query using command

                DataTable dt = new DataTable();
                adapter.Fill(dt); // at this point, query is filed and the data table has been filled with data/records

                //'3. convert ADO.NET object to Entities (Trip)
                foreach (DataRow dr in dt.Rows)
                {
                    RegistrationsViewModel newEvent = new RegistrationsViewModel
                    {
                        EventId = Convert.ToInt32(dr["EventID"]),
                        PersonId = Convert.ToInt32(dr["PersonID"]),
                        DateRegistered = Convert.ToDateTime(dr["DateRegistered"]),
                        EventName = Convert.ToString(dr["EventName"]),
                        EventDescription = Convert.ToString(dr["EventDescription"]),
                        EventStartTime = Convert.ToDateTime(dr["StartTime"]),
                        EventEndTime = Convert.ToDateTime(dr["EndTime"]),
                        PersonFirstName = Convert.ToString(dr["FirstName"]),
                        PersonLastName = Convert.ToString(dr["LastName"]),
                        PersonEmailAddress = Convert.ToString(dr["EmailAddress"]),

                    };
                    Registrations.Add(newEvent);
                }
            }
            return Registrations;
        }

        public bool CreateRegistrations(Registrations Registrations)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertRegistrations", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EventID", Registrations.EventId);
                sqlCommand.Parameters.AddWithValue("@PersonID", Registrations.PersonId);
                //sqlCommand.Parameters.AddWithValue("@DateRegistered", Registrations.DateRegistered);

                conn.Open();
                i = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return i != 0;
        }

        public bool CreateRegistrationsWithPerson(EMSENTITIES.ViewModel.RegistrationsViewModel Registrations)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertRegistrationsWithPerson", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EventID", Registrations.EventId);
                sqlCommand.Parameters.AddWithValue("@PersonFirstName", Registrations.PersonFirstName);
                sqlCommand.Parameters.AddWithValue("@PersonLastName", Registrations.PersonLastName);
                sqlCommand.Parameters.AddWithValue("@PersonEmailAddress", Registrations.PersonEmailAddress);

                conn.Open();
                i = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return i != 0;
        }
        public bool UpdateRegistrations(Registrations Registrations)
        {
            throw new NotImplementedException();
        }
        
        public bool DeleteRegistrations(int eventId, int personId)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_DeleteRegistrations", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EventID", eventId);
                sqlCommand.Parameters.AddWithValue("@PersonID", personId);
               

                conn.Open();
                i = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return i != 0;
        }
    }
}
