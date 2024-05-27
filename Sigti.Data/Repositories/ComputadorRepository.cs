using Flunt.Notifications;
using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using Sigti.Core.Repositories;
using Sigti.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Data.Repositories
{
    public class ComputadorRepository : GenericRepository<Computador>, IComputadorRepository
    {
        public ComputadorRepository(SigtiContext context) : base(context)
        {
        }
    }
}
