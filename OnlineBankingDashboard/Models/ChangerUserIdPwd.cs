using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBankingDashboard.Models
{
    
    public class ChangerUserIdPwdContexts
    {
        [Key]
       public int AccountNumber { get; set; }
       public string LoginPassword { get; set; }
        
       public string ConfirmLoginPassword { get; set; }

       public string TransactionPassword { get; set; }

       public string ConfirmTransactionPassword { get; set; }

       public int EnterOtp { get; set; }
    }
}
