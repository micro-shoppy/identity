using System;
using System.Linq;
using FluentAssertions;
using MicroShoppy.Identity.Domain.Exceptions;
using MicroShoppy.Identity.Domain.ValueObjects;
using Xunit;

namespace MicroShoppy.Identity.UnitTests.ValueObjects
{
    public class RoleNameTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreatingRoleNameUsingConstructor_WithInvalidValue_ShouldThrowInvalidRoleNameException(
            string roleName)
        {
            //Arrange
            Action action = () =>
            {
                // Act
                var roleNameVO = new RoleName(roleName);
            };

            // Assert
            action.Should().Throw<InvalidRoleNameException>("invalid role name is used.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreatingRoleNameUsingForMethod_WithInvalidValue_ShouldThrowInvalidRoleNameException(
            string roleName)
        {
            //Arrange
            Action action = () =>
            {
                // Act
                var roleNameVO = RoleName.For(roleName);
            };

            // Assert
            action.Should().Throw<InvalidRoleNameException>("invalid role name is used.");
        }

        [Fact]
        public void AllRoleNameValueObjects_CreatedFromSameRoleNameStringUsingConstructor_ShouldBeEqual()
        {
            // Arrange
            const string roleName = "Admin";

            Action action = () =>
            {
                // Act
                var roleNames = Enumerable.Range(0, 10).Select(x => new RoleName(roleName))
                    .Aggregate((x, y) => x.Equals(y) ? y : throw new Exception());
            };

            // Assert
            action.Should().NotThrow("RoleName value object should check equality based on value.");
        }

        [Fact]
        public void AllRoleNameValueObjects_CreatedFromSameRoleNameStringUsingForMethod_ShouldBeEqual()
        {
            // Arrange
            const string roleName = "Admin";

            Action action = () =>
            {
                // Act
                var roleNames = Enumerable.Range(0, 10).Select(x => RoleName.For(roleName))
                    .Aggregate((x, y) => x.Equals(y) ? y : throw new Exception());
            };

            // Assert
            action.Should().NotThrow("RoleName value object should check equality based on value.");
        }
    }
}