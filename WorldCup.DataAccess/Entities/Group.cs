namespace WorldCup.DataAccess.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Draw> Draws { get; set; }
    }
}
