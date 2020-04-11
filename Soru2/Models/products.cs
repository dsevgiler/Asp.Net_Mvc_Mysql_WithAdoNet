using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Soru2.Models
{
    public class products
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public int UnitInStock { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        
    }
}