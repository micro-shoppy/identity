using System;
using System.Linq;
using FluentAssertions;
using MicroShoppy.Identity.Domain.Exceptions;
using MicroShoppy.Identity.Domain.ValueObjects;
using Xunit;

namespace MicroShoppy.Identity.UnitTests.ValueObjects
{
    public class UserNameTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("user name")]
        public void CreatingUserNameUsingConstructor_WithInvalidValue_ShouldThrowInvalidUsernameException(
            string userName)
        {
            //Arrange
            Action action = () =>
            {
                // Act
                var userNameVO = new UserName(userName);
            };

            // Assert
            action.Should().Throw<InvalidUserNameException>("invalid user name is used.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("user name")]
        public void CreatingUserNameUsingForMethod_WithInvalidValue_ShouldThrowInvalidUsernameException(
            string userName)
        {
            //Arrange
            Action action = () =>
            {
                // Act
                var userNameVO = UserName.For(userName);
            };

            // Assert
            action.Should().Throw<InvalidUserNameException>("invalid user name is used.");
        }

        [Fact]
        public void AllUserNameValueObjects_CreatedFromSameUserNameStringUsingConstructor_ShouldBeEqual()
        {
            // Arrange
            const string userName = "Admin";

            Action action = () =>
            {
                // Act
                var userNames = Enumerable.Range(0, 10).Select(x => new UserName(userName))
                    .Aggregate((x, y) => x.Equals(y) ? y : throw new Exception());
            };

            // Assert
            action.Should().NotThrow("UserName value object should check equality based on value.");
        }

        [Fact]
        public void AllUserNameValueObjects_CreatedFromSameUserNameStringUsingForMethod_ShouldBeEqual()
        {
            // Arrange
            const string userName = "Admin";

            Action action = () =>
            {
                // Act
                var userNames = Enumerable.Range(0, 10).Select(x => UserName.For(userName))
                    .Aggregate((x, y) => x.Equals(y) ? y : throw new Exception());
            };

            // Assert
            action.Should().NotThrow("UserName value object should check equality based on value.");
        }
    }
}