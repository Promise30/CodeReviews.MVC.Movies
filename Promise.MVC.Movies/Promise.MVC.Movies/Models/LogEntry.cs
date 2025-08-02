namespace Promise.MVC.Movies.Models
{
    public class LogEntry
    {
        public Guid Id  { get; set; } 
        public string Message { get; set; } 
        public string StackTrace { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
