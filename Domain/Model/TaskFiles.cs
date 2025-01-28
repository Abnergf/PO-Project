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
        public string FileTitle { get; set; }
        public string FileURL { get; set; }
        public virtual ProjectTasks ProjectTasks { get; set; }
    }
}