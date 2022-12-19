using System.ComponentModel.DataAnnotations;

namespace Movie_Api.Model
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string? Movie_Name { get; set; }
        [Required]

        public string? Director_Name { get; set; }
        [Required]
        public string? Lead_Actor { get; set; }
        [Required]
        public string? Rating { get; set; }
        [Required]
        public string? Movie_Description { get; set; }
        public int Gnere_id { get; set; }

        
        public virtual Genre? Genres { get; set; }


       

    }
}
