using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestorDocumentosEntrada.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult platFormMenu()
        {
            return View();
        }

        public ActionResult platFormBossMenu()
        {
            return View();
        }

        public ActionResult administrativeMenu()
        {
            return View();
        }

        public ActionResult administratorMenu()
        {
            return View();
        }
    }
}