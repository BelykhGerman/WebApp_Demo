using Microsoft.AspNetCore.Identity;

namespace DemoApp.Core.Models {
    public class Friend {
        public int Id { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Note { get; set; }
        public IEnumerable<Group>? Groups { get; set; }
        public IEnumerable<Contact>? Contacts { get; set; }

    }
}
