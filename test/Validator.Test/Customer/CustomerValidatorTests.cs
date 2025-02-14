using BancoKrt.Application.UseCases.Customer;
using BancoKrt.Exception.MessageResource;
using CommomTestUtilities.Request.Customer;
using FluentAssertions;

namespace Validator.Test.Customer;

public class CustomerValidatorTests
{
    [Fact]
    public void Should_Pass_When_All_Fields_Are_Valid()
    {
        //Arrange
        var validator = new CustomerValidator();
        var req = CreateCustomerRequestBuilder.Build();

        //Act
        var result = validator.Validate(req);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Should_Return_Error_When_Name_Is_Empty(string name)
    {
        //Assert
        var validator = new CustomerValidator();
        var req = CreateCustomerRequestBuilder.Build();
        req.Name = name;

        //Act
        var result = validator.Validate(req);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors
            .Should()
            .ContainSingle()
            .And
            .Contain(e => e.ErrorMessage
                .Equals(ErrorMessageResource.NAME_REQUIRED));
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Should_Return_Error_When_Document_Is_Empty(string document)
    {
        //Assert
        var validator = new CustomerValidator();
        var req = CreateCustomerRequestBuilder.Build();
        req.Document = document;

        //Act
        var result = validator.Validate(req);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors
            .Should()
            .ContainSingle()
            .And
            .Contain(e => e.ErrorMessage
                .Equals(ErrorMessageResource.DOCUMENT_REQUIRED));
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Should_Return_Error_When_AgencyNumber_Is_Empty(string agency)
    {
        //Assert
        var validator = new CustomerValidator();
        var req = CreateCustomerRequestBuilder.Build();
        req.AgencyNumber = agency;

        //Act
        var result = validator.Validate(req);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors
            .Should()
            .ContainSingle()
            .And
            .Contain(e => e.ErrorMessage
                .Equals(ErrorMessageResource.AGENCY_NUMBER_REQUIRED));
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Should_Return_Error_When_AccountNumber_Is_Empty(string accountNumber)
    {
        //Assert
        var validator = new CustomerValidator();
        var req = CreateCustomerRequestBuilder.Build();
        req.AccountNumber = accountNumber;

        //Act
        var result = validator.Validate(req);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors
            .Should()
            .ContainSingle()
            .And
            .Contain(e => e.ErrorMessage
                .Equals(ErrorMessageResource.ACCOUNT_NUMBER_REQUIRED));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(0.00)]
    [InlineData(-1)]
    public void Should_Return_Error_When_Balance_Is_Invalid(decimal balance)
    {
        //Assert
        var validator = new CustomerValidator();
        var req = CreateCustomerRequestBuilder.Build();
        req.Balance = balance;

        //Act
        var result = validator.Validate(req);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors
            .Should()
            .Contain(e => e.ErrorMessage
                .Equals(ErrorMessageResource.BALANCE_REQUIRED));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(0.00)]
    [InlineData(-1)]
    public void Should_Return_Error_When_TransactionLimit_Is_Invalid(decimal transactionLimit)
    {
        //Assert
        var validator = new CustomerValidator();
        var req = CreateCustomerRequestBuilder.Build();
        req.TransactionLimit = transactionLimit;

        //Act
        var result = validator.Validate(req);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors
            .Should()
            .Contain(e => e.ErrorMessage
                .Equals(ErrorMessageResource.TRANSACTION_LIMIT_REQUIRED));
    }
}
