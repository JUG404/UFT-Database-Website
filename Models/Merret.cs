using Finance.Models;
using System.ComponentModel.DataAnnotations;
namespace Finance.Models
{
    public class Merret
    {
        public int Id { get; set; }
        public required string Emer { get; set; }
        public required string Mbiemer { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Shuma nuk mund të jetë negative.")]
        public int Shuma { get; set; }

        [Required] 
        [Range(100000, 999999, ErrorMessage = "Kodi duhet të jetë një numër 6-shifror.")]
        public int Kodi { get; set; }
        public bool Verifiko(Dergon tarifat)
        {
            return this.Kodi == tarifat.Kodi;
        }

        public Merret() { }
    }
}
