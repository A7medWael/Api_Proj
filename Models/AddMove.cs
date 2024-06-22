using System.ComponentModel.DataAnnotations;

namespace FirstProj.Models
{
    public class AddMove
    {
        [MaxLength(250)]
        public string Title { get; set; }
        public int year { get; set; }
        public double Rate { get; set; }
        [MaxLength(2500)]
        public string StoreLine { get; set; }
        public IFormFile Poster { get; set; }

        public byte GenreId { get; set; }
    }
}
