using Domain.Request;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class FieldOfOperation
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Professionals> Professionals { get; set; }
        private FieldOfOperation()
        {}
        public FieldOfOperation(CreateFieldOfOperationRequest createFieldOfOperation)
        {
            Title = createFieldOfOperation.Title;
            Description = createFieldOfOperation.Description;
            Code = createFieldOfOperation.Code;
            CreationDate = createFieldOfOperation.CreationDate;
            Professionals = new List<Professionals>();
        }
        public void Update(AlterFieldOfOperationRequest alterFieldOfOperation)
        {
            Title = alterFieldOfOperation.Title;
            Description = alterFieldOfOperation.Description;
            Code = alterFieldOfOperation.Code;
            CreationDate = alterFieldOfOperation.CreationDate;
            Professionals = new List<Professionals>();
        }
    }
}