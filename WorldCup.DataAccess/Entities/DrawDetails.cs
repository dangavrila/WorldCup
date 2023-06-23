namespace WorldCup.DataAccess.Entities
{
    public class DrawDetail
    {
        public int Id { get; set; }

        public int DrawId { get; set; }
        public virtual Draw Draw { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
