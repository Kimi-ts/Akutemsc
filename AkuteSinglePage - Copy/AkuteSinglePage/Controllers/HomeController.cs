using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AkuteSinglePage.Models;
using AkuteSinglePage.Utils;

namespace AkuteSinglePage.Controllers
{
    public class HomeController:BaseController
    {
        private AkuteDBEntities context;

        public HomeController(AkuteDBEntities context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            var model = new HomePageModel();
            var lang = Thread.CurrentThread.CurrentCulture;
            var albumfromdb = context.Albums.ToList();
            model.Albums = new List<LocalizedAlbum>();
            foreach (var alb in albumfromdb)
            {
                model.Albums.Add(new LocalizedAlbum(alb, lang));
            }

            var currdate = DateTime.Now.Date;
            var concertsformdb = context.Concerts.Where(c => c.Date >= currdate).ToList();
            model.Concerts = new List<LocalizedConcert>();
            foreach (var conc in concertsformdb)
            {
                model.Concerts.Add(new LocalizedConcert(conc, lang));
            }

            var newsfromdb = context.News.Take(5).ToList();
            model.News = new List<LocalizedNews>();
            foreach (var news in newsfromdb)
            {
                model.News.Add(new LocalizedNews(news, lang));
            }

            var videofromdb = context.Videos.Take(2).ToList();
            model.Videos = new List<LocalizedVideo>();
            foreach (var video in videofromdb)
            {
                model.Videos.Add(new LocalizedVideo(video, lang));
            }

            return View(model);
        }

        public ActionResult SetCulture(string culture, string returnUrl)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        public ActionResult GetAlbumLogo(string filename)
        {
            var file = Server.MapPath("~/Data/Pictures/Album Logos/" + filename);
            return File(file, "image/jpeg");
        }

        public ActionResult GetConcertLogo(string filename)
        {
            var file = Server.MapPath("~/Data/Pictures/Concert Logos/" + filename);
            return File(file, "image/jpeg");
        }

        public ActionResult MyAudio(int albumId, string songName)
        {
            var file = Server.MapPath("~/Data/Audio/" + albumId + "/" + songName);
            return File(file, "audio/mp3");
        }
    }
}
