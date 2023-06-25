using Albuns.Aplicacao.Commando.AdicionarAlbum;
using Albuns.Aplicacao.Commando.ApagarAlbum;
using Albuns.Aplicacao.Commando.AtualizarAlbum;
using Albuns.Aplicacao.Query.ObterAlbumPorId;
using Albuns.Aplicacao.Query.ObterAlbuns;
using Albuns.Domain.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Albuns.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbunsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbunsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAlbum([FromBody] AdicionarAlbumCommand command)
        {
            bool success = await _mediator.Send(command);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ApagarAlbum(Guid id)
        {
            var command = new ApagarAlbumCommand { Id = id };
            bool success = await _mediator.Send(command);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAlbum(Guid id, [FromBody] AtualizarAlbumCommand command)
        {
            command.Id = id;
            bool success = await _mediator.Send(command);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> ObterAlbumPorId(Guid id)
        {
            var query = new ObterAlbumPorIdQuery { Id = id };
            var album = await _mediator.Send(query);
            if (album != null)
            {
                return Ok(album);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> ObterAlbuns()
        {
            var query = new ObterAlbunsQuery();
            var albuns = await _mediator.Send(query);
            return Ok(albuns);
        }
    }
}

