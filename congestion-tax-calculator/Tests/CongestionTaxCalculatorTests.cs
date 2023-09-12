using congestion.calculator;
using CongestionCalculator;
using Tests;
using Xunit;

public class CongestionTaxCalculatorTests
{
    [Fact]
    public void GetTax_WithNoPasses_ReturnsZero()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car();
        var dateTimes = new List<DateTime>();

        // Act
        var result = calculator.GetTax(vehicle, dateTimes);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetTax_WithTollFreeVehicle_ReturnsZero()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Motorbike();
        var dateTimes = new List<DateTime> {
            new DateTime(2023, 9, 12, 8, 0, 0),
        new DateTime(2023, 9, 12, 8, 20, 0)};

        // Act
        var result = calculator.GetTax(vehicle, dateTimes);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetTax_WithTollableVehicle_ReturnsNonZero()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car();
        var dateTimes = new List<DateTime> { new DateTime(2013, 9, 12, 8, 0, 0),
        new DateTime(2013, 9, 12, 8, 20, 0),};

        // Act
        var result = calculator.GetTax(vehicle, dateTimes);

        // Assert
        Assert.Equal(13, result);
    }

    [Fact]
    public void GetTax_WithTollableVehicleInOneDay_Returns60()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car();
        var dateTimes = DateTimeCreator.GetMoreThan60TaxDateTimes();

        // Act
        decimal result = calculator.GetTax(vehicle, dateTimes);
        decimal expected = 60;
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetTax_WithTollableVehicleInOneDay_ReturnsLessThan60()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car();
        var dateTimes = DateTimeCreator.GetLessThan60TaxDateTimes();

        // Act
        decimal result = calculator.GetTax(vehicle, dateTimes);
        decimal expected = 47;
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetTax_WithTollableVehicleInTwoDay_ReturnsNonZero()
    {
        // Arrange
        var calculator = new CongestionTaxCalculator();
        var vehicle = new Car();
        var dateTimes = DateTimeCreator.GetLessThan60TaxDateTimes();
        dateTimes.AddRange(DateTimeCreator.GetMoreThan60TaxDateTimes());

        // Act
        decimal result = calculator.GetTax(vehicle, dateTimes);
        decimal expected = 107;
        // Assert
        Assert.Equal(expected, result);
    }

}
