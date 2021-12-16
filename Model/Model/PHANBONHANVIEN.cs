namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANBONHANVIEN")]
    public partial class PHANBONHANVIEN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string MANV { get; set; }
        public string TENNV { get { return NHANVIEN.TENNV; } }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string MADOAN { get; set; }

        [StringLength(100)]
        public string NHIEMVU { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
