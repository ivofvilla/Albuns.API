using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Commando.AtualizarAlbum
{
    public class AtualizarAlbumCommand
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Banda { get; set; }
        public int QuantidadeFaixas { get; set; }
        public bool Duplo { get; set; }
    }
}
