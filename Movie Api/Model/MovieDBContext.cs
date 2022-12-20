using Microsoft.EntityFrameworkCore;

namespace Movie_Api.Model
{
    public partial class MovieDBContext : DbContext
    {
       /* public MovieDBContext()
        {

        }*/
        public MovieDBContext(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server= DESKTOP-SC4NGQA\\SQLEXPRESS;Database=Movie_Recomendation;Integrated Security=True;");
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Movie>(entity =>
            {
               

                entity.HasOne(e => e.Genres)
                .WithMany(p => p.Movies)
                .HasForeignKey(d => d.Gnere_id)
                .OnDelete(DeleteBehavior.Cascade);


            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
