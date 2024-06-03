namespace Sigti.Core.Entities
{
    public sealed class Controladora : Entity
    {
        public Controladora(string nome, string descricao, Guid localizacaoId, string modificadoPor, Guid setorId)
        {
            Nome = nome;
            Descricao = descricao;
            LocalizacaoId = localizacaoId;
            ModificadoPor = modificadoPor;
            SetorId = setorId;
        }
        public void Atualizar(string nome, string descricao, Guid localizacaoId, string modificadoPor, Guid setorId)
        {
            Nome = nome;
            Descricao = descricao;
            LocalizacaoId = localizacaoId;
            ModificadoPor = modificadoPor;
            DataModificacao = DateTime.Now;
        }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Guid LocalizacaoId { get; private set; }
        public Guid SetorId { get; private set; }


       
        public Localizacao Localizacao { get;  }
        public Setor Setor { get;  }
        public ICollection<AcessoControladora> AcessoControladoras { get;  }

    }
}
