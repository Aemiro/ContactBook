using System;

namespace ContactBook.Application.Contacts.Queries
{
    public class ContactQueryModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Nickname { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String Picture { get; set; }
        public String Website { get; set; }
        public int? GroupId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
