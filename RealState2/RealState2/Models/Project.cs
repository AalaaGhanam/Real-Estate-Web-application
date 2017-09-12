using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealState2.Models
{
    public class Project
    {
        public long ID { set; get; }
        public string ssss { set; get; }
        public string CustomerName { set; get; }
        public string PMName { set; get; }
        public string TLName { set; get; }
        public string JEName { set; get; }
        public string Name { set; get; }
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { set; get; }
        public float Price { set; get; }
        public DateTime Date { set; get; }
        public int Code { set; get; }
        public string Comment { set; get; }
        public string Comments { set; get; }
        public Boolean Approval { set; get; }
        public Boolean Submit { set; get; }
        public Boolean Report { set; get; }
        public Boolean PMAccept { set; get; }
        public Boolean TLAccept { set; get; }
        public Boolean JEAccept { set; get; }
        public Boolean Assign{ set; get; }
        public Boolean Delivered { set; get; }
        public string Feedback { set; get; }
    }
}