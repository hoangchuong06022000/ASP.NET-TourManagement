namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOURDULICH")]
    public partial class TOURDULICH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOURDULICH()
        {
            CHITIETTOURs = new HashSet<CHITIETTOUR>();
            DOANDULICHes = new HashSet<DOANDULICH>();
            GIATOURs = new HashSet<GIATOUR>();
        }

        [Key]
        [StringLength(4)]
        public string MATOUR { get; set; }

        [Required]
        [StringLength(100)]
        public string TENGOI { get; set; }

        [Required]
        [StringLength(100)]
        public string DACDIEM { get; set; }

        [Required]
        [StringLength(4)]
        public string MALOAIHINH { get; set; }
        public string TENLOAITOUR
        {
            get { return LOAIHINHDULICH.TENLOAIHINH; }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTOUR> CHITIETTOURs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOANDULICH> DOANDULICHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIATOUR> GIATOURs { get; set; }

        public virtual LOAIHINHDULICH LOAIHINHDULICH { get; set; }
    }
}
