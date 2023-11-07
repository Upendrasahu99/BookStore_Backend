using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RepoLayer.Entity;

namespace RepoLayer.Context
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
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.PinCode).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Address__User_Id__571DF1D5");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Book__A25C5AA7C9017733")
                    .IsUnique();

                entity.Property(e => e.Author).IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Language).IsUnicode(false);

                entity.Property(e => e.Publisher).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<OrderData>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Order_Da__F1E4607B0A65E100");

                entity.Property(e => e.OrderStatus).IsUnicode(false);

                entity.Property(e => e.PaymentStatus).IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.OrderData)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Order_Dat__Addre__71D1E811");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderData)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Order_Dat__Book___70DDC3D8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderData)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Order_Dat__User___6FE99F9F");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__206D91705970CB28");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D1053489725917")
                    .IsUnique();

                entity.HasIndex(e => e.MobileNum)
                    .HasName("UQ__Users__0134C2C6766CB88B")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MobileNum).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
