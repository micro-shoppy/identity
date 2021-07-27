using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MicroShoppy.Identity.Domain.Exceptions;
using MicroShoppy.Identity.Domain.ValueObjects;
using Xunit;

namespace MicroShoppy.Identity.UnitTests.ValueObjects
{
    public class EmailTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ab.com")]
        [InlineData("a#b.com")]
        [InlineData("a@@b.com")]
        public void CreatingEmailUsingConstructor_WithInvalidValue_ShouldThrowInvalidEmailException(string mail)
        {
            //Arrange
            Action action = () =>
            {
                // Act
                var email = new Email(mail);
            };

            // Assert
            action.Should().Throw<InvalidEmailException>("invalid email is used.");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ab.com")]
        [InlineData("a#b.com")]
        [InlineData("a@@b.com")]
        public void CreatingEmailUsingForMethod_WithInvalidValue_ShouldThrowInvalidEmailException(string mail)
        {
            //Arrange
            Action action = () =>
            {
                // Act
                var email = Email.For(mail);
            };

            // Assert
            action.Should().Throw<InvalidEmailException>("invalid email is used.");
        }

        [Fact]
        public void AllEmailValueObjects_CreatedFromSameEmailStringUsingConstructor_ShouldBeEqual()
        {
            // Arrange
            const string email = "test@domain.com";

            Action action = () =>
            {
                // Act
                var emails = Enumerable.Range(0, 10).Select(x => new Email(email))
                    .Aggregate((x, y) => x.Equals(y) ? y : throw new Exception());
            };

            // Assert
            action.Should().NotThrow("Email value object should check equality based on value.");
        }

        [Fact]
        public void AllEmailValueObjects_CreatedFromSameEmailStringUsingForMethod_ShouldBeEqual()
        {
            // Arrange
            const string email = "test@domain.com";

            Action action = () =>
            {
                // Act
                var emails = Enumerable.Range(0, 10).Select(x => Email.For(email))
                    .Aggregate((x, y) => x.Equals(y) ? y : throw new Exception());
            };

            // Assert
            action.Should().NotThrow("Email value object should check equality based on value.");
        }
    }
}
