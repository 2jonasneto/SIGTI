using Sigti.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Entities
{
    public sealed class Servidor : Entity
    {
        public Servidor(string nome, string usuario, string senha, Guid setorId,
            Guid localizacaoId, string observacao, string ip, ETipoServidor tipo, string modificadoPor)
        {
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            SetorId = setorId;
            LocalizacaoId = localizacaoId;
            Observacao = observacao;
            Ip = ip;
            Tipo = tipo;
            ModificadoPor = modificadoPor;
        }
        public void Atualizar(string nome, string usuario, string senha, Guid setorId,
            Guid localizacaoId, string observacao, string ip, ETipoServidor tipo,string modificadoPor)
        {
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            SetorId = setorId;
            LocalizacaoId = localizacaoId;
            Observacao = observacao;
            Ip = ip;
            Tipo = tipo;
            ModificadoPor = modificadoPor;
        }

        public string Nome { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public Guid SetorId { get; private set; }
        public Guid LocalizacaoId { get; private set; }
        public string Observacao { get; private set; }
        public string Ip { get; private set; }
        public ETipoServidor Tipo { get; private set; }


        public Setor Setor { get; set; }
        public Localizacao Localizacao { get; set; }
    }
}
