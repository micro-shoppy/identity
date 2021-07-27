using System;
using FluentAssertions;
using MicroShoppy.Identity.Domain.Entities;
using MicroShoppy.Identity.Domain.ValueObjects;
using Xunit;

namespace MicroShoppy.Identity.UnitTests.Entities
{
    [Collection("UsingPasswordStaticMethodsTests")]
    public class UserTests : IDisposable
    {
        public UserTests()
        {
            UserPassword.HashFunction = s => s;
            UserPassword.VerifyPasswordFunction = (s1, s2) => s1 == s2;
        }

        [Fact]
        public void CreatingUser_WithNullEmail_ShouldThrowArgumentNullException()
        {
            // Arrange
            Action action = () =>
            {
                // Act
                var user = new User(
                    Guid.NewGuid(),
                    DateTime.UtcNow,
                    null,
                    UserName.For("UserName"), 
                    UserPassword.For("Password123"));
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreatingUser_WithNullUserName_ShouldThrowArgumentNullException()
        {
            // Arrange
            Action action = () =>
            {
                // Act
                var user = new User(
                    Guid.NewGuid(),
                    DateTime.UtcNow,
                    Email.For("email@domain.com"),
                    null,
                    UserPassword.For("Password123"));
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreatingUser_WithNullUserPassword_ShouldThrowArgumentNullException()
        {
            // Arrange
            Action action = () =>
            {
                // Act
                var user = new User(
                    Guid.NewGuid(),
                    DateTime.UtcNow,
                    Email.For("email@domain.com"),
                    UserName.For("UserName"),
                    null);
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        public void Dispose()
        {
            UserPassword.HashFunction = default;
            UserPassword.VerifyPasswordFunction = default;
        }
    }
}