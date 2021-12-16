namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTOUR")]
    public partial class CHITIETTOUR
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string MATOUR { get; set; }
        public string TENTOUR
        {
            get { return TOURDULICH.TENGOI; }
        }
        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string MADIADIEM { get; set; }

        public string TENDIADIEM
        {
            get { return DIADIEM.TENDIADIEM; }
        }

        public int THUTU { get; set; }

        public virtual TOURDULICH TOURDULICH { get; set; }

        public virtual DIADIEM DIADIEM { get; set; }
    }
}
