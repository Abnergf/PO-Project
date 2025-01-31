namespace Domain.Request
{
    public class CreateTaskFilesRequest
    {
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }
        public string FileTitle { get; set; }
        public string FileURL { get; set; }
    }
}
