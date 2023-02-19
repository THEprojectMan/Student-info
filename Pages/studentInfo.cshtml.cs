using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace StudentInfo.Pages
{
    public class studentInfoModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
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

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "-" + dataReader.GetValue(3) + "</br>";
            }


            cnn.Close();
        }
    }
}
