using Domain.Enum;
namespace Domain.Request
{
    public class CreateProjectTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float EstimatedTime { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public int ProfessionalId { get; set; }
        public int ProjectId { get; set; }
        public Status Status { get; set; }
    }
}