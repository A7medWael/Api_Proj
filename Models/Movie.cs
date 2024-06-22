using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProj.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public int year { get; set; }
        public  double Rate { get; set; }
        [MaxLength(2500)]
        public string StoreLine { get; set; }
        public byte[] Poster { get; set; }
        
        public byte GenreId { get; set; }
        public Genre genre { get; set; }
    }
}
