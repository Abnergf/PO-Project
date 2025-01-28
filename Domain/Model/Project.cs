using Domain.Enum;
using Domain.Request;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public Status Status { get; set; }
        [JsonIgnore]
        public ICollection<ProjectTasks> ProjectTasks { get; set; }
        public ICollection<ProfessionalsInProjects> ProfessionalsInProjects { get; } = new List<ProfessionalsInProjects>();
        public Project()
        {
            Title = string.Empty;
            Description = string.Empty;
            ProjectTasks = new List<ProjectTasks>();
        }
        public Project(CreateProjectRequest createProjectRequest)
        {
            Title = createProjectRequest.Title;
            Description = createProjectRequest.Description;
            CreationDate = createProjectRequest.CreationDate;
            Status = createProjectRequest.Status;
            ProjectTasks = new List<ProjectTasks>();
        }
        public void Update(AlterProjectRequest alterProjectRequest)
        {
            Title = alterProjectRequest.Title;
            Description = alterProjectRequest.Description;
            CompletedDate = alterProjectRequest.CompletedDate;
            Status = alterProjectRequest.Status;
            ProjectTasks = new List<ProjectTasks>();
        }
    }
}