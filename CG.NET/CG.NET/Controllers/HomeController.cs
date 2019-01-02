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
        private MSDBTools tools;

        public HomeController()
        {
            tools = new MSDBTools();
        }


        public ActionResult Index()
        {
            ServerModel model = Session["DB"] as ServerModel;
            if (model == null)
            {
                return RedirectToAction("Login");
            }
            tools.Login(model);
            DataTable dt = tools.ExcuteDataTable(string.Format(SQLStr.Tables, model.database), System.Data.CommandType.Text);
            List<string> Tables = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
                Tables.Add(item[0].ToString());
            }
            ViewBag.Tables = Tables;
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
                    if (model.dbtype=="MSSQL")
                    {
                        tools.Login(model);
                        DataTable dt = tools.ExcuteDataTable(SQLStr.Datatables, System.Data.CommandType.Text);
                        List<string> Data = new List<string>();
                        foreach (DataRow item in dt.Rows)
                        {
                            Data.Add(item[0].ToString());
                        }
                        hs.Add("Data", Data);
                    }
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
            if (ModelState.IsValid&&!string.IsNullOrWhiteSpace(model.database))
            {
                try
                {
                    if (model.dbtype == "MSSQL")
                    {
                        Session["DB"] = model;
                        Code = 0;
                    }
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