using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TM_EducationV1.DTO
{
    public class UnitDTO
    {

        public Guid id { get; set; }
        public int coursecode { get; set; }
        public string courseimg { get; set; }
        public string coursename { get; set; }

    }  
    public class courseInfo

    {
        public Guid id { get; set; }
        public int code { get; set; }
        public string img{ get; set; }
        public string name{ get; set; }
    
    } 
    public class AllUnits

    {
        public Guid id { get; set; }
        public string coursName { get; set; }
        public string img{ get; set; }
        public string name{ get; set; }
    
    }
}