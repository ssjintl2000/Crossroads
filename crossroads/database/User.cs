//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crossroads.database
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string UName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UGender { get; set; }
        public string UType { get; set; }
        public bool UVocalist { get; set; }
        public string UPosition { get; set; }
        public bool UPrimary { get; set; }
        public string UStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int Id { get; set; }
        public int ChurchId { get; set; }
    }
}