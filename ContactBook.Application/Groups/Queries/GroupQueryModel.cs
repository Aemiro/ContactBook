using System;

namespace ContactBook.Application.Groups.Queries
{
    public class GroupQueryModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
