using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JFT_Project.DTOS
{
    public partial class JFTProjectContext : DbContext
    {
        public JFTProjectContext()
        {
        }

        public JFTProjectContext(DbContextOptions<JFTProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branddto> Branddto { get; set; }
        public virtual DbSet<Collectionsdto> Collectionsdto { get; set; }
        public virtual DbSet<Productdto> Productdto { get; set; }
        public virtual DbSet<Slidedto> Slidedto { get; set; }
        public virtual DbSet<Checkoutdto> Checkoutdto { get; set; }
        public virtual DbSet<Contactdto> Contactdto { get; set; }
        public virtual DbSet<LoginModel> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS; Initial Catalog=JFTProject; trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branddto>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__BRANDDTO__F89D3409053976D7");

                entity.ToTable("BRANDDTO");

                entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");

                entity.Property(e => e.BrandImage)
                    .HasColumnName("BRAND_IMAGE")
                    .HasMaxLength(255);

                entity.Property(e => e.BrandName)
                    .HasColumnName("BRAND_NAME")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Collectionsdto>(entity =>
            {
                entity.HasKey(e => e.CollectionId)
                    .HasName("PK__COLLECTI__C9B5C62AB0A4071B");

                entity.ToTable("COLLECTIONSDTO");

                entity.Property(e => e.CollectionId).HasColumnName("COLLECTION_ID");

                entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");
                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
                entity.Property(e => e.ProductId2).HasColumnName("PRODUCT_ID2");

                entity.Property(e => e.CollectionImage)
                    .HasColumnName("COLLECTION_IMAGE")
                    .HasMaxLength(255);

                entity.Property(e => e.CollectionImage2)
                    .HasColumnName("COLLECTION_IMAGE2")
                    .HasMaxLength(255);

                entity.Property(e => e.CollectionName)
                    .HasColumnName("COLLECTION_NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Detail)
                    .HasColumnName("DETAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.ProductName1)
                    .HasColumnName("PRODUCT_NAME1")
                    .HasMaxLength(30);

                entity.Property(e => e.ProductName2)
                    .HasColumnName("PRODUCT_NAME2")
                    .HasMaxLength(30);

                entity.Property(e => e.PricePro1).HasColumnName("PRICE_PRO1");
                entity.Property(e => e.PricePro2).HasColumnName("PRICE_PRO2");
                entity.Property(e => e.Price).HasColumnName("PRICE");
            });

            modelBuilder.Entity<Productdto>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__PRODUCTD__52B41763E86606CE");

                entity.ToTable("PRODUCTDTO");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");

                entity.Property(e => e.Detail)
                    .HasColumnName("DETAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.ProductImage)
                    .HasColumnName("PRODUCT_IMAGE")
                    .HasMaxLength(255);

                entity.Property(e => e.ProductName)
                    .HasColumnName("PRODUCT_NAME")
                    .HasMaxLength(30);

                entity.Property(e => e.Qnt).HasColumnName("QNT");
                entity.Property(e => e.Qnt1).HasColumnName("QNT1");
            });

            modelBuilder.Entity<Slidedto>(entity =>
            {
                entity.HasKey(e => e.SlideId)
                    .HasName("PK__SLIDEID__34A45763E86606CE");

                entity.ToTable("SLIDEDTO");

                entity.Property(e => e.SlideId).HasColumnName("SLIDE_ID");

                entity.Property(e => e.SlideImage)
                    .HasColumnName("SLIDE_IMAGE")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Checkoutdto>(entity =>
            {
                entity.HasKey(e => e.CusId)
                   .HasName("PK__CUSID__34A45763E86609GD");

                entity.ToTable("CHECKOUTDTO");

                entity.Property(e => e.CusId).HasColumnName("CUSID");

                entity.Property(e => e.FullName)
                    .HasColumnName("FULLNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.AddressCus)
                    .HasColumnName("ADDRESSCUS")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PHONENUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.DayGet)
                   .HasColumnName("DAYGET")
                   .HasMaxLength(255);

                entity.Property(e => e.ProductImage)
                   .HasColumnName("PRODUCT_IMAGE")
                   .HasMaxLength(255);

                entity.Property(e => e.CollectionImage)
                    .HasColumnName("COLLECTION_IMAGE")
                    .HasMaxLength(255);

                entity.Property(e => e.CollectionImage2)
                    .HasColumnName("COLLECTION_IMAGE2")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Contactdto>(entity =>
            {
                entity.HasKey(e => e.CusId)
                   .HasName("PK__CUSID__34A45763E86603HG");

                entity.ToTable("CONTACTDTO");

                entity.Property(e => e.CusId).HasColumnName("CUS_ID");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasMaxLength(255);

            });

            modelBuilder.Entity<LoginModel>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                   .HasName("PK__CUSID__34A45763A977503HG");

                entity.ToTable("LOGINADMIN");

                entity.Property(e => e.AdminId).HasColumnName("AdminId");

                entity.Property(e => e.AdminName)
                    .HasColumnName("AdminName")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .HasMaxLength(255);

                

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
