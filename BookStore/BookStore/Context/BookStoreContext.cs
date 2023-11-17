using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BookStore.Entity;

namespace BookStore.Context
{
    public partial class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<OrderData> OrderData { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullAddress)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Address__User_Id__3A4CA8FD");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Book__A25C5AA75F57FB12")
                    .IsUnique();

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageCount).HasColumnName("Page_Count");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderData>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Order_Da__F1E4607BE3A3FB27");

                entity.ToTable("Order_Data");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.DateTime)
                    .HasColumnName("Date_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.OrderData)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Order_Dat__Addre__14270015");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderData)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Order_Dat__Book___1332DBDC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderData)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Order_Dat__User___3B40CD36");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__206D917045103EB9");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D1053425D76D85")
                    .IsUnique();

                entity.HasIndex(e => e.MobileNum)
                    .HasName("UQ__Users__0134C2C6E48F1499")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNum)
                    .IsRequired()
                    .HasColumnName("Mobile_Num")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
