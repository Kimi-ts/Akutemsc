using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedPicture
    {
        private Picture picture;
        private CultureInfo lang;

        public LocalizedPicture(Picture picture, CultureInfo lang)
        {
            this.picture = picture;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return picture.Id;
            }
        }

        public int PhotoAlbumId
        {
            get
            {
                return picture.PhotoAlbumId;
            }
        }

        public string Filename
        {
            get
            {
                return picture.Filename;
            }
        }

        public string Description
        {
            get
            {
                if (lang.Name == "be")
                {
                    return picture.DescriptionBe;
                }
                if (lang.Name == "ru")
                {
                    return picture.DescriptionRu;
                }
                if (lang.Name == "en")
                {
                    return picture.DescriptionEn;
                }
                return string.Empty;
            }
        }

        public LocalizedPhotoAlbum PhotoAlbum
        {
            get
            {
                return new LocalizedPhotoAlbum(picture.PhotoAlbum, lang);
            }
        }
    }
}