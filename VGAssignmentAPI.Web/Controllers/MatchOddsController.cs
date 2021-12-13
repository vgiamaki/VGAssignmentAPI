using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Matches.Queries.GetMatchesWithPagination;
using Web.Controllers;
using Application.Matches.Commands;
using Application.Matches.Commands.UpdateMatch;
using Application.Matches.Commands.DeleteMatch;
using Application.MatchOdds;
using System.Collections.Generic;
using Application.MatchOdds.Queries;

namespace VGDemoAPIApp.WebUI.Controllers
{
   // [Authorize]
    public class MatchOddsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetMatchOdds([FromQuery] GetMatchOddsQuery query)
        {
            var list = await Mediator.Send(query);
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMatchOddCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok($"New Match Odd created with id: {id}");
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
