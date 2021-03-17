using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using midTerm.Models.Models;
using midTerm.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace midTerm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SurveyUserController : ControllerBase
    {
        private readonly ISurveyUserService _service;

        public SurveyUserController(ISurveyUserService service)
        {
           _service = service;
        }

        [HttpGet("/SurveyUsers/{id:int}", Name = nameof(GetSurveyUser))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SurveyUserModelExtended))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSurveyUser([FromRoute] int id)
        {
            var result = await _service.Get(id);
            return result != null
                ? (IActionResult)Ok(result)
                : NoContent();
        }

        [HttpGet("/SurveyUsers", Name = nameof(GetAllSurveyUsers))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyUserModelBase>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllSurveyUsers()
        {
            var result = await _service.Get();
            return result != null && result.Any()
                ? (IActionResult)Ok(result)
                : NoContent();
        }

        [HttpPost("", Name = nameof(PostSurveyUser))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostSurveyUser([FromBody] SurveyUserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var item = await _service.Insert(model);

                if (item != null)
                {
                    return CreatedAtRoute(nameof(GetSurveyUser), item, item.Id);
                }
                return Conflict();
            }
            return UnprocessableEntity(ModelState);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SurveyUserModelBase))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] SurveyUserUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;
                var result = await _service.Update(model);

                return result != null
                    ? (IActionResult)Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _service.Delete(id));
            }
            return BadRequest();
        }
    }
}
