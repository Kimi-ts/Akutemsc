using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedVideo
    {
        private Video video;
        private CultureInfo lang;

        public LocalizedVideo(Video video, CultureInfo lang)
        {
            this.video = video;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return video.Id;
            }
        }

        public DateTime Date
        {
            get
            {
                return video.Date;
            }
        }

        public string Link
        {
            get
            {
                return video.Link;
            }
        }

        public string Title
        {
            get
            {
                if (lang.Name == "be")
                {
                    return video.TitleBe;
                }
                if (lang.Name == "ru")
                {
                    return video.TitleRu;
                }
                if (lang.Name == "en")
                {
                    return video.TitleEn;
                }
                return string.Empty;
            }
        }

        public string Caterogy
        {
            get
            {
                if (lang.Name == "be")
                {
                    return video.VideoCatogory.NameBe;
                }
                if (lang.Name == "ru")
                {
                    return video.VideoCatogory.NameRu;
                }
                if (lang.Name == "en")
                {
                    return video.VideoCatogory.NameEn;
                }
                return string.Empty;
            }
        }
    }
}