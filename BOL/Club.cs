//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Club
    {
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public int NumberOfMembers { get; set; }
        public int ClubManagerId { get; set; }
    
        public virtual Member Member { get; set; }
    }
}