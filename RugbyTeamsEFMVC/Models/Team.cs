using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RugbyTeamsEFMVC.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z_]*$", ErrorMessage = "Please enter text")]
        [DisplayName("Team Name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z_]*$", ErrorMessage = "Please enter text")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z_]*$", ErrorMessage = "Please enter text")]
        public string State { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        //Relationship
        public List<Player> Players { get; set; }
    }
}
