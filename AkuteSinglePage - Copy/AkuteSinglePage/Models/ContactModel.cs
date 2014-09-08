using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AkuteSinglePage.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage="Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage="Message can't be empty")]
        public string Message { get; set; }
    }
}