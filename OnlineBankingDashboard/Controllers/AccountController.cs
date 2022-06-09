using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBankingDashboard.Models;

namespace OnlineBankingDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration config;
        public readonly Applicationcontext context;
        public AccountController(IConfiguration _config, Applicationcontext _context)
        {
            config = _config;
            context = _context;

        }

        [HttpPut("Credit_to_Accno/{Accno}")]
        public async Task<IActionResult> CreditAmount(int Accno, Account cwdp)
        {
            var data = await context.accounts.FirstOrDefaultAsync(item => item.accno == Accno);
            if (data != null)
            {

                data.balance = (int)(data.balance + cwdp.creditamount);
                data.creditamount = cwdp.creditamount;
                await context.SaveChangesAsync();
            }
            return Ok("success");
        }


        [HttpPut("Debit/{accno}")]
        public async Task<IActionResult> DebitAmount(int accno, Account cwdp)
        {
            var data = await context.accounts.FirstOrDefaultAsync(item => item.accno == accno);
            if (data != null)
            {

                data.balance = (int)(data.balance - cwdp.debitamount);
                data.debitamount = cwdp.debitamount;
                await context.SaveChangesAsync();
            }
            return Ok(data);
        }


        [HttpPost("InsertTableRow")]
        public async Task<ActionResult<Account>> InsertTableRow(Account cwdp)
        {
            await context.accounts.AddAsync(cwdp);
            await context.SaveChangesAsync();
            return Ok("success");
        }


        [HttpGet("GetAccountdata/{Accno}")]
        public async Task<ActionResult<Account>> GetAccountdata(int Accno)
        {
            var tableData = await (from x in context.accounts
                                   where x.accno == Accno
                                   select new
                                   {
                                       accno = x.accno,
                                       balance = x.balance,
                                       created = x.created,
                                       creditamount = x.creditamount,
                                       debitamount = x.debitamount,


                                   }).ToListAsync();

            return Ok(tableData);
            //return Ok("success");
        }
    }
}
