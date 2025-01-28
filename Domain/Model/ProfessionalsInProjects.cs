using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class ProfessionalsInProjects
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [ForeignKey("Professional")]
        public int ProfessionalId { get; set; }
        public virtual Professionals Professional { get; set; }

        [ForeignKey("FieldOfOperation")]
        public int FieldOfOperationId { get; set; }
        public virtual FieldOfOperation FieldOfOperation { get; set; }
        public DateTime AssociationDate { get; set; }
        public string ProjectRole { get; set; }
    }
}