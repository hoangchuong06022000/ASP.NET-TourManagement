using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.Model
{
    public partial class QLDLEntity : DbContext
    {
        public QLDLEntity()
            : base("name=QLDL")
        {
        }

        public virtual DbSet<CHIPHI> CHIPHIs { get; set; }
        public virtual DbSet<CHITIETDOAN> CHITIETDOANs { get; set; }
        public virtual DbSet<CHITIETTOUR> CHITIETTOURs { get; set; }
        public virtual DbSet<DIADIEM> DIADIEMs { get; set; }
        public virtual DbSet<DOANDULICH> DOANDULICHes { get; set; }
        public virtual DbSet<GIATOUR> GIATOURs { get; set; }
        public virtual DbSet<KHACH> KHACHes { get; set; }
        public virtual DbSet<LOAICHIPHI> LOAICHIPHIs { get; set; }
        public virtual DbSet<LOAIHINHDULICH> LOAIHINHDULICHes { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NOIDUNG> NOIDUNGs { get; set; }
        public virtual DbSet<PHANBONHANVIEN> PHANBONHANVIENs { get; set; }
        public virtual DbSet<TOURDULICH> TOURDULICHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHIPHI>()
                .Property(e => e.MACHIPHI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHIPHI>()
                .Property(e => e.MADOAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDOAN>()
                .Property(e => e.MADOAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDOAN>()
                .Property(e => e.MAKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETTOUR>()
                .Property(e => e.MATOUR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETTOUR>()
                .Property(e => e.MADIADIEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIADIEM>()
                .Property(e => e.MADIADIEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIADIEM>()
                .HasMany(e => e.CHITIETTOURs)
                .WithRequired(e => e.DIADIEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOANDULICH>()
                .Property(e => e.MADOAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOANDULICH>()
                .Property(e => e.MATOUR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOANDULICH>()
                .HasMany(e => e.CHIPHIs)
                .WithRequired(e => e.DOANDULICH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOANDULICH>()
                .HasMany(e => e.CHITIETDOANs)
                .WithRequired(e => e.DOANDULICH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOANDULICH>()
                .HasOptional(e => e.NOIDUNG)
                .WithRequired(e => e.DOANDULICH);

            modelBuilder.Entity<GIATOUR>()
                .Property(e => e.MAGIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIATOUR>()
                .Property(e => e.MATOUR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACH>()
                .Property(e => e.MAKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACH>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACH>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACH>()
                .HasMany(e => e.CHITIETDOANs)
                .WithRequired(e => e.KHACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAICHIPHI>()
                .Property(e => e.MACHIPHI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAICHIPHI>()
                .HasMany(e => e.CHIPHIs)
                .WithRequired(e => e.LOAICHIPHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIHINHDULICH>()
                .Property(e => e.MALOAIHINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAIHINHDULICH>()
                .HasMany(e => e.TOURDULICHes)
                .WithRequired(e => e.LOAIHINHDULICH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHANBONHANVIENs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NOIDUNG>()
                .Property(e => e.MADOAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHANBONHANVIEN>()
                .Property(e => e.MANV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHANBONHANVIEN>()
                .Property(e => e.MADOAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOURDULICH>()
                .Property(e => e.MATOUR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOURDULICH>()
                .Property(e => e.MALOAIHINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOURDULICH>()
                .HasMany(e => e.CHITIETTOURs)
                .WithRequired(e => e.TOURDULICH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOURDULICH>()
                .HasMany(e => e.DOANDULICHes)
                .WithRequired(e => e.TOURDULICH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOURDULICH>()
                .HasMany(e => e.GIATOURs)
                .WithRequired(e => e.TOURDULICH)
                .WillCascadeOnDelete(false);
        }
    }
}
