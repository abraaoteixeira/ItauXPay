using Xunit;
using ItauXPay.Controllers;
using ItauXPay.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ItauXPay.Data;

public class PaymentsControllerTests
{
    [Fact]
    public async Task CreatePayment_ShouldReturnCreatedPayment()
    {
        // Arrange
        var mockContext = new Mock<PaymentContext>();
        var mockService = new Mock<ItauPaymentService>();
        var controller = new PaymentsController(mockContext.Object, mockService.Object);

        var payment = new Payment
        {
            PayerName = "John Doe",
            Amount = 100.50M,
            Status = "Processing"
        };

        // Act
        var result = await controller.CreatePayment(payment) as CreatedAtActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Processing", payment.Status);
    }
}