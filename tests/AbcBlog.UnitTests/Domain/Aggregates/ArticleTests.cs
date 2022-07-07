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
        public void Load_ShouldThrowException_WhenArticleIdNull()
        {
            var result = Assert.Throws<DomainException>(() =>
            {
                Article.Load(Guid.Empty, It.IsAny<string>(), It.IsAny<string>(), Guid.Empty, It.IsAny<int>(), It.IsAny<DateTime>());
            });

            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error5));
        }

        [Test]
        public void Load_ShouldThrowException_WhenArticleTitleNull()
        {
            var faker = new Faker();
            var result = Assert.Throws<DomainException>(() =>
            {
                Article.Load(faker.Random.Guid(), string.Empty, It.IsAny<string>(), It.IsAny<Guid>(),
                    It.IsAny<int>(), It.IsAny<DateTime>());
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
                Article.Load(faker.Random.Guid(), faker.Random.String(), string.Empty, It.IsAny<Guid>(),
                    It.IsAny<int>(), It.IsAny<DateTime>());
            });

            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error7));
        }

        [Test]
        public void Load_ShouldThrowException_WhenArticleOwnerIdNull()
        {
            var faker = new Faker();
            var result = Assert.Throws<DomainException>(() =>
            {
                Article.Load(faker.Random.Guid(), faker.Random.String(), faker.Random.String(), It.IsAny<Guid>(), It.IsAny<int>(),
                    It.IsAny<DateTime>());
            });

            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error8));
        }

        [Test]
        public void Load_ShouldThrowException_WhenArticleCreatedDateNull()
        {
            var faker = new Faker();
            var result = Assert.Throws<DomainException>(() =>
            {
                Article.Load(faker.Random.Guid(), faker.Random.String(), faker.Random.String(), faker.Random.Guid(), It.IsAny<int>(),
                    It.IsAny<DateTime>());
            });

            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error9));
        }

        [Test]
        public void Load_ShouldResult_WhenSuccess()
        {
            var faker = new Faker();
            var articleId = faker.Random.Guid();
            var title = faker.Lorem.Sentence(3);
            var description = faker.Lorem.Paragraph(3);
            var ownerId = faker.Random.Guid();
            var statusId = faker.Random.Int(1, 4);
            var createdDate = faker.Date.Future();

            var result = Article.Load(articleId, title, description, ownerId, statusId, createdDate);

            result.Should().NotBeNull();
            result.Id.Should().Be(articleId);
            result.Title.Should().Be(title);
            result.Description.Should().Be(description);
            result.OwnerId.Should().Be(ownerId);
            result.CreatedDate.Should().Be(createdDate);

        }
    }
}
