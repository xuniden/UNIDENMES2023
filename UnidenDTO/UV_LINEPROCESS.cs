//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnidenDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class UV_LINEPROCESS
    {
        public long ProcessId { get; set; }
        public string ProcessName { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public Nullable<bool> Completed { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Lot { get; set; }
        public Nullable<bool> DeleteSatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string GroupProcess { get; set; }
    }
}
