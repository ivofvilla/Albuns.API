﻿using Albuns.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Query.ObterAlbumPorId
{
    public class ObterAlbumPorIdQuery : IRequest<Album>
    {
        public Guid Id { get; set; }
    }
}
