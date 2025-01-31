namespace Domain.Request
{
    public class AlterTaskFilesRequest
    {
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }
        public string FileTitle { get; set; }
        public string FileURL { get; set; }
    }
}
