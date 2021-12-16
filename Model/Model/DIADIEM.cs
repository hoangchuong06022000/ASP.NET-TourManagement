namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIADIEM")]
    public partial class DIADIEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIADIEM()
        {
            CHITIETTOURs = new HashSet<CHITIETTOUR>();
        }

        [Key]
        [StringLength(4)]
        public string MADIADIEM { get; set; }

        [Required]
        [StringLength(100)]
        public string TENDIADIEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTOUR> CHITIETTOURs { get; set; }
    }
}
