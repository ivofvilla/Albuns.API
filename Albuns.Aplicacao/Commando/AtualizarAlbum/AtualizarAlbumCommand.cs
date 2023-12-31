﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Commando.AtualizarAlbum
{
    public class AtualizarAlbumCommand : IRequest<bool>
    {
        public Guid Id { get; private set; }
        public string Titulo { get; set; }
        public string Banda { get; set; }
        public int QuantidadeFaixas { get; set; }
        public bool Duplo { get; set; }
        public string CaminhoImagem { get; set; }
        public void SetId(Guid id) => Id = id;
    }
}
