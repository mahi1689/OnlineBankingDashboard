using System.ComponentModel.DataAnnotations;

namespace OnlineBankingDashboard.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public int mobile { get; set; }

        public Account account { get; set; }
    }
}
