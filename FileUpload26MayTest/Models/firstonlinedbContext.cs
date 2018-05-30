using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FileUpload26MayTest.Models
{
    public partial class firstonlinedbContext : DbContext
    {
        public virtual DbSet<FormTable> FormTable { get; set; }
        public firstonlinedbContext(DbContextOptions<firstonlinedbContext>obj):base(obj)
        { }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=den1.mssql5.gear.host;Database=firstonlinedb;User ID=firstonlinedb; Password=Pi1d7?cX8a?e;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormTable>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);            
                entity.Property(e => e.FilePath).HasMaxLength(250);
                entity.Property(e => e.FileDownload).HasMaxLength(250);        
                entity.Property(e => e.PhoneNo).HasColumnType("numeric(18, 0)");
            });
        }
    }
}
