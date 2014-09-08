using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedVideoCategory
    {
        private VideoCatogory videoCategory;
        private CultureInfo lang;

        public LocalizedVideoCategory(VideoCatogory videoCategory, CultureInfo lang)
        {
            this.videoCategory = videoCategory;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return videoCategory.Id;
            }
        }

        public string Name
        {
            get
            {
                if (lang.Name == "be")
                {
                    return videoCategory.NameBe;
                }
                if (lang.Name == "ru")
                {
                    return videoCategory.NameRu;
                }
                if (lang.Name == "en")
                {
                    return videoCategory.NameEn;
                }
                return string.Empty;
            }
        }

        public IEnumerable<LocalizedVideo> Videos
        {
            get
            {
                var videos = new List<LocalizedVideo>();
                foreach (var item in videoCategory.Videos)
                {
                    videos.Add(new LocalizedVideo(item, lang));
                }
                return videos;
            }
        }
    }
}