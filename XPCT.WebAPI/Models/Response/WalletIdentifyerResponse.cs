namespace XPCT.WebAPI.Models.Response
{
    public class WalletIdentifyerResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public WalletIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
