namespace Domain.Response
{
    public class ReportProjectResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalTasks { get; set; }
        public int TotalFinishedTasks { get; set; }
        public int TotalUnfinishedTasks { get; set; }
    }
}