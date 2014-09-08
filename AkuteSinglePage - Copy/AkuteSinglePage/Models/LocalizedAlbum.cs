using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedAlbum
    {
        private Album album;
        private CultureInfo lang;

        public LocalizedAlbum(Album album, CultureInfo lang)
        {
            this.lang = lang;
            this.album = album;
        }

        public int Id
        {
            get
            {
                return album.Id;
            }
        }

        public int Year
        {
            get
            {
                return album.Year;
            }
        }

        public string Label
        {
            get
            {
                return album.Label;
            }
        }

        public string LogoFilename
        {
            get
            {
                return album.LogoFilename;
            }
        }

        public string Name
        {
            get
            {
                if (lang.Name == "be")
                {
                    return album.NameBe;
                }
                if (lang.Name == "ru")
                {
                    return album.NameRu;
                }
                if (lang.Name == "en")
                {
                    return album.NameEn;
                }

                return string.Empty;
            }
        }

        public string Description
        {
            get
            {
                if (lang.Name == "be")
                {
                    return album.DescriptionBe;
                }
                if (lang.Name == "ru")
                {
                    return album.DescriptionRu;
                }
                if (lang.Name == "en")
                {
                    return album.DescriptionEn;
                }

                return string.Empty;
            }
        }

        public IEnumerable<LocalizedSong> Songs
        {
            get
            {
                var list = new List<LocalizedSong>();

                foreach (var item in album.Songs)
                {
                    list.Add(new LocalizedSong(item, lang));
                }
                return list;
            }
        }
    }
}