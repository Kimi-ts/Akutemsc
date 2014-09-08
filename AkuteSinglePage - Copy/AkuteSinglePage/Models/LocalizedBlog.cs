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
                if (lang.Name == "be")
                {
                    return blog.Title;
                }
                if (lang.Name == "en")
                {
                    return blog.Title;
                }
                if (lang.Name == "ru")
                {
                    return blog.Title;
                }
                return string.Empty;
            }
        }

        public string Text
        {
            get
            {
                if (lang.Name == "be")
                {
                    return blog.Text;
                }
                if (lang.Name == "en")
                {
                    return blog.Text;
                }
                if (lang.Name == "ru")
                {
                    return blog.Text;
                }
                return string.Empty;
            }
        }

        public string Tags
        {
            get
            {
                if (lang.Name == "be")
                {
                    return blog.Tags;
                }
                if (lang.Name == "en")
                {
                    return blog.Tags;
                }
                if (lang.Name == "ru")
                {
                    return blog.Tags;
                }
                return string.Empty;
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