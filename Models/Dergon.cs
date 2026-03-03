using System.ComponentModel.DataAnnotations;
namespace Finance.Models
{
    public class Dergon
    {
        private static Random rnd = new Random();
        private string userName;

        public int ID { get; set; }

        [Required]
        public string Emer { get; set; }

        [Required]
        public string Mbiemer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Datelindja { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Shuma nuk mund të jetë negative.")]
        public int Shuma { get; set; }

        public int Kodi { get; set; }
        public string? UserName { get; set; }
        public Dergon() { }



    }
}

