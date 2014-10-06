using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using AkuteSinglePage.Models;
using AkuteSinglePage.Utils;

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

        public ActionResult Romaramsi()
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            var userFromDb = context.Users.Where(c => c.NameRu == "Роман").First();
            var currentUser = new LocalizedUser(userFromDb, lang);
            return View(currentUser);
        }

        public ActionResult DrumExt()
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            var userfromdb = context.Users.Where(c => c.NameRu == "Павел").First();

            var currentUser = new LocalizedUser(userfromdb, lang);
            return View(currentUser);
        }

        public ActionResult DrumExtBlog(BlogSectionType section, int id)
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            switch (section)
            {
                case BlogSectionType.Notes:
                    var notefromDB = context.Blogs.Where(c => c.ID == id).First();
                    var note = new LocalizedBlog(notefromDB, lang);
                    return View("DrumExtNote", note);
                case BlogSectionType.Photos:
                    var photoAlbumFromDB = context.PhotoAlbums.Where(c => c.Id == id).First();
                    var photoAlbum = new LocalizedPhotoAlbum(photoAlbumFromDB, lang);
                    return View("DrumExtPhotoAlbum", photoAlbum);
                default:
                    break;
            }

            return View();
        }

        public ActionResult GetProfileLogo(string filename)
        {
            var file = Server.MapPath("~/Content/img/" + filename);
            return File(file, "image/jpeg");
        }

        public ActionResult GetAlbumPicture(int photoAlbumId, string filename)
        {
            var file = Server.MapPath(string.Format("~/Data/Pictures/{0}/{1}", photoAlbumId, filename));
            return File(file, "image/jpeg");
        }

        public ActionResult GetNotesList(int userId)
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            var userfromDB = context.Users.Where(c => c.Id == userId).First();
            var currentUser = new LocalizedUser(userfromDB, lang);

            switch (currentUser.Name)
            {
                case "Станистав":
                    break;
                case "Роман":
                    break;
                case "Павел":
                    return PartialView("DrumExtNotesList", currentUser);
                default:
                    break;
            }

            return null;
        }

        public ActionResult GetPhotoAlbumsList(int userId)
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            var userFromDB = context.Users.Where(c => c.Id == userId).First();

            var currentUser = new LocalizedUser(userFromDB, lang);

            switch (currentUser.Name)
            {
                case "Станистав":
                    break;
                case "Роман":
                    break;
                case "Павел":
                    return PartialView("DrumExtPhotoAlbumsList", currentUser);
                default:
                    break;
            }

            return null;
        }
    }
}