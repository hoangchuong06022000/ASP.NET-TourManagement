namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAICHIPHI")]
    public partial class LOAICHIPHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAICHIPHI()
        {
            CHIPHIs = new HashSet<CHIPHI>();
        }

        [Key]
        [StringLength(4)]
        public string MACHIPHI { get; set; }

        [Required]
        [StringLength(100)]
        public string TENLOAICHIPHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHIPHI> CHIPHIs { get; set; }
    }
}
