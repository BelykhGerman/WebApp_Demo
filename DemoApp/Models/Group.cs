using DemoApp.Core.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace DemoApp.Core.Models {
    public class Group {
        public int Id { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string Title { get; set; }
        public Groups Type { get; set; }
        public string? Note { get; set; }
    }
}
