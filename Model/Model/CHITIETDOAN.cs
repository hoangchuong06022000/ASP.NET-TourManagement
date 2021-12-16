namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDOAN")]
    public partial class CHITIETDOAN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string MADOAN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string MAKH { get; set; }
        public string TENKH
        {
            get { return KHACH.HOTEN; }
        }

        [StringLength(100)]
        public string VAITROKH { get; set; }

        public virtual DOANDULICH DOANDULICH { get; set; }

        public virtual KHACH KHACH { get; set; }
    }
}
