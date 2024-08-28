using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp
{
    internal class AdoDotNetProgram
    {
        private SqlConnectionStringBuilder stringBuilder;
        private SqlConnection connection;
        private SqlCommand command;
        public AdoDotNetProgram()
        {

            stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "localhost"; // server name
            stringBuilder.InitialCatalog = "DotNetPractice"; // database name
            stringBuilder.UserID = "myserver";
            stringBuilder.Password = "password";
            connection = new SqlConnection(stringBuilder.ConnectionString);

            // alternative way of sql connection
            //SqlConnection connection = new SqlConnection("stringBuilder.DataSource = \"localhost\";stringBuilder.InitialCatalog = \"DotNetPractice\";stringBuilder.UserID = \"myserver\";stringBuilder.Password = \"password\"; ");

            connection.Open();

        }

        public void ReadData()
        {
            string query = "select * from blogs";
            command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("#### Querying Blog Database ####\n");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("id: " + dr["id"]);
                Console.WriteLine("title: " + dr["title"]);
                Console.WriteLine("author: " + dr["author"]);
                Console.WriteLine("content: " + dr["blog_content"]);
                Console.WriteLine("------------------------------------");
            }
           
        }

        public void CreateData(string title, string author, string blog_content)
        {
            string query = @"INSERT INTO [dbo].[blogs]
                   ([title]
                   ,[author]
                   ,[blog_content])
             VALUES
                   (@title,
		           @author,
		           @blog_content)";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@blog_content", blog_content);

            int result = command.ExecuteNonQuery();

            string message = result > 0 ? "Data saved successfully." : "Failed to save your data!";
            Console.WriteLine(message);
        }

        public void CloseProgram()
        {
            connection.Close();

            Console.WriteLine("Database connection closed!");
        }
    }
}
