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
    
    public partial class CustomerDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerDetail()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public int Id { get; set; }
        public string BussinessName { get; set; }
        public string BussinessWebsite { get; set; }
        public Nullable<int> BusinessCatageoryId { get; set; }
        public Nullable<int> SubCatageoryNo { get; set; }
    
        public virtual BusinessCatageory BusinessCatageory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
