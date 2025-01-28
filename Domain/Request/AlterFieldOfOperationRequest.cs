namespace Domain.Request
{
    public class AlterFieldOfOperationRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}