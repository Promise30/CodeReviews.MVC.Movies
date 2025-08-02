using Promise.MVC.Movies.Data;
using Promise.MVC.Movies.Models;

namespace Promise.MVC.Movies.Services
{
    public class DatabaseLogger : IDatabaseLogger
    {
        private readonly MovieDbContext _dbContext;

        public DatabaseLogger(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Log(Exception ex)
        {
            try
            {
                var logEntry = new LogEntry
                {
                    Id = Guid.NewGuid(),
                    Message = ex.Message ?? "Unknown error occurred",
                    StackTrace = ex.StackTrace ?? "No stack trace available",
                    Timestamp = DateTime.UtcNow
                };
                
                _dbContext.LogEntries.Add(logEntry);
                _dbContext.SaveChanges();
            }
            catch (Exception logEx)
            {
                // Log to system event log or console as fallback
                Console.WriteLine(logEx.ToString());

                // Avoid infinite recursion by not calling this logger again
                System.Diagnostics.Debug.WriteLine($"Failed to log to database: {logEx.Message}");
            }
        }
    }
}
