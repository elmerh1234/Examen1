using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Examen1.Models;

namespace Examen1.Controllers
{
    public class HomeController : Controller
    {
        DAOUsuarios dao = new DAOUsuarios();
        
        public ActionResult Index()
        {
            if(Session["nivel"]==null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
   
        }

        public ActionResult About()
        {         

            if (Session["nivel"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
        }

        public ActionResult Contact()
        {
            if (Session["nivel"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = "Your contact page.";
                return View();
            }
        }

        public ActionResult Helpers()
        {
            return View();
        }

        public ActionResult Login(string txtUsu, string txtContra)
        {
            string usu = txtUsu;
            string contra = txtContra;
            string nivel = dao.login(usu, contra);

            if (!nivel.Equals(""))
            {
                System.Web.HttpContext.Current.Session["nivel"] = nivel;
                System.Web.HttpContext.Current.Session["nombre"] = usu;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
    }
}