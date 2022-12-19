using System.ComponentModel.DataAnnotations;

namespace Movie_Api.Model
{
    public class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>() ;
        }
        [Key]
        public int Genre_Id { get; set; }
        [Required]
        
        public string? Genre_Name { get; set; }

       


        public virtual ICollection<Movie> Movies { get; set; }

        
    }
}
