using BancoKrt.Application.UseCases.Customer.Delete;
using BancoKrt.Application.UseCases.Customer.GetAll;
using BancoKrt.Application.UseCases.Customer.GetById;
using BancoKrt.Application.UseCases.Customer.Register;
using BancoKrt.Application.UseCases.Customer.Update;
using BancoKrt.Domain.Request.Customer;
using BancoKrt.Domain.Response.Customer;
using BancoKrt.Domain.Response.Error;
using Microsoft.AspNetCore.Mvc;

namespace BancoKrt.Api.Controllers;

/// <summary>
/// Controller responsible for manage data regarding customer
/// </summary>
[Route("v1/api/customer")]
[ApiController]
public class CustomerController : ControllerBase
{

    /// <summary>
    /// Create a costumer in our database
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreatedCustomerResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddAsync(
        [FromServices] ICreateCustomerUseCase useCase,
        [FromBody] CreateCustomerRequest req)
    {
        var response = await useCase.ExecuteAsync(req);

        return CreatedAtAction("", response);
    }

    /// <summary>
    /// Get all customers
    /// </summary>
    /// <param name="useCase"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(CustomerResponseList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllAsync([FromServices] IGetAllCustomerUseCase useCase)
    {
        var response = await useCase.ExecuteAsync();

        if (response.Customers.Count != 0)
            return Ok(response);

        return NoContent();
    }

    /// <summary>
    /// Get a costumer by id
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(CreatedCustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] IGetByIdCustomerUseCase useCase,
        string id)
    {
        var response = await useCase.ExecuteAsync(id);

        if (response is not null)
            return Ok(response);

        return BadRequest();
    }

    /// <summary>
    /// Get a customer by account number
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("account-number/{id}")]
    [ProducesResponseType(typeof(CreatedCustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByAccountAsync(
        [FromServices] IGetByAccountCustomerUseCase useCase,
        string id)
    {
        var response = await useCase.ExecuteAsync(id);

        if (response is not null)
            return Ok(response);

        return BadRequest();
    }

    /// <summary>
    /// Update customer transaction limit
    /// </summary>
    /// <param name="id"></param>
    /// <param name="req"></param>
    /// <param name="useCase"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(CreatedCustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] string id,
        [FromBody] UpdateCustomerRequest req,
        [FromServices] IUpdateCustomerUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(id, req);

        return Ok(response);
    }


    /// <summary>
    /// Delete a customer
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteCustomerUseCase useCase, [FromRoute] string id)
    {
        await useCase.ExecuteAsync(id);

        return NoContent();
    }
}
