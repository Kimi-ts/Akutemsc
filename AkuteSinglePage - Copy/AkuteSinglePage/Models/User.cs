//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AkuteSinglePage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Blogs = new HashSet<Blog>();
            this.PhotoAlbums = new HashSet<PhotoAlbum>();
        }
    
        public int Id { get; set; }
        public string NameRu { get; set; }
        public string SurnameRu { get; set; }
        public string NameEn { get; set; }
        public string SurnameEn { get; set; }
        public string NameBe { get; set; }
        public string SurnameBe { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Vkontakte { get; set; }
        public string Instagram { get; set; }
        public string LogoFilename { get; set; }
    
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<PhotoAlbum> PhotoAlbums { get; set; }
    }
}
