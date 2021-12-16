namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACH")]
    public partial class KHACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH()
        {
            CHITIETDOANs = new HashSet<CHITIETDOAN>();
        }

        [Key]
        [StringLength(4)]
        public string MAKH { get; set; }

        [Required]
        [StringLength(100)]
        public string HOTEN { get; set; }

        [StringLength(12)]
        public string CMND { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(3)]
        public string GIOITINH { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string QUOCTICH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDOAN> CHITIETDOANs { get; set; }
    }
}
