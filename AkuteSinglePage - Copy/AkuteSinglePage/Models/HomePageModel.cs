using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class HomePageModel
    {
        public List<LocalizedAlbum> Albums { get; set; }
        //public IEnumerable<LocalizedPicture> Pictures { get; set; }
        public List<LocalizedConcert> Concerts { get; set; }
        public List<LocalizedNews> News { get; set; }
        public List<LocalizedVideo> Videos { get; set; }
    }
}