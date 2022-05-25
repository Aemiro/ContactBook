using ContactBook.Domain.Contacts;
using System;
using System.Collections.Generic;

namespace ContactBook.Domain.Groups
{
    public class Group:BaseModel
    {
        public String Name { get; private set; }
        public String Picture { get; private set; }
        public void SetName(String name)
        {
            this.Name = name;
        }
        public void SetPicture(String picture)
        {
            this.Picture = picture;
        }
        //Navigation
        private readonly List<Contact> contacts;
        public IReadOnlyCollection<Contact> Contacts => contacts;
        
        public Group()
        {
            contacts = new List<Contact>();
        }
        public Group(String name, String picture, DateTime createdAt, DateTime updatedAt):this()
        {
            this.SetName(name);
            this.SetPicture(picture);
            this.SetCreatedAt(createdAt);
            this.SetUpdatedAt(updatedAt);
        }

    }
}
