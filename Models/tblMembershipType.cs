//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMembershipType
    {
        public tblMembershipType()
        {
            this.tblMemberships = new HashSet<tblMembership>();
        }
    
        public int MembershipTypeId { get; set; }
        public string MembershipName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> AllowedMonth { get; set; }
    
        public virtual ICollection<tblMembership> tblMemberships { get; set; }
    }
}
