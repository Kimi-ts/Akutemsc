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
    public class AfishaController : BaseController
    {
        private AkuteDBEntities context;

        public AfishaController(AkuteDBEntities context)
        {
            this.context = context;
        }

        public ActionResult Concerts()
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            var currdate = DateTime.Now.Date;
            var concertsformdb = context.Concerts.Where(c => c.Date >= currdate).ToList();

            var concerts = new List<LocalizedConcert>();
            foreach (var conc in concertsformdb)
            {
                concerts.Add(new LocalizedConcert(conc, lang));
            }

            return View(concerts);
        }

        public ActionResult GetConcertLogo(string filename)
        {
            var file = Server.MapPath("~/Data/Pictures/Concert Logos/" + filename);
            return File(file, "image/jpeg");
        }
    }
}