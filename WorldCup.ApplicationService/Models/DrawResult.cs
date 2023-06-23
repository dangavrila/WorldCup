namespace WorldCup.ApplicationService.Models
{
    public class DrawResult
    {
        public IEnumerable<Group> Groups { get; }
        public int TotalDraws { get; }
    }

    public class Group
    {
        public int Id { get; }
        public IEnumerable<int> TeamIds { get; }
    }
}
