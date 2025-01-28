namespace Domain.Request
{
    public class CreateFieldOfOperationRequest
    {
        public string Title { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}