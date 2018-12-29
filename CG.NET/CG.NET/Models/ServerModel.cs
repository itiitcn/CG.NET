using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CG.NET.Models
{
    public class ServerModel
    {
        [Required]
        [Display(Name ="数据库类型")]
        public string dbtype { get; set; }
        [Required]
        [Display(Name = "数据库地址")]
        public string server { get; set; }
        [Required]
        [Display(Name = "数据库登录名")]
        public string name { get; set; }
        [Required]
        [Display(Name = "数据库密码")]
        public string pwd { get; set; }
        [Display(Name = "数据库/表空间")]
        public string database { get; set; }
    }
}