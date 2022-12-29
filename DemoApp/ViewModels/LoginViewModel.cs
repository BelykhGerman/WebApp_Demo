using System.ComponentModel.DataAnnotations;

namespace DemoApp.Core.ViewModels {

    public class LoginViewModel {

        [Display ( Name = "Email" )]
        [Required]
        [DataType ( DataType.EmailAddress )]
        public string? Email { get; set; }
        [Display ( Name = "Password" )]
        [Required]
        [DataType ( DataType.Password )]
        public string? Password { get; set; }

        [Display ( Name = "Remember me" )]
        public bool RememberMe { get; set; }
    }
}