namespace WorldCup.ApplicationService.Models
{
    public class DrawResult
    {
        public IEnumerable<Group> Groups { get; set; }
    }

    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<string> Teams { get; set; }
    }
}
