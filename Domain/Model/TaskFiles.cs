using Domain.Request;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class TaskFiles
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProjectTasks")]
        public int ProjectTaskId { get; set; }
        public virtual ProjectTasks ProjectTasks { get; set; }
        public string FileTitle { get; set; }
        public string FileURL { get; set; }
        public TaskFiles()
        {}
        public TaskFiles(CreateTaskFilesRequest create)
        {
            ProjectTaskId = create.ProjectTaskId;
            FileTitle = create.FileTitle;
            FileURL = create.FileURL;
        }
        public void Update(AlterTaskFilesRequest request)
        {
            ProjectTaskId = request.ProjectTaskId;
            FileTitle = request.FileTitle;
            FileURL = request.FileURL;
        }
    }
}