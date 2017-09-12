using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace RealState2.Models
{
    public class TwoModel
    {
        public long ID { set; get; }
        public User Usrs { get; set; }
        public Project Projects  { get; set; }
    }
}