namespace CourseApi.ViewModel
{
    public class BatchViewModel
    {
        public int BatchCode { get; set; }
        public string BatchName { get; set; }
        public DateOnly StartDate { get; set; }
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public string TrainerName { get; set; }
    }
}

