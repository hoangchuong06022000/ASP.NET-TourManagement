namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIHINHDULICH")]
    public partial class LOAIHINHDULICH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIHINHDULICH()
        {
            TOURDULICHes = new HashSet<TOURDULICH>();
        }

        [Key]
        [StringLength(4)]
        public string MALOAIHINH { get; set; }

        [Required]
        [StringLength(100)]
        public string TENLOAIHINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOURDULICH> TOURDULICHes { get; set; }
    }
}
