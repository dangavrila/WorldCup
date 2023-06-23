namespace WorldCup.ApplicationService.Models
{
    public class DrawGroupsResponse
    {
        public List<GroupModel> Groups { get; set; } = new List<GroupModel>();
    }

    public class GroupModel
    {
        public string GroupName { get; set; }
        public List<Name> Teams { get; set; } = new List<Name>();
    }

    public record struct Name(string name);
}
