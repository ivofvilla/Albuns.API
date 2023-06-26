﻿using Albuns.Aplicacao.Commando.AdicionarAlbum;
using Albuns.Aplicacao.Commando.ApagarAlbum;
using Albuns.Aplicacao.Commando.AtualizarAlbum;
using Albuns.Aplicacao.Query.ObterAlbumPorId;
using Albuns.Aplicacao.Query.ObterAlbuns;
using Albuns.Domain.Entidades;
using Azure.Storage.Blobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Albuns.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbunsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AlbunsController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAlbum([FromForm] AdicionarAlbumCommand command)
        {
            string caminhoArquivo = string.Empty;
            var arquivo = Request.Form.Files.FirstOrDefault();

            //azure
            var conexao = _configuration.GetSection("ContainerAzure:NomeContainer").Value;
            var container = _configuration.GetSection("ContainerAzure:ConectionString").Value;

            var blob = new BlobClient(conexao, container, $"{DateTime.Now.Ticks}_{arquivo.FileName}");
            using (var ms = new MemoryStream(GeraArrayBytes(command.Arquivo.OpenReadStream())))
            {
                blob.Upload(ms);
            }

            //local
            //if (arquivo != null && arquivo.Length > 0)
            //{
            //    caminhoArquivo = Path.Combine("D:\\ZZZ_teste", $"{DateTime.Now.Ticks}_{arquivo.FileName}");
            //    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
            //    {
            //        await arquivo.CopyToAsync(stream);
            //    }
            //}

            //command.SetCaminhoImagem(blob.Uri.AbsoluteUri);
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
            command.SetId(id);
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
        private byte[] GeraArrayBytes(Stream stream)
        {
            byte[] result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                result = ms.ToArray();
            }
            return result;
        }
    }
}

