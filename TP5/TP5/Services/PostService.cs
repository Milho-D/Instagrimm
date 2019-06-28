using System;
using System.Collections.Generic;
using System.Text;
using TP5.Models;

namespace TP5.Services
{
    public class PostService
    {
        private PostService() { }

        private PostService _Instance;
        public PostService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PostService();
                }

                return _Instance;
            }
        }

        private Post _CurrentPost;

        public Post GetCurrentPost()
        {
            return _CurrentPost;
        }
    }
}
