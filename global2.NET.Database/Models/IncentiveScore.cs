namespace global2.NET.Database.Models
{
    public class IncentiveScore
    {
        public long ScoreId { get; set; }
        public long AcquiredScore { get; set; }
        public string GoalAchieved { get; set; }
        public DateTime? GoalAchievedData { get; set; }
    }
}
