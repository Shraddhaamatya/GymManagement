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
    
    public partial class tblMembership
    {
        public tblMembership()
        {
            this.tblAttendances = new HashSet<tblAttendance>();
            this.tblMeasurements = new HashSet<tblMeasurement>();
            this.tblPayments = new HashSet<tblPayment>();
            this.tblWorkouts = new HashSet<tblWorkout>();
        }
    
        public int MembershipId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> MembershipTypeId { get; set; }
        public Nullable<System.DateTime> RegDate { get; set; }
        public Nullable<decimal> Fees { get; set; }
        public Nullable<int> ShiftId { get; set; }
    
        public virtual ICollection<tblAttendance> tblAttendances { get; set; }
        public virtual ICollection<tblMeasurement> tblMeasurements { get; set; }
        public virtual tblMembershipType tblMembershipType { get; set; }
        public virtual tblShift tblShift { get; set; }
        public virtual tblUser tblUser { get; set; }
        public virtual ICollection<tblPayment> tblPayments { get; set; }
        public virtual ICollection<tblWorkout> tblWorkouts { get; set; }
    }
}
