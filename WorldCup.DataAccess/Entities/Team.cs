namespace WorldCup.DataAccess.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Draw> Draws { get; set; }
    }
}
