namespace XPCT.WebAPI.Models.Response
{
    public class ProductIdentifyerResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public ProductIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
