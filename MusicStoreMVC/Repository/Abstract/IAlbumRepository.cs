﻿using System.Linq;
using Model.Entities;

namespace Repository.Abstract
{
    public interface IAlbumRepository
    {
        IQueryable<Album> Albums { get; }
    }
}
