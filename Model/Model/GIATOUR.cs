namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIATOUR")]
    public partial class GIATOUR
    {
        [Key]
        [StringLength(4)]
        public string MAGIA { get; set; }

        [Required]
        [StringLength(4)]
        public string MATOUR { get; set; }

        public double? THANHTIEN { get; set; }

        public DateTime? TG_BATDAU { get; set; }

        public DateTime? TG_KETTHUC { get; set; }

        public virtual TOURDULICH TOURDULICH { get; set; }
    }
}
