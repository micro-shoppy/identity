using System;
using System.Linq;
using FluentAssertions;
using MicroShoppy.Identity.Domain.Exceptions;
using MicroShoppy.Identity.Domain.ValueObjects;
using Xunit;

namespace MicroShoppy.Identity.UnitTests.ValueObjects
{
    [Collection("UsingPasswordStaticMethodsTests")]
    public class UserPasswordTests : IDisposable
    {
        public UserPasswordTests()
        {
            UserPassword.HashFunction = s => s;
            UserPassword.VerifyPasswordFunction = (s1, s2) => s1 == s2;
        }

        [Fact]
        public void CreatingUserPasswordUsingConstructor_WhenHashFunctionIsNotSet_ShouldReturnNullReferenceException()
        {
            // Arrange
            const string password = "Password123";
            UserPassword.HashFunction = default;

            Action action = () =>
            {
                // Act
                var userPassword = new UserPassword(password);
            };

            action.Should().Throw<NullReferenceException>("UserPassword's HashFunction static property is not set.");
        }

        [Fact]
        public void CreatingUserPasswordUsingForMethod_WhenHashFunctionIsNotSet_ShouldReturnNullReferenceException()
        {
            // Arrange
            const string password = "Password123";
            UserPassword.HashFunction = default;

            Action action = () =>
            {
                // Act
                var userPassword = UserPassword.For(password);
            };

            action.Should().Throw<NullReferenceException>("UserPassword's HashFunction static property is not set.");
        }

        [Fact]
        public void VerifyingUserPassword_WhenVerifyPasswordFunctionIsNotSet_ShouldReturnNullReferenceException()
        {
            // Arrange
            const string password = "Password123";
            var userPassword = new UserPassword(password);
            UserPassword.VerifyPasswordFunction = default;

            Action action = () =>
            {
                // Act
                userPassword.VerifyPassword(password);
            };

            action.Should().Throw<NullReferenceException>("UserPassword's VerifyPasswordFunction static property is not set.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("user password")]
        public void CreatingUserPasswordUsingConstructor_WithInvalidValue_ShouldThrowInvalidUserPasswordException(
            string userPassword)
        {
            //Arrange
            Action action = () =>
            {
                // Act
                var userPasswordVO = new UserPassword(userPassword);
            };

            // Assert
            action.Should().Throw<InvalidUserPasswordException>("invalid user password is used.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("user password")]
        public void CreatingUserPasswordUsingForMethod_WithInvalidValue_ShouldThrowInvalidUserPasswordException(
            string userPassword)
        {
            //Arrange
            Action action = () =>
            {
                // Act
                var userPasswordVO = UserPassword.For(userPassword);
            };

            // Assert
            action.Should().Throw<InvalidUserPasswordException>("invalid user password is used.");
        }

        [Fact]
        public void VerifyingAllPasswordValueObjects_CreatedFromSameUserPasswordStringUsingConstructor_ShouldReturnTrue()
        {
            // Arrange
            const string password = "Password123";
            var userPassword = new UserPassword(password);

            // Act
            var allPasswordsVerified = Enumerable.Range(0, 10).Select(x => password)
                .Aggregate(true, (b, s) => b && userPassword.VerifyPassword(s));

            // Assert
            allPasswordsVerified.Should().BeTrue("UserPassword's VerifyPassword method uses statically set VerifyPasswordFunction to determine if password and its hash are equal.");
        }

        [Fact]
        public void VerifyingAllPasswordValueObjects_CreatedFromSameUserPasswordStringUsingForMethod_ShouldReturnTrue()
        {
            // Arrange
            const string password = "Password123";
            var userPassword = UserPassword.For(password);

            // Act
            var allPasswordsVerified = Enumerable.Range(0, 10).Select(x => password)
                .Aggregate(true, (b, s) => b && userPassword.VerifyPassword(s));

            // Assert
            allPasswordsVerified.Should().BeTrue("UserPassword's VerifyPassword method uses statically set VerifyPasswordFunction to determine if password and its hash are equal.");
        }

        public void Dispose()
        {
            UserPassword.HashFunction = default;
            UserPassword.VerifyPasswordFunction = default;
        }
    }
}