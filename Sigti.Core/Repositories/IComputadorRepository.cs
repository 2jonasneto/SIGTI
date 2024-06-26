﻿using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Repositories
{
    public interface IComputadorRepository:IGenericRepository<Computador>
    {
        Task<List<Computador>> GetAllByGrid();
    }
}
