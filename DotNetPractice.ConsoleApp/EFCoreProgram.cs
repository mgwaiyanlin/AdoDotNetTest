using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp
{
    internal class EFCoreProgram
    {
        AppDbContext appDbContext = new AppDbContext();
        public void Run()
        {
            Read();
        }

        private void Read()
        {
            appDbContext.Blogs.ToList().ForEach(blog =>
            {
                Console.WriteLine("id: " + blog.id);
                Console.WriteLine("title: " + blog.title);
                Console.WriteLine("author: " + blog.author);
                Console.WriteLine("content: " + blog.blog_content);
                Console.WriteLine("---------------------------------------------");
            });
        }

        private void Create(string title, string author, string blog_content)
        {
            var blog = new BlogDto
            {
                title = title,
                author = author,
                blog_content = blog_content
            };

            appDbContext.Blogs.Add(blog);
            
            int result = appDbContext.SaveChanges();

            string message = result > 0 ? "Successfully created...." : "Failed to create your data....";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string blog_content)
        {
            var blog = appDbContext.Blogs.FirstOrDefault(blog => blog.id == id);

            if (blog == null)
            {
                Console.WriteLine("Empty blog!");
                return;
            }

            blog.title = title;
            blog.author = author;
            blog.blog_content = blog_content;

            int result = appDbContext.SaveChanges();

            string message = result > 0 ? "Successfully updated....." : "Failed to update......";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var blog = appDbContext.Blogs.FirstOrDefault(blog =>blog.id == id);
            if(blog == null)
            {
                Console.WriteLine("Empty blog!");
                return;
            }
            appDbContext.Blogs.Remove(blog);
            int result = appDbContext.SaveChanges();
            string message = result > 0 ? "Successfully deleted....." : "Failed to delete......";
            Console.WriteLine(message);
        }
    }
}
