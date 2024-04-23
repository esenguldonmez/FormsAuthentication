//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HerIsCepteAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public Nullable<int> City { get; set; }
        public Nullable<int> District { get; set; }
        public Nullable<int> PhotoStatus { get; set; }
        public string PhotoPath { get; set; }
        public string Password { get; set; }
        public string NotificationToken { get; set; }
        public Nullable<bool> Corporate { get; set; }
        public string TaxName { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string TaxAddress { get; set; }
        public string Otp { get; set; }
        public Nullable<bool> PhoneVerified { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public Nullable<bool> Subscription { get; set; }
        public Nullable<bool> MailVerified { get; set; }
        public Nullable<bool> Banned { get; set; }
    }
}
