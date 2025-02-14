using BancoKrt.Application.UseCases.Transaction.Create;
using BancoKrt.Domain.Request.Transaction;
using BancoKrt.Domain.Response.Customer;
using BancoKrt.Domain.Response.Error;
using Microsoft.AspNetCore.Mvc;

namespace BancoKrt.Api.Controllers;
[Route("v1/api/transaction")]
[ApiController]
public class TransactionController : ControllerBase
{
    [HttpPut]
    [ProducesResponseType(typeof(CreatedCustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ProcessAsync(
        TransacionRequest req,
        [FromServices] ICreateTransactionUseCase useCase)
    {
        await useCase.ExecuteAsync(req.Sender, req.Amount, req.Receiver);

        return Ok();
    }
}