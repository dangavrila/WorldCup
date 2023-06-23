namespace WorldCup.DataAccess.Entities
{
    public class Draw
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int GroupsCount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
