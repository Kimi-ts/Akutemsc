using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedBlog
    {
        private Blog blog;
        private CultureInfo lang;

        public LocalizedBlog(Blog blog, CultureInfo lang)
        {
            this.blog = blog;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return blog.ID;
            }
        }

        public DateTime Date
        {
            get
            {
                return blog.Date;
            }
        }

        public string Title
        {
            get
            {
                return blog.Title;
            }
        }

        public string Text
        {
            get
            {
                return blog.Text;
            }
        }

        public string Tags
        {
            get
            {
                return blog.Tags;
            }
        }

        public LocalizedUser Author
        {
            get
            {
                return new LocalizedUser(blog.User, lang);
            }
        }
    }
}