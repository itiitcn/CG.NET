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

        public ActionResult Login()
        {
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


    }
}