using ContactBook.Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactBook.Persistence.EntityConfigurations
{

    public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> config)
        {
            config.ToTable("groups", AppDbContext.DEFAULT_SCHEMA);
            config.HasKey(o => o.Id);
          
            config.Property(o => o.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
       
            config.Property(o => o.Name)
                .HasColumnName("name")
                .IsRequired(); 

            config.Property(o => o.Picture)
                .HasColumnName("picture")
                .HasColumnType("jsonb")
                .IsRequired(false);

            config.Property(o => o.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            config.Property(o => o.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
            var nacContacts = config.Metadata.FindNavigation(nameof(Group.Contacts));
            // DDD Patterns comment:
            // Set as field (New since EF 1.1) to access a collection property through its field
            nacContacts.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}