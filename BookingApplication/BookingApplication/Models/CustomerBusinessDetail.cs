//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerBusinessDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerBusinessDetail()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public int Id { get; set; }
        public string SRIET { get; set; }
        public string VatNumber { get; set; }
        public string APE { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}