using System.ComponentModel.DataAnnotations;

namespace MusiquitaRandom.Models
{
    public class Musiquita
    {
        [Key]
        public string SongName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Letra { get; set; }
        [Url]
        public string Link { get; set; }
    }
}
