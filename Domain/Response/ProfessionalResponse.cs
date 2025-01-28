namespace Domain.Response
{
    public class ProfessionalResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FieldOfOperationCode { get; set; }
        public string FieldOfOperationName { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
    }
}