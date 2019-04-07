using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using mandatory1.ViewModels;
using System.Net.Mail;
using Umbraco.Core.Models;



namespace mandatory1.Controllers
{
    public class ContactFormSurfaceController : Umbraco.Web.Mvc.SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }



        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }

            MailMessage message = new MailMessage();
            message.To.Add("iamjusthereforfun@hotmail.dk");
            message.Subject = model.Subject;
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;
            TempData["success"] = true;

            

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("iamjushereforfun@gmail.com", "qvslqldxrfmpjcks");

                // send mail
                smtp.Send(message);
                //TODO make this work Lesson 4 excercise 2
                /*IContent msg = Services.ConsentService.CreateContent(model.Subject, CurrentPage.Id, "message");
                msg.SetValue("messageName", model.Name);
                msg.SetValue("email", model.Email);
                msg.SetValue("subject", model.Subject);
                msg.SetValue("messageContent", model.Message);

                Services.ConsentService.Save(msg);*/
            }
            return RedirectToCurrentUmbracoPage();

        }

    }
}