using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspireWebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sqlConnectionString = Properties.Settings.Default.SQLConnectionString;
            

            SqlConnection con = new SqlConnection(sqlConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT [FirstName], [LastName] FROM [dbo].[Person]", con);
            int rows= command.ExecuteNonQuery();

            SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    // iterate your results here
                    String firstName = (String)reader["FirstName"];
                    String lastName = (String)reader["LastName"];
                    FirstName.Text = firstName;
                    LastName.Text = lastName;

                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.FileUpload1.HasFile)
            {
                Console.WriteLine("Uploading file.. ");
                string FilePath = Properties.Settings.Default.FilePath; //mounts/files/
                string fileName = Path.Combine(FilePath, this.FileUpload1.FileName); //abc.jpg
                //mounts/files/abc.jpg
                
                this.FileUpload1.SaveAs(fileName);


                Label1.Text = fileName + " has been uploaded.";
            }
        }
    }
}