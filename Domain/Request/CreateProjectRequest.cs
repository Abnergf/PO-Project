using Domain.Enum;
namespace Domain.Request
{
    public class CreateProjectRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Status Status { get; set; }
    }
}