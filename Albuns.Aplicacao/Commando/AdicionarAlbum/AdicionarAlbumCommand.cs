using MediatR;

namespace Albuns.Aplicacao.Commando.AdicionarAlbum
{
    public class AdicionarAlbumCommand : IRequest<bool>
    {
        public string Titulo { get; set; }
        public string Banda { get; set; }
        public int QuantidadeFaixas { get; set; }
        public bool Duplo { get; set; }
        public string CaminhoImagem { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

    }
}
