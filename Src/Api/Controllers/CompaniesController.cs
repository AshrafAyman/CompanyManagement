using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetAll;
using Application.Features.Companies.Queries.GeyById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class CompaniesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand command)
            => Ok(await Mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCompanyCommand command)
            => Ok(await Mediator.Send(command));

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCompaniesQuery query)
            => Ok(await Mediator.Send(query));

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetCompanyByIdQuery query)
            => Ok(await Mediator.Send(query));
    }
}
