using System.ComponentModel.DataAnnotations;

namespace DemoApp.ViewModels {

    public class RegisterViewModel {
        [Display ( Name = "Email" )]
        [Required]
        [DataType ( DataType.EmailAddress )]
        public string? Email { get; set; }

        [Display ( Name = "Password" )]
        [Required]
        [DataType ( DataType.Password )]
        public string? Password { get; set; }

        [Display ( Name = "Confirm password" )]
        [DataType ( DataType.Password )]
        [Compare ( nameof ( Password ) )]
        public string? ConfirmPassword { get; set; }
    }
}
