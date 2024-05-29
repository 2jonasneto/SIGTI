using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;

namespace Sigti.Data.Repositories
{
    public class LocalizacaoRepository : GenericRepository<Localizacao>, ILocalizacaoRepository
    {
        public LocalizacaoRepository(SigtiContext context) : base(context)
        {
        }
    }
}
