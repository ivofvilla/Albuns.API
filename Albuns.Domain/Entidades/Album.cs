
namespace Albuns.Domain.Entidades
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public int QuantidadeFaixas { get; set; }
        public bool Duplo { get; set; }
        public string CaminhoImagem { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
