using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDAL
{
    public class EventsRepository
    {

        public List<Events> GetEvents()
        {
            List<Events> events = new List<Events>();
            // 1. connect to db
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {


                // 2. fire sql query
                const string commandText = "usp_GetAllEvents";
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
                    Events newEvent = new Events
                    {
                        EventID = Convert.ToInt32(dr["EventID"]),
                        //OrganizerID = Convert.ToInt32(dr["OrganizerID"]),
                        EventName = Convert.ToString(dr["EventName"]),
                        EventDescription = Convert.ToString(dr["EventDescription"]),
                        StartTime = Convert.ToDateTime(dr["StartTime"]),
                        EndTime = Convert.ToDateTime(dr["EndTime"])
                    };
                    events.Add(newEvent);
                }
            }
            return events;
        }

        public bool CreateEvents(Events events)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertEvents", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue("@OrganizerID", events.OrganizerID);
                sqlCommand.Parameters.AddWithValue("@EventName", events.EventName);
                sqlCommand.Parameters.AddWithValue("@EventDescription", events.EventDescription);
                sqlCommand.Parameters.AddWithValue("@StartTime", events.StartTime);
                sqlCommand.Parameters.AddWithValue("@EndTime", events.EndTime);

                conn.Open();
                i = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return i != 0;
        }
        public bool UpdateEvents(Events events)
        {
            {
                int i;
                using (SqlConnection conn = new SqlConnection(Connection.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("usp_UpdateEvents", conn);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EventID", events.EventID);
                    //sqlCommand.Parameters.AddWithValue("@OrganizerID", events.OrganizerID);
                    sqlCommand.Parameters.AddWithValue("@EventName", events.EventName);
                    sqlCommand.Parameters.AddWithValue("@EventDescription", events.EventDescription);
                    sqlCommand.Parameters.AddWithValue("@StartTime", events.StartTime);
                    sqlCommand.Parameters.AddWithValue("@EndTime", events.EndTime);

                    conn.Open();
                    i = sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
                return i != 0;
            }
        }
        
        public bool DeleteEvents(int eventId)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_DeleteEvents", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EventID", eventId);

                conn.Open();
                i = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return i != 0;
        }
    }
}
