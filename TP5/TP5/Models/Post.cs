using System;
using System.Collections.Generic;
using System.Text;

namespace TP5.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateUpdated { get; set; }

        public User UserPost {get;set;}
    }
}
