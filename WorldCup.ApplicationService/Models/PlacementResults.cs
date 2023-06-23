namespace WorldCup.ApplicationService.Models
{
    public class PlacementResults
    {
        public Dictionary<int, Group> Groups { get; }
        public int TotalDraws { get; set; }

        public PlacementResults(int[] groupIds)
        {
            var groups = groupIds.Select(g => new Group(g));
            Groups = groups.ToDictionary(g => g.Id);
        }
    }

    public class Group
    {
        public Group(int id)
        {
            Id = id;
            TeamIds = new List<int>();
        }

        public int Id { get; }
        public List<int> TeamIds { get; }
    }
}
