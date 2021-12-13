using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Matches.Queries.GetMatchesWithPagination;
using Web.Controllers;
using Application.Matches;
using Application.Matches.Commands;
using Application.Matches.Commands.UpdateMatch;
using Application.Matches.Commands.DeleteMatch;

namespace VGDemoAPIApp.WebUI.Controllers
{
   // [Authorize]
    public class MatchController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<MatchDto>>> GetMatchesWithPagination([FromQuery] GetMatchesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMatchCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok($"New Match created with id: {id}");
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateMatchOddCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Ok("Entity is updated successfully");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMatchOddCommand { Id = id });

            return Ok("Entity is deleted Successfully");
        }
    }
}
