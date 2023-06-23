namespace WorldCup.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Draw> Draws { get; set; }
    }
}
