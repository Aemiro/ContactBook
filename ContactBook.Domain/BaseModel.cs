using System;

namespace ContactBook.Domain
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public void SetCreatedAt(DateTime createdAt)
        {
            this.CreatedAt = createdAt;
        }
        public void SetUpdatedAt(DateTime updatedAt)
        {
            this.UpdatedAt = updatedAt;
        }
    }
}
