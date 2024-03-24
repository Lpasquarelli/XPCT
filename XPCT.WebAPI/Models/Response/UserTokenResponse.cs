namespace XPCT.WebAPI.Models.Response
{
    public class UserTokenResponse
    {
        public string Token { get; private set; }
        public DateTime DueDate { get; private set; }

        public UserTokenResponse(string token, DateTime dueDate)
        {
            Token = token;
            DueDate = dueDate;
        }
    }
}
