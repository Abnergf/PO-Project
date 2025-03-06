namespace Domain.Request
{
    public class CreateTaskFilesRequest
    {
        public int ProjectTaskId { get; set; }
        public string FileTitle { get; set; }
        public string FileURL { get; set; }
    }
}
