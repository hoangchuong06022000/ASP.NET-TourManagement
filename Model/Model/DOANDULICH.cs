namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOANDULICH")]
    public partial class DOANDULICH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOANDULICH()
        {
            CHIPHIs = new HashSet<CHIPHI>();
            CHITIETDOANs = new HashSet<CHITIETDOAN>();
        }

        [Key]
        [StringLength(4)]
        public string MADOAN { get; set; }

        [Required]
        [StringLength(4)]
        public string MATOUR { get; set; }

        public string TENTOUR
        {
            get { return TOURDULICH.TENGOI; }
        }

        public DateTime? NGAYKHOIHANH { get; set; }

        public DateTime? NGAYKETTHUC { get; set; }

        public double DOANHTHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHIPHI> CHIPHIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDOAN> CHITIETDOANs { get; set; }

        public virtual TOURDULICH TOURDULICH { get; set; }

        public virtual NOIDUNG NOIDUNG { get; set; }
    }
}