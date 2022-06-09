using System.ComponentModel.DataAnnotations;

namespace OnlineBankingDashboard.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }

       
        public int accno { get; set; }

        

        
        
        public decimal balance { get; set; }

       
        public DateTime? created { get; set; }

        
       
        public decimal creditamount { get; set; }

        

        public decimal debitamount { get; set; }
        

    }
}
