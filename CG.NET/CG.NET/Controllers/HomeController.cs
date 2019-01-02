using CG.NET.DB;
using CG.NET.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CG.NET.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            ServerModel model = Session["DB"] as ServerModel;
            if (model == null)
            {
                return RedirectToAction("Login");
            }
            
            DataTable dt = DBTools.ExcuteDataTable(SQLStr.Tables(model.database), model);
            List<string> tables = new List<string>();
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataRow item in dt.Rows)
                {
                    tables.Add(item[0].ToString());
                }
            dt = DBTools.ExcuteDataTable(SQLStr.AllColumns(model.database), model);
            List<DBColumn> columns = new List<DBColumn>();
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataRow item in dt.Rows)
                {
                    columns.Add(new DBColumn(item, model.dbtype));
                }
            ViewBag.columns = columns;
            ViewBag.tables = tables;
            return View();
        }


        public ActionResult Login()
        {
            if (Session["DB"] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult GetDatebase(ServerModel model)
        {
            Hashtable hs = new Hashtable();
            int Code = 0;
            string Mess = "";
            if (ModelState.IsValid)
            {
                try
                {
                    DataTable dt = DBTools.ExcuteDataTable(SQLStr.Datatables(), model);
                    List<string> Data = new List<string>();
                    foreach (DataRow item in dt.Rows)
                    {
                        Data.Add(item[0].ToString());
                    }
                    hs.Add("Data", Data);
                }
                catch (Exception ex)
                {
                    Code = 500;
                    Mess = "服务器错误";
                }
            }
            else
            {
                Code = 500;
                Mess = GetErrorsMessage();
            }
            hs.Add("Mess", Mess);
            hs.Add("Code", Code);
            return Json(hs);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LoginDB(ServerModel model)
        {
            Hashtable hs = new Hashtable();
            int Code = 0;
            string Mess = "";
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(model.database))
            {
                try
                {
                    Session["DB"] = model;
                    Code = 0;
                }
                catch (Exception ex)
                {
                    Code = 500;
                    Mess = "服务器错误";
                }
            }
            else
            {
                Code = 500;
                Mess = GetErrorsMessage();
            }
            hs.Add("Mess", Mess);
            hs.Add("Code", Code);
            return Json(hs);
        }

    }
}