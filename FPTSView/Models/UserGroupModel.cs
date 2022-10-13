using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTSView.Models
{
    public class UserGroupModel
    {
        public string Username { get; set; }
        public string GroupCode { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}