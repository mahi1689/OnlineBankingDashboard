using Microsoft.AspNetCore.Cors;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBankingDashboard.Models;


namespace OnlineBankingDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ChangerUserIdPwdController : ControllerBase
    {
        /* private IConfiguration _config;

         public ChangerUserIdPwdController(IConfiguration config)
         {
             _config = config;

         }*/
        private readonly IConfiguration config;
        public readonly ChangerUserIdPwdContext context;
        public ChangerUserIdPwdController(IConfiguration _config, ChangerUserIdPwdContext _context)
        { 
            config = _config;
            context = _context;
        }


        //return get data of loginpassword and confirmloginpwd
        [HttpPost("GetListOfData")]

        public async Task<IActionResult> GetListOfData()
        {

            var datalist = await (from x in context.ChangerUserIdPwdContexts
                            select new
                            {
                                lpwd=x.LoginPassword,
                                cnflgnpwd=x.ConfirmLoginPassword
                            }).ToListAsync();
            return Ok(datalist);
            return Ok("success created from create mthd");
        }


        [HttpGet("GetAllData")]
        public async Task<IActionResult>  GetAllData()
        {
            var datlist =await (from x in context.ChangerUserIdPwdContexts
                           select x).ToListAsync();
            return Ok(datlist);
        }



        //return all the row of specified table
        [HttpGet("GetTableData")]
        public async Task<IActionResult> GetTableData(string loginpwd, string cnflgnpwd)
        {
            var tableData =await (from x in context.ChangerUserIdPwdContexts
                             where x.LoginPassword == loginpwd && x.ConfirmLoginPassword == cnflgnpwd
                             select new
                             {
                                 otp = x.EnterOtp,
                                 transpwd = x.TransactionPassword

                             }).ToListAsync();
            return Ok(tableData);
        }

        [HttpGet("RemoveData")]

        public async Task<IActionResult> RemoveData(int id )
        {
            var xy = await context.ChangerUserIdPwdContexts.Where(item => item.AccountNumber == id).FirstOrDefaultAsync();
            context.ChangerUserIdPwdContexts.Remove(xy);
           await context.SaveChangesAsync();
            return Ok("success");      
                
        }

       

/*
        [HttpPost("InsertTableRowData")]

         public ActionResult InsertTableRow(ChangerUserIdPwdContexts cwdp)
         {
              context.ChangerUserIdPwdContexts.Add(cwdp);
             context.SaveChanges();
             return Ok("success");
         }*/
        

        
         [HttpPost("InsertTableRowData")]
          public async Task <ActionResult<ChangerUserIdPwdContexts>> InsertTableRow(ChangerUserIdPwdContexts cwdp)
          {
              await context.ChangerUserIdPwdContexts.AddAsync(cwdp);
              await context.SaveChangesAsync();
              return Ok("success");
          }


          
        [HttpPut("Update/{id}")]
         public async Task<IActionResult> UpdateUID(int id, ChangerUserIdPwdContexts cwdp)
        {
            var data =await  context.ChangerUserIdPwdContexts.FirstOrDefaultAsync(item => item.AccountNumber == id);
            if(data!=null)
            {
                data.LoginPassword = cwdp.LoginPassword;
                data.ConfirmLoginPassword = cwdp.ConfirmLoginPassword;
                data.TransactionPassword = cwdp.TransactionPassword;
                data.ConfirmTransactionPassword = cwdp.ConfirmTransactionPassword;
                data.EnterOtp = cwdp.EnterOtp;
               await context.SaveChangesAsync();
            }
            return Ok("success");
        }


        //[HttpGet("GetData/{id}")]
        //public async Task<IActionResult> GetData(int id)
        //{
        //     await context.ChangerUserIdPwdContexts.FirstOrDefaultAsync(item=>item.AccountNumber==id);

        //              await  context.SaveChangesAsync();

        //    return Ok("success");
        //}

        [HttpGet("GetData/{id}")]
        public async Task<IActionResult> GetData(int id)
        {
            
            var tableData = await (from x in context.ChangerUserIdPwdContexts
                                   where x.AccountNumber == id
                                   select new
                                   {
                                       accountNumber = x.AccountNumber,
                                       loginPassword = x.LoginPassword,
                                       confirmLoginPassword = x.ConfirmLoginPassword,
                                       transactionPassword = x.TransactionPassword,
                                       confirmTransactionPassword = x.ConfirmTransactionPassword,
                                       enterOtp = x.EnterOtp
                                       

                                   }).ToListAsync();
           
            return Ok(tableData);
            //return Ok("success");
        }


        //sql query part

        [HttpGet("Sql")]
        public IActionResult Getbyid(int id)
        {
            var str = context.ChangerUserIdPwdContexts.FromSqlRaw("select * from ChangerUserIdPwdContexts where AccountNumber = {0}", id).FirstOrDefault();
            
            return Ok(str);
        }

        [HttpPut("Updatenew1/{id}")]
        public async Task<IActionResult> UpdateUID1(int id, ChangerUserIdPwdContexts cwdp)
        {
            var data = await context.ChangerUserIdPwdContexts.FirstOrDefaultAsync(item => item.AccountNumber == id);
            if (data != null)
            {
                //data.LoginPassword = cwdp.LoginPassword;
                //data.ConfirmLoginPassword = cwdp.ConfirmLoginPassword;
                //data.TransactionPassword = cwdp.TransactionPassword;
                //data.ConfirmTransactionPassword = cwdp.ConfirmTransactionPassword;
                data.EnterOtp = data.EnterOtp + 100;
                await context.SaveChangesAsync();
            }
            return Ok(data);
        }

    }
}
