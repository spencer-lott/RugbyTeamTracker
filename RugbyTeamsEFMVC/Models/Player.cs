using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RugbyTeamsEFMVC.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z_]*$", ErrorMessage = "Please enter text")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z_]*$", ErrorMessage = "Please enter text")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string? Notes { get; set; }
        public string? Position { get; set; }

        [Required]
        public int HeightFt { get; set; }

        [Required]
        public int HeightIn { get; set; }

        [Required]
        public int Weight { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }

        public string CompleteHeight
        {
            get
            {
                return $"{HeightFt}' {HeightIn}\"";
            }
        }

        //Relationship with the Team model/table
        public int TeamId { get; set; } //Foreign Key

        public Team Team { get; set; } //Reference navigation property
    }
}
