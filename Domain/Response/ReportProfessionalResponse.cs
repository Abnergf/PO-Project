namespace Domain.Response
{
    public class ReportProfessionalResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalFinishedTasks { get; set; }
        public float TotalHoursFinishedTasks { get; set; }
        public int TotalUnfinishedTasks { get; set; }
        public float TotalHoursUnfinishedTasks { get; set; }
    }
}