using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp
{
    public class DapperProgram
    {
        public void Run()
        {
            Console.WriteLine("DapperProgram is running...");
            //Console.WriteLine("Console app");
            //Read();

            //Create("Myanmar Pyi", "Myanmar Pyi Tarzan", "There are many poor Myanmar people including me.");
            //Update(3, "Updated Title", "Updated Author", "Updated Description");
            Delete(5);
            Read();

        }

        private void Read()
        {
            using IDbConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> blogs = connection.Query<BlogDto>("select * from blogs").ToList(); // using Dapper
            
            foreach (BlogDto blog in blogs)
            {
                Console.WriteLine("id: " + blog.id);
                Console.WriteLine("title: " + blog.title);
                Console.WriteLine("author: " + blog.author);
                Console.WriteLine("content: " + blog.blog_content);
                Console.WriteLine("---------------------------------------------");
            }
        }

        private void Create(string title, string author, string blog_content)
        {
            BlogDto blog = new BlogDto()
            {
                title = title,
                author = author,
                blog_content = blog_content
            };

            string query = @"INSERT INTO [dbo].[blogs]
                   ([title]
                   ,[author]
                   ,[blog_content])
             VALUES
                   (@title,
		           @author,
		           @blog_content)";

            using IDbConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            int result = connection.Execute(query, blog);

            string message = result > 0 ? "New blog created successfully." : "Failed to create a new blog";
            Console.WriteLine(message);

        }

        private void Update(int id, string title, string author, string blog_title)
        {
            BlogDto blog = new BlogDto()
            {
                id = id,
                title = title,
                author = author,
                blog_content = blog_title
            };

            string query = @"UPDATE [dbo].[blogs]
                   SET [title] = @title
                      ,[author] = @author
                      ,[blog_content] = @blog_content
                 WHERE id = @id";

            using IDbConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            int result = connection.Execute(query, blog);

            string message = result > 0 ? "Updated successfully." : "Failed to update";
            Console.WriteLine(message);

        }

        private void Delete(int id)
        {
            BlogDto blog = new BlogDto()
            {
                id = id
            };
            string query = @"DELETE FROM [dbo].[blogs] WHERE id = @id";

            using IDbConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            int result = connection.Execute(query, blog);

            string message = result > 0 ? "deleted successfully" : "failed to delete";
            Console.WriteLine(message);
        }
    }
}
