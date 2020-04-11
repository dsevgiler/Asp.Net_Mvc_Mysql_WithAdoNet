using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Soru2.Models
{
    public class category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}