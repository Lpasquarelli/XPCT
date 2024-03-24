namespace XPCT.WebAPI.Models.Response
{
    public class UserIdentifyerResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public UserIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
