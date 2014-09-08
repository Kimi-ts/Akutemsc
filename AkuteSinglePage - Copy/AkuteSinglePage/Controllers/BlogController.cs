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
    public class BlogController : BaseController
    {
        private AkuteDBEntities context;

        public BlogController(AkuteDBEntities context)
        {
            this.context = context;
        }

        public ActionResult Staneskas()
        {
            return View();
        }

        public ActionResult DrumExt()
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            var userfromdb = context.Users.Where(c => c.NameRu == "Павел").First();

            var currentUser = new LocalizedUser(userfromdb, lang);
            return View(currentUser);
        }

        public ActionResult GetProfileLogo(string filename)
        {
            var file = Server.MapPath("~/Content/img/" + filename);
            return File(file, "image/jpeg");
        }
    }
}