using Application.Features.Branches.Commands.Delete;
using Application.Features.Branches.Commands.Update;
using Application.Features.Branches.Queries.GetAll;
using Application.Features.Branches.Queries.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class BranchesController : BaseController
    {
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBranchCommand command)
            => Ok(await Mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBranchCommand command)
            => Ok(await Mediator.Send(command));

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBranchesQuery query)
            => Ok(await Mediator.Send(query));

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetBranchByIdQuery query)
            => Ok(await Mediator.Send(query));
    }
}
