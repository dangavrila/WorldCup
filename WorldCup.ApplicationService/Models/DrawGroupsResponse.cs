namespace WorldCup.ApplicationService.Models
{
    public class DrawGroupsResponse
    {
        private readonly List<GroupModel> _groups = new List<GroupModel>();
        public IEnumerable<GroupModel> Groups => _groups;

        public void AddGroup(GroupModel group)
        {
            _groups.Add(group);
        }
    }

    public class GroupModel
    {
        private readonly List<Name> _teams = new List<Name>();
        public string? GroupName { get; set; }
        public IEnumerable<Name> Teams => _teams;

        public void AddTeam(Name name)
        {
            _teams.Add(name);
        }
    }

    public record struct Name(string name);
}
