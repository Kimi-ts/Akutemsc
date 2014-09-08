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
    public class VideoController : BaseController
    {
        private AkuteDBEntities context;

        public VideoController(AkuteDBEntities context)
        {
            this.context = context;
        }

        public ActionResult Gallery()
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            var categoiesfromdb = context.VideoCatogories.ToList();
            var categories = new List<LocalizedVideoCategory>();
            foreach (var category in categoiesfromdb)
            {
                categories.Add(new LocalizedVideoCategory(category, lang));
            }

            return View(categories);
        }
    }
}