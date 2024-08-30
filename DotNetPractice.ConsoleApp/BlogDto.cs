using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetPractice.ConsoleApp
{
    // This BlogDto is the same with the 'blogs' database.
    [Table("blogs")]
    public class BlogDto
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string blog_content { get; set; }
    }
}
