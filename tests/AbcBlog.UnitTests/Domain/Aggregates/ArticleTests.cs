using AbcBlog.Domain.Aggregates.Articles;
using AbcBlog.Domain.Constants;
using AbcBlog.Domain.Exceptions;
using Bogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AbcBlog.UnitTests.Domain.Aggregates
{
    [TestFixture]
    public class ArticleTests
    {
        [Test]
        public void Load_ShouldThrowException_WhenArticleTitleNull()
        {
            var faker = new Faker();
            var result = Assert.Throws<DomainException>(() =>
            {
                Article.Load(string.Empty, It.IsAny<string>(), It.IsAny<int>());
            });

            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error6));
        }

        [Test]
        public void Load_ShouldThrowException_WhenArticleDescriptionNull()
        {
            var faker = new Faker();
            var result = Assert.Throws<DomainException>(() =>
            {
                Article.Load(faker.Random.String(), string.Empty, It.IsAny<int>());
            });

            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error7));
        }

        [Test]
        public void Load_ShouldThrowException_WhenArticleCreatedUserIdNull()
        {
            var faker = new Faker();
            var result = Assert.Throws<DomainException>(() =>
            {
                Article.Load(faker.Random.String(), faker.Random.String(), 0);
            });

            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error8));
        }

        [Test]
        public void Load_ShouldResult_WhenSuccess()
        {
            var faker = new Faker();
            var title = faker.Lorem.Sentence(3);
            var description = faker.Lorem.Paragraph(3);
            var createdUserId = faker.Random.Int(1);

            var result = Article.Load(title, description, createdUserId);

            result.Should().NotBeNull();
            result.Title.Should().Be(title);
            result.Description.Should().Be(description);
            result.CreatedUserId.Should().Be(createdUserId);
        }
    }
}
