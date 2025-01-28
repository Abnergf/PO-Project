using Domain.Enum;
namespace Domain.Request
{
    public class AlterProjectRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CompletedDate { get; set; }
        public Status Status { get; set; }
    }
}