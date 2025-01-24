using Microsoft.EntityFrameworkCore;

namespace PhoneBook_webAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Person> Person { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>(entity => {
        //        entity.HasKey(k => k.PersonId);
        //    });
        //    OnModelCreatingPartial(modelBuilder);
        //}
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
