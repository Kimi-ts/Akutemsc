using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using AkuteSinglePage.Models;
using System.Net.Mail;
using System.Text;

namespace AkuteSinglePage.Controllers
{
    public class ContactController : BaseController
    {
        public ActionResult Details()
        {
            ViewBag.IsError = false;
            return View();
        }

        [HttpPost]
        public ActionResult Details(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Імя: " + contact.Name);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + contact.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append(contact.Message);
                    //gets info from system.net section in web.config
                    var client = new SmtpClient();
                    client.Send("r-g@tut.by", "r-g@tut.by", "Contact Us", sb.ToString());
                    return View("Success");
                }
                catch (Exception ex)
                {
                    ViewBag.IsError = true;
                    return View();
                }
            }
            else
            {
                ViewBag.IsError = false;
                return View();
            }
        }
    }
}