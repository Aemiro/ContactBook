using System;
namespace ContactBook.Domain.Contacts
{
    public class Contact : BaseModel
    {
        public String Name { get; private set; }
        public String Nickname { get; private set; }
        public String Phone { get; private set; }
        public String Email { get; private set; }
        public String Gender { get; private set; }
        public String Picture { get; private set; }
        public String Website { get; private set; }
        public int? GroupId { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public void SetName(String name)
        {
            this.Name = name;
        }
        public void SetNickName(String nickName)
        {
            this.Nickname = nickName;
        }
        public void SetPhone(String phone)
        {
            this.Phone = phone;
        }
        public void SetEmail(String email)
        {
            this.Email = email;
        }
        public void SetGender(String gender)
        {
            this.Gender = gender;
        }
        public void SetWebsite(String website)
        {
            this.Website = website;
        }
        public void SetPicture(String picture)
        {
            this.Picture = picture;
        }

        public void SetBirthDate(DateTime? birthDate)
        {
            this.BirthDate = birthDate;
        }
       public void SetGroupId(int? groupId)
        {
            this.GroupId = groupId;
        }
        public Contact()
        {

        }
        public Contact(String name, String nickName, String phone, String email, String website, String gender, String picture, DateTime createdAt, DateTime updatedAt, int? groupId, DateTime? birthDate):this()
        {
            this.SetName(name);
            this.SetNickName(nickName);
            this.SetPhone(phone);
            this.SetEmail(email);
            this.SetWebsite(website);
            this.SetGender(gender);
            this.SetPicture(picture);
            this.SetCreatedAt(createdAt);
            this.SetUpdatedAt(updatedAt);
            this.SetBirthDate(birthDate);
            this.SetGroupId(groupId);
        }
    }
}
