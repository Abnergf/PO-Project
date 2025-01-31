using Domain.Enum;
using Domain.Request;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class ProjectTasks
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        [MaxLength(200)]
        [Required]
        public string Description { get; set; }
        public float EstimatedTime { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletedDate { get; set; }
        [ForeignKey("Professional")]
        public int ProfessionalId { get; set; }
        public virtual Professionals Professional { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<TaskFiles> TaskFiles { get; set; }
        public ProjectTasks()
        {
            TaskFiles = new List<TaskFiles>();
        }
        public ProjectTasks(CreateProjectTaskRequest create)
        {
            Title = create.Title;
            Description = create.Description;
            Description = create.Description;
            EstimatedTime = create.EstimatedTime;
            CreationDate = create.CreationDate;
            StartDate = create.StartDate;
            ProfessionalId = create.ProfessionalId;
            ProjectId = create.ProjectId;
            Status = create.Status;
        }
        public void Update(AlterProjectTaskRequest request)
        {
            Title = request.Title;
            Description = request.Description;
            EstimatedTime = request.EstimatedTime;
            StartDate = request.StartDate;
            CompletedDate = request.CompletedDate;
            ProfessionalId = request.ProfessionalId;
            ProjectId = request.ProjectId;
            Status = request.Status;
        }
    }
}