namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHIPHI")]
    public partial class CHIPHI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string MACHIPHI { get; set; }
        public string TENLOAICHIPHI
        {
            get { return LOAICHIPHI.TENLOAICHIPHI; }
        }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string MADOAN { get; set; }

        public double? SOTIEN { get; set; }

        public string GIATIEN
        {
            get { return DinhDanhTien((double)SOTIEN); }
        }
        public string DinhDanhTien(double Tien)
        {
            return string.Format("{0:#,##0}", Tien);
        }
        public virtual LOAICHIPHI LOAICHIPHI { get; set; }

        public virtual DOANDULICH DOANDULICH { get; set; }
    }
}
