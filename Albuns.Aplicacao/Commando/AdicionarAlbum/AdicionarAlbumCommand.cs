using MediatR;
using Microsoft.AspNetCore.Http;

namespace Albuns.Aplicacao.Commando.AdicionarAlbum
{
    public class AdicionarAlbumCommand : IRequest<bool>
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public int QuantidadeFaixas { get; set; }
        public bool Duplo { get; set; }
        public string CaminhoImagem { get; private set; }
        public IFormFile Arquivo { get; set; }

        public void SetCaminhoImagem(string caminhoImagem) => CaminhoImagem = caminhoImagem;

    }
}
