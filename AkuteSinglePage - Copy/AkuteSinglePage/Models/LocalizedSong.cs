using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedSong
    {
        private Song song;
        private CultureInfo lang;

        public LocalizedSong(Song song, CultureInfo lang)
        {
            this.song = song;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return song.Id;
            }
        }

        public int AlbumId
        {
            get
            {
                return song.AlbumId;
            }
        }

        public int Number
        {
            get
            {
                return song.Number;
            }
        }

        public string Filename
        {
            get
            {
                return song.Filename;
            }
        }

        public string Lyrics
        {
            get
            {
                return song.Lyrics;
            }
        }

        public string Title
        {
            get
            {
                if (lang.Name == "be")
                {
                    return song.TitleBe;
                }
                if (lang.Name == "ru")
                {
                    return song.TitleRu;
                }
                if (lang.Name == "en")
                {
                    return song.TitleEn;
                }
                return string.Empty;
            }
        }

        public LocalizedAlbum Album
        {
            get
            {
                return new LocalizedAlbum(song.Album, lang);
            }
        }
    }
}