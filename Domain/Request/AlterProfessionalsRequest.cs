namespace Domain.Request
{
    public class AlterProfessionalsRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FieldOfOperationCode { get; set; }
        public bool Active { get; set; }
    }
}