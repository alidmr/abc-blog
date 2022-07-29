using AbcBlog.Domain.Aggregates.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbcBlog.Infrastructure.EntityConfigurations;

public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
{
    //1.yol = dapper native sql query
    //2.yol = orm schema modified
    //3.yol = poco -> domain model (arastir)
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles", "dbo");

        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.DomainEvents);

        builder.Property(x => x.Id);
        builder.Property(x => x.Title);
        builder.Property(x => x.Description);
        builder.Property(x => x.CreatedUserId);
        builder.Property(x => x.CreatedDate);
        builder.Property<int>("_statusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("StatusId")
            .IsRequired();

        builder.Ignore(x => x.Status);
    }
}