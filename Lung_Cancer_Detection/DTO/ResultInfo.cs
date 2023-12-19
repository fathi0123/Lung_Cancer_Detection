using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lung_Cancer_Detection.DTO
{
    public class ResultInfo
    {
        public int _ID { get; set; }
        public int uid { get; set; }
        public int Testid { get; set; }
        public String name { get; set; }
        public String testType { get; set; }
        public DateTime date { get; set; }
        public String Result { get; set; }

    }  public class TotalDe
    {
     
        public int Result { get; set; }

    }
}