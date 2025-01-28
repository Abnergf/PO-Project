using Domain.Enum;
namespace Domain.Response
{
    public class ProjectResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Status Status { get; set; }
    }
}