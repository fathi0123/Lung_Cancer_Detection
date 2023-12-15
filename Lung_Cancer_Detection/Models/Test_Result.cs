//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lung_Cancer_Detection.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Test_Result
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test_Result()
        {
            this.Results = new HashSet<Result>();
        }
    
        public int C_id { get; set; }
        public Nullable<int> userid { get; set; }
        public string username { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<int> gender { get; set; }
        public Nullable<int> testid { get; set; }
        public Nullable<int> SMOKING { get; set; }
        public Nullable<int> YELLOW_FINGERS { get; set; }
        public Nullable<int> ANXIETY { get; set; }
        public Nullable<int> PEER_PRESSURE { get; set; }
        public Nullable<int> CHRONIC_DISEASE { get; set; }
        public Nullable<int> FATIGUE { get; set; }
        public Nullable<int> ALLERGY { get; set; }
        public Nullable<int> WHEEZING { get; set; }
        public Nullable<int> ALCOHOL_CONSUMING { get; set; }
        public Nullable<int> COUGHING { get; set; }
        public Nullable<int> SHORTNESS_OF_BREATH { get; set; }
        public Nullable<int> SWALLOWING_DIFFICULTY { get; set; }
        public Nullable<int> CHEST_PAIN { get; set; }
        public Nullable<bool> IS_Deleted { get; set; }
        public Nullable<System.DateTime> Datet { get; set; }
        public Nullable<int> Total_Degree { get; set; }
    
        public virtual Gender Gender1 { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }
    }
}