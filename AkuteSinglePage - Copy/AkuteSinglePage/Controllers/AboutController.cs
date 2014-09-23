using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using AkuteSinglePage.Models;

namespace AkuteSinglePage.Controllers
{
    public class AboutController : BaseController
    {
        private AkuteDBEntities context;

        public AboutController(AkuteDBEntities context)
        {
            this.context = context;
        }

        public ActionResult Details()
        {
            var lang = Thread.CurrentThread.CurrentCulture;

            //General Blog Gallery Photo album is album without User in DB
            var picturesfromdb = context.PhotoAlbums.Where(c => c.User == null).First().Pictures.ToList();

            var model = new AboutModel();
            model.Pictures = new List<LocalizedPicture>();
            foreach (var pic in picturesfromdb)
            {
                model.Pictures.Add(new LocalizedPicture(pic, lang));
            }
            return View(model);
        }

        public ActionResult GetAlbumPicture(int photoAlbumId, string filename)
        {
            var filePath = string.Format("~/Data/Pictures/{0}/{1}", photoAlbumId, filename);
            var file = Server.MapPath(filePath);
            return File(file, "image/jpeg");
        }
    }
}