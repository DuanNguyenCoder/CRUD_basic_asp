//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public System.DateTime publish_date { get; set; }
        public decimal price { get; set; }
    }
}