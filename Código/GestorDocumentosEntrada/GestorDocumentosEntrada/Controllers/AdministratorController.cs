using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorDocumentosEntrada.Models;

namespace GestorDocumentosEntrada.Controllers
{
    public class AdministratorController : Controller
    {
        private ProcedureConnection con = new ProcedureConnection();
        /**/
        public ActionResult UserList()
        {
            ViewBag.table = con.getViewUsers();
            return View();
        }
        /**/
        public ActionResult CreateUser()
        {
            ViewBag.deparmentTable = con.getDepartments();
            return View();
        }
        /**/
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            int boss = 0;
            if (form["userIsBoss"] != null) {boss = Int32.Parse(form["userIsBoss"]);}
            String name = form["userName"];
            String dep = form["userDepartment"];
            String email = form["userEmail"];
            String pwd = form["userPassword"];
            if (dep.CompareTo("Plataforma") == 0) 
            {
                 int flag = con.insertPlatfor(email, pwd, name, boss);
                 if (flag == -1) {
                     ViewBag.messege = "Lo sentimos, ese correo ya està registrado";
                     ViewBag.deparmentTable = con.getDepartments();
                     return View();
                 } else {
                     return RedirectToAction("UserList", "Administrator");
                 }
            } else {
                int flag = con.insertSecre(email, pwd, name,dep);
                if (flag == -1)
                {
                    ViewBag.messege = "Lo sentimos, ese correo ya està registrado";
                    ViewBag.deparmentTable = con.getDepartments();
                    return View();
                }
                else
                {
                    return RedirectToAction("UserList", "Administrator");
                }
            }

            
        }
        /**/
        public ActionResult procedureTypes()
        {
            ViewBag.table = con.getViewProcType();
            return View();
        }
        /**/
        [HttpPost]
        public ActionResult procedureTypes(FormCollection form)
        {
            String name = form["searchCode"];
            
            int flag = con.insertProcedureType(name);
            if (flag == -1)
            {
                ViewBag.messege = "Lo sentimos,ya està registrado";
                ViewBag.table = con.getViewProcType();
                return View();
            }
            else
            {
                ViewBag.table = con.getViewProcType();
                return View();
            }

        }
        /**/
        public ActionResult AddUser() 
        {
            return RedirectToAction("UserList", "Administrator");
        }
        /**/
        public ActionResult deleteUser(String email)
        {
            int a = con.eliminateUser(email);
            if (a == -1)
            {
                ViewBag.messege = "Error";
                return RedirectToAction("UserList", "Administrator");
            }
            //ViewBag.table = con.getViewUsers();
            return RedirectToAction("UserList", "Administrator");
        }
        /**/
        public ActionResult EditUser(String email,String name, String dep)
        {
            ViewBag.email = email;
            ViewBag.name = name;
            ViewBag.dep = dep;
            ViewBag.id = con.searchInLogging(email);
            ViewBag.deparmentTable = con.getDepartments();
            return View();
        }
        /**/
        [HttpPost]
        public ActionResult EditUser(FormCollection form )
        {
            int boss = 0;
            if (form["userIsBoss"] != null) { boss = Int32.Parse(form["userIsBoss"]); }
            String name = form["userName"];
            String Actualdep = form["dep"];
            String newDep = form["userDepartment"];
            int idlog = Int32.Parse(form["idLog"]);
            String email = form["userEmail"];
            con.updateEmail(email, idlog);

            if (Actualdep.Equals(newDep))
            {
                if (Actualdep.Equals("Plataforma"))
                {
                    con.updatePlataforma(name, boss, idlog);
                }
                else
                {
                    con.updateSecretary(name, newDep, idlog);
                }

            }
            else
            {
                if (Actualdep.Equals("Plataforma"))
                {
                    con.moveToDepartment(name, newDep, idlog, email);
                }
                else if (!Actualdep.Equals("Plataforma"))
                {
                    if (newDep.Equals("Plataforma"))
                    {
                        con.moveToPlatformer(name, boss, idlog, email);
                    }
                    else 
                    {
                        con.updateSecretary(name, newDep, idlog);
                    }
                   
                }

            }
            return RedirectToAction("UserList", "Administrator");
        }

    }
}
