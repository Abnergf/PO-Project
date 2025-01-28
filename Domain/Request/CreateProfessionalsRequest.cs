namespace Domain.Request
{
    public class CreateProfessionalsRequest
    {
        public string Name { get; set; }
        public int FieldOfOperationCode { get; set; } 
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
    }
}