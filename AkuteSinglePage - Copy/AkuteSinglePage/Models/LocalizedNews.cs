using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedNews
    {
        private News news;
        private CultureInfo lang;

        public LocalizedNews(News news, CultureInfo lang)
        {
            this.news = news;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return news.Id;
            }
        }

        public string Title
        {
            get
            {
                if (lang.Name == "be")
                {
                    if (news.TitleBe != string.Empty)
                    {
                        return news.TitleBe;
                    }
                }
                if (lang.Name == "ru")
                {
                    if (news.TitleRu != string.Empty)
                    {
                        return news.TitleRu;
                    }
                }
                if (lang.Name == "en")
                {
                    if (news.TitleEn != string.Empty)
                    {
                        return news.TitleEn;
                    }
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
                    if (news.TextBe != string.Empty)
                    {
                        return news.TextBe;
                    }
                }
                if (lang.Name == "ru")
                {
                    if (news.TextRu != string.Empty)
                    {
                        return news.TextRu;
                    }
                }
                if (lang.Name == "en")
                {
                    if (news.TextEn != string.Empty)
                    {
                        return news.TextEn;
                    }
                }
                return string.Empty;
            }
        }

        public DateTime Date
        {
            get
            {
                return news.Date;
            }
        }
    }
}