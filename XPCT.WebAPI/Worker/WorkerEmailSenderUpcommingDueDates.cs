using Quartz;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.User;
using XPCT.Domain.Entities;
using XPCT.WebAPI.Models.Response;

namespace XPCT.WebAPI.Worker
{
    /// <summary>
    /// Worker schedulado para envio de email para os clientes com investimentos com data de vencimento proximas
    /// </summary>
    public class WorkerEmailSenderUpcommingDueDates : IJob
    {
        private readonly ILogger<WorkerEmailSenderUpcommingDueDates> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Instancia um <see cref="WorkerEmailSenderUpcommingDueDates"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger{WorkerEmailSenderUpcommingDueDates}"/></param>
        /// <param name="userService"><see cref="IUserService"/></param>
        public WorkerEmailSenderUpcommingDueDates(ILogger<WorkerEmailSenderUpcommingDueDates> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Executar
        /// </summary>
        /// <param name="context"><see cref="IJobExecutionContext"/></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogInformation(":: START :: Attempt to get the wallets with upcomming due date");
                var users = _userService.GetUserWalletsUpcommingDueDate();

                if(users == null)
                {
                    _logger.LogError("An error occoured at searching users with investments at upcomming due date");
                    await ReScheduleJob(context);
                    return;
                }

                if(users.Status != GetUserWalletsUpcommingDueDateStatus.Success && 
                    users.Status != GetUserWalletsUpcommingDueDateStatus.NoContent)
                {
                    _logger.LogError(users.Message);
                    await ReScheduleJob(context);
                    return;
                }
                if(users.Status == GetUserWalletsUpcommingDueDateStatus.NoContent)
                    _logger.LogInformation($"no wallet with upcomming due date found to send email");
                else
                {
                     _logger.LogInformation($"{users.Users.Count()} Users to send email");

                    foreach (var user in users.Users)
                    {
                        SendEmail(user);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                await ReScheduleJob(context);
                return;
            }
            
            return;
        }

        /// <summary>
        /// Reprocessa o job
        /// </summary>
        /// <param name="context"><see cref="IJobExecutionContext"/></param>
        /// <returns></returns>
        private async Task ReScheduleJob(IJobExecutionContext context)
        {
            await Task.Delay(TimeSpan.FromMinutes(1));
            await Execute(context);
            return;
        }

        /// <summary>
        /// Simula o envio do email
        /// </summary>
        /// <param name="user"><see cref="User"/></param>
        /// <returns><see cref="bool"/></returns>
        private bool SendEmail(User user)
        {
            Console.WriteLine($"############################################################################");
            Console.WriteLine($"EMAIL SENT TO {user.Email}  \r\n\r\n  {GetBodyText(user.Wallet.Investments)}");
            Console.WriteLine($"############################################################################");

            return true;
        }

        /// <summary>
        /// Obter o Text do body
        /// </summary>
        /// <param name="investments"><see cref="IEnumerable{T}"/> de <see cref="Investment"/></param>
        /// <returns><see cref="string"/></returns>
        private string GetBodyText(IEnumerable<Investment> investments)
        {
            var text = "";

            foreach (var investment in investments)
            {
                text += $"INVESTMENT {investment.Product.Name} - Due Date: {investment.DueDate.ToString("dd/MM/yyyy HH:mm:ss")} - {SubtractDaysToExpire(investment.DueDate)} days to expiration \r\n\r\n ";
            }

            return text;
        }

        /// <summary>
        /// Subtrai os dias da data de vencimento
        /// </summary>
        /// <param name="dueDate">data de vencimento</param>
        /// <returns><see cref="int"/></returns>
        private int SubtractDaysToExpire(DateTime dueDate)
        {
            DateTime currentDate = DateTime.Now.Date;

            TimeSpan difference = dueDate.Date - currentDate;

            return (int)difference.TotalDays;
        }
    }
}
