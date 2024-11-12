namespace global2.NET.Database.Models
{
    public class IncentiveScore
    {
        public long Id { get; set; }
        public long AcquiredScore { get; set; }
        public long GoalAchieved { get; set; }
        public DateTime? GoalAchievedData { get; set; }
    }
}
