using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace StudentInfo.Pages
{
    public class infoModel : PageModel
    {
        public void OnGet()
        {
            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source=AMANTHA;Initial Catalog=studentinfo;Integrated Security=True";


            cnn = new SqlConnection(connectionString);
            cnn.Open();

            //Response.WriteAsync("Connection Succeeded");

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT * FROM Students";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            Output = Output + "</br>" + "Student info" + "</br>";
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "-" + dataReader.GetValue(3) + "</br>";
            }

            Output = Output + "</br>" + "Course info" + "</br>";

            cnn.Close();


            Response.WriteAsync(Output);

            //Course
            string stringConnection;
            SqlConnection npc;

            stringConnection = @"Data Source=AMANTHA;Initial Catalog=studentinfo;Integrated Security=True";


            npc = new SqlConnection(stringConnection);
            npc.Open();

            //Response.WriteAsync("Connection Succeeded");

            SqlCommand task;
            SqlDataReader Reader;
            String lqs, display = "";

            lqs = "SELECT * FROM Courses";

            task = new SqlCommand(lqs, npc);

            Reader = task.ExecuteReader();

            while (Reader.Read())
            {
                display = display + Reader.GetValue(0) + "-" + Reader.GetValue(1) + "-" + Reader.GetValue(2) + "</br>";
            }

            Response.WriteAsync(display);

            npc.Close();
        }

        public void OnPost() 
        { 

        }
    }
}
