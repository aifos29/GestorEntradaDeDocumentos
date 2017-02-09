using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorDocumentosEntrada.Models;
using System.Globalization;

namespace GestorDocumentosEntrada.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/
        private ProcedureConnection con = new ProcedureConnection();
        /**/
        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }
        /**/
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            String email = form["email"];
            String pwd = form["pwd"];
            int generalExist = con.getIDLogin(email, pwd); // Buscamos si el usuario realmente existe
            int idTablePlat = 0;
            if (generalExist == 0)  // Si el resultado de la busqueda es 0, ese email con esa contraseña NO existen
            {
                ViewBag.messege = "Lo sentimos, el correo y la contraseña no coinciden";
                return View();
            }
            else if (generalExist == -1) // Si el resultado es -1 hubo un problema de conexion
            {
                ViewBag.messege = "Lo sentimos, Hubo un error de conexiòn";
                return View();
            }
            else if (generalExist != 0 && generalExist != -1) // Si es cualquier otro numero, serìa el ID de la tabla login por lo que el usuario existe
            {
                idTablePlat = con.getIDPlatformer(generalExist); // Busca si es plataformista
                if (idTablePlat != 0 && idTablePlat != -1) // Si es plataformista
                {
                    int auxID = con.IsABoss(idTablePlat); // Busca si es el jefe de plataforma
                    if (auxID == 0) // Es jefe de plataforma
                    {
                        Session["userName"] = con.getNamePlatformer(idTablePlat);
                        Session["platfomerID"] = idTablePlat;
                        Session["isABoss"] = 0;
                        return RedirectToAction("platFormMenu", "Menu");
                    }
                    else // No es jefe de plataforma
                    {
                        Session["userName"] = con.getNamePlatformer(idTablePlat);
                        Session["platfomerID"] = idTablePlat;
                        Session["isABoss"] = 1;
                        return RedirectToAction("platFormBossMenu", "Menu");
                    }
                }
                else // No es plataformista
                { 
                    int idTableSec = con.getIDSecretary(generalExist);
                    
                    if (idTableSec != 0 && idTableSec != -1)
                    {
                        String name = con.getNameSecretary(idTableSec);
                        int idDep = con.getIDDepartmentBySec(idTableSec);
                        String depName = con.getNameDep(idDep);
                        if (depName.CompareTo("INFORMÁTICA") == 0 || depName.CompareTo("Informática") == 0)
                        {
                            Session["userName"] = name;
                            Session["ID"] = idTableSec;
                            Session["idDepartment"] = idDep;
                            Session["isAdministrator"] = 1;
                            return RedirectToAction("administratorMenu", "Menu");
                        }
                        else
                        {
                            Session["userName"] = name;
                            Session["ID"] = idTableSec;
                            Session["idDepartment"] = idDep;
                            Session["isAdministrator"] = 0;
                            return RedirectToAction("administrativeMenu", "Menu");
                        }
                    }
                    else 
                    {
                            ViewBag.messege = "Lo sentimos, Hubo un error";
                            return View();
                        
                    } 
                    
                }
            }

           
            return View();
        }
        
        
    }
}
