using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using mandatory1.ViewModels;

namespace mandatory1.Controllers
{
    public class ContactFormSurfaceController : Umbraco.Web.Mvc.SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }
    }
}