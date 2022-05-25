using ContactBook.Domain.Contacts;
using ContactBook.Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactBook.Persistence.EntityConfigurations
{

    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> config)
        {
            config.ToTable("contacts", AppDbContext.DEFAULT_SCHEMA);
            config.HasKey(o => o.Id);

            config.Property(o => o.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            config.Property(o => o.Name)
                .HasColumnName("name")
                .IsRequired();

            config.Property(o => o.Nickname)
                .HasColumnName("nick_name")
                .IsRequired(false); 

            config.Property(o => o.Phone)
                .HasColumnName("phone")
                .IsRequired();

            config.Property(o => o.Email)
                .HasColumnName("email")
                .IsRequired(false);

            config.Property(o => o.Website)
                .HasColumnName("website")
                .IsRequired(false);

            config.Property(o => o.Picture)
                .HasColumnName("picture")
                .HasColumnType("jsonb")
                .IsRequired(false);

            config.Property(o => o.Gender)
                .HasColumnName("gender")
                .IsRequired(false);

            config.Property(o => o.GroupId)
               .HasColumnName("group_id")
               .IsRequired(false);

            config.HasOne<Group>()
               .WithMany(x => x.Contacts)
               .HasForeignKey(y => y.GroupId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);

            config.Property(o => o.BirthDate)
                .HasColumnName("birth_date")
                .IsRequired();

            config.Property(o => o.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            config.Property(o => o.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();


        }
    }
}