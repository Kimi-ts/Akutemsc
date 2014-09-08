using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedUser
    {
        private User user;
        private CultureInfo lang;

        public LocalizedUser(User user, CultureInfo lang)
        {
            this.user = user;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return user.Id;
            }
        }

        public string Name
        {
            get
            {
                if (lang.Name == "be")
                {
                    return user.NameBe;
                }
                if (lang.Name == "ru")
                {
                    return user.NameRu;
                }
                if (lang.Name == "en")
                {
                    return user.NameEn;
                }
                return string.Empty;
            }
        }

        public string Surname
        {
            get
            {
                if (lang.Name == "be")
                {
                    return user.SurnameBe;
                }
                if (lang.Name == "ru")
                {
                    return user.SurnameRu;
                }
                if (lang.Name == "en")
                {
                    return user.SurnameEn;
                }
                return string.Empty;
            }
        }

        public string Twitter
        {
            get
            {
                return user.Twitter;
            }
        }

        public string Facebook
        {
            get
            {
                return user.Facebook;
            }
        }

        public string Vkontakte
        {
            get
            {
                return user.Vkontakte;
            }
        }

        public string Instagram
        {
            get
            {
                return user.Instagram;
            }
        }

        public string LogoFilename
        {
            get
            {
                return user.LogoFilename;
            }
        }

        public IEnumerable<LocalizedBlog> Blogs
        {
            get
            {
                var blogs = new List<LocalizedBlog>();
                foreach (var item in user.Blogs)
                {
                    blogs.Add(new LocalizedBlog(item, lang));
                }

                return blogs;
            }
        }

    }
}