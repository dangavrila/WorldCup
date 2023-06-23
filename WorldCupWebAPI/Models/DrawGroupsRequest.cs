using System.ComponentModel.DataAnnotations;

namespace WorldCup.WebAPI.Models
{
    public class DrawGroupsRequest
    {
        [Required]
        public int GroupCount { get; set; }

        [Required]
        public Person? User { get; set; }
    }

    public class Person
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
    }
}
