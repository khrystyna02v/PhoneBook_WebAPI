using Microsoft.EntityFrameworkCore;
using PhoneBook_webAPI.PersonClasses;
using PhoneBook_webAPI.Other_entities_classes;

namespace PhoneBook_webAPI.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Person> Person { get; set; }
        public DbSet<Pet> Pet { get; set; } = default!;

        public virtual DbSet<Animal> Animal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(t => t.PersonId);
            modelBuilder.Entity<Person>().Property(t => t.Name).HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(t => t.Surname).HasMaxLength(50);

            modelBuilder.Entity<Pet>()
                .HasKey(t => t.PetId);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(p => p.Pets)
                .HasForeignKey(p => p.OwnerId);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Animal)
                .WithMany(p => p.Pets)
                .HasForeignKey(p => p.AnimalTypeId);

            modelBuilder.Entity<Address>()
                .HasKey(t => t.OwnerId);

            modelBuilder.Entity<Address>()
                .HasOne(p => p.Owner)
                .WithOne(p => p.Home)
                .HasForeignKey<Address>(p => p.OwnerId);

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
