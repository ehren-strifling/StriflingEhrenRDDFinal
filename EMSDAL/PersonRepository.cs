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
    public class PersonRepository
    {

        public List<Person> GetPerson()
        {
            List<Person> Person = new List<Person>();
            // 1. connect to db
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {


                // 2. fire sql query
                const string commandText = "usp_GetAllPerson";
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
                    Person newPerson = new Person
                    {
                        PersonId = Convert.ToInt32(dr["PersonID"]),
                        //OrganizerID = Convert.ToInt32(dr["OrganizerID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"])
                    };
                    Person.Add(newPerson);
                }
            }
            return Person;
        }

        public bool CreatePerson(Person Person)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertPerson", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue("@OrganizerID", Person.OrganizerID);
                sqlCommand.Parameters.AddWithValue("@FirstName", Person.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", Person.LastName);
                sqlCommand.Parameters.AddWithValue("@EmailAddress", Person.EmailAddress);

                conn.Open();
                i = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return i != 0;
        }
        public bool UpdatePerson(Person Person)
        {
            {
                int i;
                using (SqlConnection conn = new SqlConnection(Connection.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("usp_UpdatePerson", conn);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@PersonID", Person.PersonId);
                    //sqlCommand.Parameters.AddWithValue("@OrganizerID", Person.OrganizerID);
                    sqlCommand.Parameters.AddWithValue("@FirstName", Person.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", Person.LastName);
                    sqlCommand.Parameters.AddWithValue("@EmailAddress", Person.EmailAddress);

                    conn.Open();
                    i = sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
                return i != 0;
            }
        }
        
        public bool DeletePerson(int personId)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_DeletePerson", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PersonID", personId);

                conn.Open();
                i = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return i != 0;
        }
    }
}
