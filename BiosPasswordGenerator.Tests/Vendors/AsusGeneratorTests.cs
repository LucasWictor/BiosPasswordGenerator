using BiosPasswordGenerator.Vendors;
using FluentAssertions;
using Xunit;

namespace BiosPasswordGenerator.Tests.Vendors;

public class AsusGeneratorTests
{
    [Fact]
    public void GeneratePassword_WithValidDate_ReturnsExpectedPassword()
    {
        // Arrange
        var year = 2022;
        var month = 5;
        var day = 15;

        // Act
        string password = AsusGenerator.GeneratePassword(year, month, day);

        // Assert
        password.Should().NotBeNullOrEmpty(); // Password cant not be null or empty
        password.Length.Should().Be(8); // Password = 8 characters
    }

    [Xunit.Theory]
    [InlineData(2022, 5, 15)]
    [InlineData(1995, 12, 31)]
    [InlineData(2100, 1, 1)]
    public void GeneratePassword_WithVariousDates_ReturnsPasswordsOfCorrectLength(int year, int month, int day)
    {
        // Act
        string password = AsusGenerator.GeneratePassword(year, month, day);

        // Assert
        password.Should().NotBeNullOrEmpty(); // Password cant not be null or empty
        password.Length.Should().Be(8); // Password = 8 characters
    }

    [Fact]
    public void GeneratePassword_WithInvalidDate_ShouldThrowException()
    {
        // Arrange
        var year = -1;
        var month = 0;
        var day = 32;

        // Act & Assert
        Action act = () => AsusGenerator.GeneratePassword(year, month, day);
        act.Should().Throw<ArgumentException>("Invalid date inputs should throw an exception");
    }
}