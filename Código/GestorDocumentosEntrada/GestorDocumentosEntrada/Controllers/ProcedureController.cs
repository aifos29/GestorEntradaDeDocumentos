using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using GestorDocumentosEntrada.Models;
using System.Globalization;
using Newtonsoft.Json;


namespace GestorDocumentosEntrada.Controllers
{
    public class ProcedureController : Controller
    {
        private ProcedureConnection con = new ProcedureConnection();
        // GET: Procedure
        public ActionResult Create()
        {
            ViewBag.date = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.maxDate = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.minDate = (DateTime.Now.AddDays(-14)).ToString("yyyy-MM-dd"); 
            ViewBag.deparmentTable = con.getDepartments();
            ViewBag.procedureType = con.getProcedureType();
            ViewBag.identifyType = con.getIdentifyType();
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.deparmentTable = con.getDepartments();
            ViewBag.procedureType = con.getProcedureType();
            ViewBag.identifyType = con.getIdentifyType();
            ViewBag.display = false;
            return View();
        }
        /***/
        public ActionResult SearchProcedure()
        {
            ViewBag.deparmentTable = con.getDepartments();
            ViewBag.platformersTable = con.getPlatformers();
           
            return View();
        }

        public JsonResult updateFormatId(int idTypeOfIdentify) 
        {
            List<String> attributes = new List<String>();
            
            if (idTypeOfIdentify == 1) {
                attributes.Add("Ej: 1-0234-0567");
                attributes.Add("\\d{1}-\\d{4}-\\d{4}$");
            }
            if (idTypeOfIdentify == 2)
            {
                attributes.Add("Ej: 1023-400-567");
                attributes.Add("\\d{4}-\\d{3}-\\d{3}$");
            }
            else {
                attributes.Add("Ej: 7AB000221");
                attributes.Add("([a-zA-Z]|\\d){7,9}$");
            }
            return Json(attributes.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddProcedure(FormCollection form) {

             DateTime date = DateTime.Parse(form["procedureDate"]);
             int departmentId = Int32.Parse(form["department"]);
             int idTypeOfIdentify = Int32.Parse(form["idType"]);
             String personID = form["personId"];
             String personName = form["personName"];
             String personContact = form["personContact"];
             int idTypeOfProcedure = Int32.Parse(form["procedureType"]);
             String detail = form["procedureDetail"];
             int userId = Int32.Parse(Session["platfomerID"].ToString());

             ViewBag.code = con.insertProcedure(date, departmentId, idTypeOfIdentify, personID, personName, personContact, idTypeOfProcedure, detail, userId);
            return View();
        }

        public JsonResult getProcedureData(String procedureCode) 
        {
            DataSet procedure = con.getProcedure(procedureCode);
            List<string> list = new List<string>();
            foreach (DataRow row in procedure.Tables["procedureList"].Rows)
            {
                for (int index = 0; index < 9; index++ )
                {
                    list.Add(row[index].ToString());
                }
            }

            if (list.Count != 0) 
            {
                string[] dateSend = list[1].Split('/');
                string[] yearTime = dateSend[2].Split(' ');
                String date = yearTime[0] + '-' + dateSend[1] + '-' + dateSend[0];
                list[1] = date;
            } 
            
            return Json(list.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult saveChangedProcedure(FormCollection form)
        {
            String code = form["codeProcedure"];
            int idTypeOfIdentify = Int32.Parse(form["idType"]);
            String personID = form["personId"];
            String personName = form["personName"];
            String personContact = form["personContact"];
            int idTypeOfProcedure = Int32.Parse(form["procedureType"]);
            String detail = form["procedureDetail"];

            con.updateProcedure(code,idTypeOfIdentify, personID, personName, personContact, idTypeOfProcedure, detail);
            ViewBag.code = code;
            return View();
        }
        /**/
        public ActionResult searchDepartment(String dep) {
            ViewBag.searchTable = con.getSearchDep(dep);
            return View();
        }
        /**/
        public ActionResult searchPlatformist(String plat)
        {
            ViewBag.searchTable = con.getSearchPlat(plat);
            return View();
        }
        /**/
       public ActionResult searchByDate(DateTime from, DateTime to){
           ViewBag.searchTable = con.getSearchDate(from, to);
           return View();
       }
        /**/
       public ActionResult searchByCode(String code)
       {
           ViewBag.searchTable = con.getSearchCode(code);
           return View();
       }

       public ActionResult getStadisticByDepartment(String code)
       {

           ProcedureConnection con = new ProcedureConnection();
           System.Data.DataTable table = con.getStadisticByDepartment(code);

           String json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
           return Json(json, JsonRequestBehavior.AllowGet);
       }


       public ActionResult getStadisticByPlataformer(String code)
       {
           ProcedureConnection con = new ProcedureConnection();
           System.Data.DataTable table = con.getStadisticByPlataformer(code);

           String json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
           return Json(json, JsonRequestBehavior.AllowGet);
       }

       public ActionResult getStadisticByDateForDeparment(String from, String to)
       {
           ProcedureConnection con = new ProcedureConnection();
           System.Data.DataTable table = con.getStadisticByDateForDepartment(from, to);

           String json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
           return Json(json, JsonRequestBehavior.AllowGet);
       }

       public ActionResult getStadisticByDateForPlataformer(String from, String to)
       {
           ProcedureConnection con = new ProcedureConnection();
           System.Data.DataTable table = con.getStadisticByDateForPlataformer(from, to);

           String json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
           return Json(json, JsonRequestBehavior.AllowGet);
       }
        /**/
        public ActionResult dailyProcedure() 
        {
            int departmentId = 0;
            if (Session["idDepartment"] != null) { departmentId = Int32.Parse(Session["idDepartment"].ToString());}
            ViewBag.dailyProcedure = con.test(departmentId) ;
            return View();
        }
        /**/
    [HttpPost]
        public void dailyProcedure(String code)
        {
            int flag = con.init(code);
            int departmentId = Int32.Parse(Session["idDepartment"].ToString());
           //ViewBag.dailyProcedure = con.test(departmentId);
            //return View();
        }
        /**/
        public ActionResult transferProcedure(String codeProcedure, int idProcedure) 
        {
            ViewBag.idProcedure = idProcedure;
            ViewBag.codeProcedure = codeProcedure;
            ViewBag.date = DateTime.Now.ToString("yyyy-MM-dd"); 
            ViewBag.deparmentTable = con.getDepartments();
            return View();
        }
        /**/
        public ActionResult saveTransferProcedure(FormCollection form)
        {
           int idProc = Int32.Parse( form["idProcedure"].ToString());
            String code =form["codeProcedure"];
            int recive = Int32.Parse(form["department"]);
           String justi= form["justification"];
            int send = Int32.Parse(Session["ID"].ToString());
            int flag = con.TransferProcedure(idProc,recive,send,code,justi);

            return RedirectToAction("dailyProcedure", "Procedure");
        
        
        }

        public ActionResult displayProcedure() 
        {
            int departmentId = Int32.Parse(Session["idDepartment"].ToString());
            ViewBag.dailyProcedure = con.getDisplayDepartmentProcedures(departmentId);
            ViewBag.states = con.getProcedureStates();
            ViewBag.row = 0;
            return View();
        }

        [HttpPost]
        public String displayProcedure(String procedureId, String newState, String observation)
        {

            int id = Int32.Parse(procedureId);

            DateTime date = DateTime.Now;

            con.closeProcedure(newState, observation, id, date);

            ViewBag.row = procedureId;
            int departmentId = Int32.Parse(Session["idDepartment"].ToString());
            ViewBag.dailyProcedure = con.getDisplayDepartmentProcedures(departmentId);
            ViewBag.states = con.getProcedureStates();
            return procedureId;
        }
    }
}