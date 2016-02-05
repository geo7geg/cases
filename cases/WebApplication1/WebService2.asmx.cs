using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
        const string connectionString = @"server=localhost;user id=root;Password=;database=contacts;persist security info=False;charset=utf8";

        public class Person
        {
            public int id { get; set; }
            public string name { get; set; }
            public int phone { get; set; }
        }

        [WebMethod]
        public DataTable findperson(string text)
        {
            Person person = new Person();

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            MySqlCommand command4 = new MySqlCommand("SELECT ID,FirstName,LastName,Company FROM contacts where FirstName LIKE '%" + text + "%' OR  FirstName LIKE '%" + text + "%' OR LastName LIKE '%" + text + "%' OR  LastName LIKE '%" + text + "%' OR Company LIKE '%" + text + "%' OR  Company LIKE '%" + text + "%' OR MobilePhone LIKE '%" + text + "%' OR EmailAddress LIKE '%" + text + "%' OR  EmailAddress LIKE '%" + text + "%' OR BusinessPhone LIKE '%" + text + "%'", connection);

            DataTable dataTable4 = new DataTable();
            MySqlDataAdapter da4 = new MySqlDataAdapter(command4);

            da4.Fill(dataTable4);
            dataTable4.TableName = "Contacts";
            //GridView3.DataSource = dataTable4;
            //GridView3.DataBind();
            //MySqlCommand command = connection.CreateCommand();
            //MySqlDataReader reader;

            //command.CommandText = "SELECT * FROM information where id=" + text;
            //command.Prepare();
            ////command.Parameters.AddWithValue("@p1", item);
            //reader = command.ExecuteReader();
            //reader.Read();
            //person.id = Convert.ToInt32(reader["id"]);
            //person.name = reader["name"].ToString();
            //person.phone = Convert.ToInt32(reader["phone"]);

            //reader.Close();
            connection.Close();

            return dataTable4;
        }
    }
}
