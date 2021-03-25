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
        DAOProductos daoPro = new DAOProductos();
        
        
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
                return RedirectToAction("Productos");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            Session["nivel"] = null;
            Session["nombre"] = null;

            return RedirectToAction("Login");
        }

        public ActionResult Productos()
        {
            string valor = null;
            if (Session["nivel"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (TempData["valor"] != null)
                {
                    valor = TempData["valor"].ToString();
                }
                else
                {
                    valor = null;
                }
                List<Productos> data = new List<Productos>();
                data = daoPro.getTabla(valor);
                ViewBag.data = data;

                if (TempData["ins"] != null)
                {
                    ViewBag.ins = TempData["ins"];
                }
                if (TempData["del"] != null)
                {
                    ViewBag.del = TempData["del"];
                }
                if (TempData["mod"] != null)
                {
                    ViewBag.mod = TempData["mod"];
                }
                return View();
            }

         
        }

        [HttpPost]
        public ActionResult busqueda(string valor)
        {
            if (valor == "")
            {
                valor = null;
            }
            TempData["valor"] = valor;
            return RedirectToAction("Productos");
        }

        [HttpPost]
        public ActionResult Productos(Productos p)
        {
            List<Productos> data = new List<Productos>();
            string valor = "";
            data = daoPro.getTabla(valor);
            ViewBag.data = data;

            if (ModelState.IsValid)
            {
                string opcion = Request.Form["boton"].ToString();
                string si_eliminar = Request.Form["idProduc"].ToString();
                switch (opcion)
                {
                    case "Guardar":
                        if (daoPro.insertar(p))
                        {
                            TempData["ins"] = true;
                            return RedirectToAction("Productos");
                        }

                        break;
                    case "Eliminar":
                        if (si_eliminar.Equals("si"))
                        {
                            if (daoPro.eliminar(p))
                            {
                                TempData["del"] = true;
                                return RedirectToAction("Productos");
                            }
                        }
                       

                        break;

                    case "Modificar":
                        if (daoPro.modificar(p))
                        {
                            TempData["mod"] = true;
                            return RedirectToAction("Productos");
                        }
                        break;
                }
                
            }
            return View(p);
        }
    }
}