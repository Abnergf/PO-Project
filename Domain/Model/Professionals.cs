using Domain.Request;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Professionals
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int? FieldOfOperationCode { get; set; }
        public virtual FieldOfOperation FieldOfOperation { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public ICollection<ProjectTasks> ProjectTasks { get; set; }
        private Professionals()
        {}
        public Professionals(CreateProfessionalsRequest create)
        {
            Name = create.Name;
            FieldOfOperationCode = create.FieldOfOperationCode;
            CreationDate = create.CreationDate;
            Active = create.Active;
        }
        public void Update(AlterProfessionalsRequest request)
        {
            Name = request.Name;
            FieldOfOperationCode = request.FieldOfOperationCode;
            Active = request.Active;
        }
    }
}