namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOIDUNG")]
    public partial class NOIDUNG
    {
        [Key]
        [StringLength(4)]
        public string MADOAN { get; set; }

        [StringLength(100)]
        public string HANHTRINH { get; set; }

        [Required]
        [StringLength(100)]
        public string KHACHSAN { get; set; }

        public virtual DOANDULICH DOANDULICH { get; set; }
    }
}
