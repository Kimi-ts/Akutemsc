using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedPhotoAlbum
    {
        private PhotoAlbum photoAlbum;
        private CultureInfo lang;

        public LocalizedPhotoAlbum(PhotoAlbum photoAlbum, CultureInfo lang)
        {
            this.photoAlbum = photoAlbum;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return photoAlbum.Id;
            }
        }

        public DateTime Date
        {
            get
            {
                return photoAlbum.Date;
            }
        }


        public LocalizedUser User
        {
            get
            {
                return new LocalizedUser(photoAlbum.User, lang);
            }
        }

        public string Title
        {
            get
            {
                if (lang.Name == "be")
                {
                    return photoAlbum.TitleBe;
                }
                if (lang.Name == "ru")
                {
                    return photoAlbum.TitleRu;
                }
                if (lang.Name == "en")
                {
                    return photoAlbum.TitleEn;
                }
                return string.Empty;
            }
        }

        public IEnumerable<LocalizedPicture> Pictures
        {
            get
            {
                List<LocalizedPicture> list = new List<LocalizedPicture>();
                foreach (var picture in photoAlbum.Pictures)
                {
                    list.Add(new LocalizedPicture(picture, lang));
                }

                return list;
            }
        }
    }
}