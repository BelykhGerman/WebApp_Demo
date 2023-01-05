using DemoApp.Core.Models.Enums;

namespace DemoApp.Core.Models {
    public class Contact {
        public int Id { get; set; }
        public Friend Friend{ get; set; }
        public string Title { get; set; }
        public Contacts Type { get; set; }
        public string Value{ get; set; }
        public string? Note { get; set; }
    }
}
