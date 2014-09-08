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
    public class MusicController : BaseController
    {
        private AkuteDBEntities context;

        public MusicController(AkuteDBEntities context)
        {
            this.context = context;
        }

        public ActionResult Discography()
        {
            var lang = Thread.CurrentThread.CurrentCulture;
            var albumfromdb = context.Albums.ToList();
            var albums = new List<LocalizedAlbum>();
            foreach (var alb in albumfromdb)
            {
                albums.Add(new LocalizedAlbum(alb, lang));
            }

            return View(albums);
        }

        public ActionResult Details(int id)
        {
            var albumitem = context.Albums.Where(c => c.Id == id).FirstOrDefault();

            var lang = Thread.CurrentThread.CurrentCulture;

            var album = new LocalizedAlbum(albumitem, lang);

            return View(album);
        }

        public ActionResult SongsPanel(int albumId)
        {
            var albumitem = context.Albums.Where(c => c.Id == albumId).FirstOrDefault();

            var lang = Thread.CurrentThread.CurrentCulture;

            var album = new LocalizedAlbum(albumitem, lang);

            return PartialView("SongsPanel", album);
        }

        public ActionResult LyricsPanel(int songId)
        {
            var songItem = context.Songs.Where(c => c.Id == songId).FirstOrDefault();

            var lang = Thread.CurrentThread.CurrentCulture;

            var song = new LocalizedSong(songItem, lang);

            return PartialView("LyricsPanel", song);
        }

        public ActionResult MyAudio(int albumId, string songName, MusicType type)
        {
            string file = string.Empty;
            FileResult fileResult = null;

            switch (type)
            {
                case MusicType.MP3:
                    file = Server.MapPath("~/Data/Audio/" + albumId + "/" + songName + ".mp3");
                    fileResult = File(file, "audio/mp3");
                    break;
                case MusicType.Ogg:
                    file = Server.MapPath("~/Data/Audio/" + albumId + "/" + songName + ".ogg");
                    fileResult = File(file, "audio/ogg");
                    break;
            }

            return fileResult;
        }

        //public ActionResult MyAudio(int albumId, string songName)
        //{
        //    var file = Server.MapPath("~/Data/Audio/" + albumId + "/" + songName + ".mp3");
        //    return File(file, "audio/mp3");
        //}

        //public ActionResult MyAudioOgg(int albumId, string songName)
        //{
        //    var file = Server.MapPath("~/Data/Audio/" + "5" + "/" + "08_kraina_2.0.ogg");
        //    return File(file, "audio/ogg");
        //}

        public ActionResult MyPicture(string filename)
        {
            var file = Server.MapPath("~/Data/Pictures/Album Logos/" + filename);
            return File(file, "image/jpeg");
        }
    }
}
