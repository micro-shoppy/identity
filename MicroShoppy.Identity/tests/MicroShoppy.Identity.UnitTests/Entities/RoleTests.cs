using System;
using FluentAssertions;
using MicroShoppy.Identity.Domain.Entities;
using Xunit;

namespace MicroShoppy.Identity.UnitTests.Entities
{
    [Collection("UsingPasswordStaticMethodsTests")]
    public class RoleTests
    {
        [Fact]
        public void CreatingRole_WithNullRoleName_ShouldThrowArgumentNullException()
        {
            // Arrange
            Action action = () =>
            {
                // Act
                var role = new Role(
                    Guid.NewGuid(),
                    DateTime.UtcNow,
                    null);
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}