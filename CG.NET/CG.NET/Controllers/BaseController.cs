using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CG.NET.Controllers
{
    public class BaseController : Controller
    {
        public string GetErrorsMessage()
        {
            string[] mess = ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage)).ToArray();
            return mess != null && mess.Length > 0 ? mess[0] : "";
        }
    }
}