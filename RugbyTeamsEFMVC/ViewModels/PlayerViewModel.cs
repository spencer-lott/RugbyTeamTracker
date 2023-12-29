using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using RugbyTeamsEFMVC.Models;

namespace RugbyTeamsEFMVC.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        public PlayerViewModel() 
        {
            teams = new List<Team>();
            positions = new List<string>();
        }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z_]*$", ErrorMessage = "Please enter text")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z_]*$", ErrorMessage = "Please enter text")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        
        public string? Notes { get; set; }
        public string? Position { get; set; }

        [Required(ErrorMessage = "Height in feet is required")]
        [DisplayName("Height ft.")]
        public int HeightFt { get; set; }

        [Required(ErrorMessage = "Inches are required, if zero input \"0\"")]
        [Range(0, 11, ErrorMessage = "The field for Inches must be between 0 and 11.")]
        [DisplayName("Height in.")]
        public int HeightIn { get; set; }

        [Required(ErrorMessage = "Weight in pounds is required")]
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

        [Required(ErrorMessage = "Please make sure to select a team")]
        public int TeamId { get; set; } //Foreign Key

        public List<Team> teams { get; set; }
        public List<string> positions { get; set; }

    }
}
