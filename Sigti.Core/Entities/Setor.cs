﻿namespace Sigti.Core.Entities
{
    public sealed class Setor : Entity
    {
        public Setor(string nome, string descricao, Guid localizacaoId,string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            LocalizacaoId = localizacaoId;
            ModificadoPor = modificadoPor;
        }
        public void Atualizar(string nome, string descricao, Guid localizacaoId, string modificadoPor)
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


        public ICollection<Computador> Computadores { get;  }
        public ICollection<Impressora> Impressoras { get;  }
        public ICollection<AcessoControladora> AcessoControladoras { get;  }
        public ICollection<Controladora> Controladoras { get;  }
        public Localizacao Localizacao { get;  }
    }
}
