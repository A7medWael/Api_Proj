using System.ComponentModel.DataAnnotations;

namespace FirstProj.Models
{
    public class MovieDetails
    {
       
        
        public string Title { get; set; }
        public int year { get; set; }
        public double Rate { get; set; }
        
        public string StoreLine { get; set; }
        public byte[] Poster { get; set; }

        public byte GenreId { get; set; }
        public string GenreName { get; set;}
        
    }
}

