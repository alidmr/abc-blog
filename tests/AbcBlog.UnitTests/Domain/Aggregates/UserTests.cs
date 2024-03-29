﻿using AbcBlog.Domain.Aggregates.Users;
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
    public class UserTests
    {
        [Test]
        public void Load_ShouldThrowException_WhenUserFistNameNull()
        {
            var result = Assert.Throws<DomainException>(() =>
            {
                User.Load(null, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                    It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>());
            });
            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error1));
        }

        [Test]
        public void Load_ShouldThrowException_WhenUserLastNameNull()
        {
            var faker = new Faker("tr");
            var result = Assert.Throws<DomainException>(() =>
            {
                User.Load(faker.Person.FirstName, null, It.IsAny<string>(), It.IsAny<bool>(),
                    It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>());
            });
            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error2));
        }

        [Test]
        public void Load_ShouldThrowException_WhenUserEmailNull()
        {
            var faker = new Faker("tr");
            var result = Assert.Throws<DomainException>(() =>
            {
                User.Load(faker.Person.FirstName, faker.Person.LastName, null, It.IsAny<bool>(),
                    It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>());
            });
            result.Should().NotBeNull();
            result?.Code.Should().Be(nameof(DomainErrorCode.Error3));
        }

        [Test]
        public void Load_ShouldResult_WhenSuccess()
        {
            var faker = new Faker("tr");
            var firstName = faker.Person.FirstName;
            var lastName = faker.Person.LastName;
            var email = faker.Internet.Email();
            var isActive = faker.Random.Bool();
            var isDeleted = faker.Random.Bool();
            var isEmailVerified = faker.Random.Bool();
            var password = faker.Internet.Password();
            var salt = faker.Random.String();

            var result = User.Load(firstName, lastName, email, isActive, isDeleted, isEmailVerified, password, salt);

            result.Should().NotBeNull();
            result.FirstName.Should().Be(firstName);
            result.LastName.Should().Be(lastName);
            result.Email.Should().Be(email);
            result.IsActive.Should().Be(isActive);
            result.IsDeleted.Should().Be(isDeleted);
            result.IsEmailVerified.Should().Be(isEmailVerified);
        }
    }
}
