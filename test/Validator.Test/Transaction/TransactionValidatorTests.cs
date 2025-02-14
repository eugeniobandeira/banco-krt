using BancoKrt.Application.UseCases.Transaction;
using BancoKrt.Exception.MessageResource;
using CommomTestUtilities.Request.Transaction;
using FluentValidation.TestHelper;

namespace Validator.Test.Transaction;

public class TransactionValidatorTests
{
    private readonly TransactionValidator _validator;

    public TransactionValidatorTests()
    {
        _validator = new TransactionValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Receiver_Is_Null()
    {
        // Arrange
        var req = TransactionRequestBuilder.Build();
        req.Receiver = null;

        // Act
        var result = _validator.TestValidate(req);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Receiver)
              .WithErrorMessage(ErrorMessageResource.RECEIVER_REQUIRED);
    }

    [Fact]
    public void Should_Have_Error_When_Amount_Is_Zero()
    {
        // Arrange
        var req = TransactionRequestBuilder.Build();
        req.Amount = 0;

        // Act
        var result = _validator.TestValidate(req);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Amount)
              .WithErrorMessage(ErrorMessageResource.AMOUNT_GREATER_THAN_ZERO);
    }

    [Fact]
    public void Should_Have_Error_When_Balance_Is_Insufficient()
    {
        // Arrange
        var req = TransactionRequestBuilder.Build();
        req.Sender.TransactionLimit = 500;
        req.Sender.Balance = 50;
        req.Amount = 100;

        // Act
        var result = _validator.TestValidate(req);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Amount)
              .WithErrorMessage(ErrorMessageResource.INSUFFICIENT_FUNDS);
    }

    [Fact]
    public void Should_Have_Error_When_Amount_Exceeds_TransactionLimit()
    {
        // Arrange
        var req = TransactionRequestBuilder.Build();
        req.Sender.TransactionLimit = 500;
        req.Sender.Balance = 1000;
        req.Amount = 550;

        // Act
        var result = _validator.TestValidate(req);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Amount)
              .WithErrorMessage(ErrorMessageResource.TRANSACTION_AMOUNT_NOT_ALLOWED);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Request_Is_Valid()
    {
        // Arrange
        var req = TransactionRequestBuilder.Build();

        // Act
        var result = _validator.TestValidate(req);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}