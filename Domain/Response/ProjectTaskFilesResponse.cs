namespace Domain.Response
{
    public class ProjectTaskFilesResponse
    {
        public int Id { get; set; }
        public int ProjectTaskId{ get; set; }
        public string FileTitle { get; set; }
        public string FileURL { get; set; }
    }
}