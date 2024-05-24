using Sigti.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Entities
{
    public sealed class Impressora:Entity
    {
        public Impressora(string modelo, string patrimonio,
            bool alugado, Guid setorId, Guid localizacaoId,
            string observacao, string ip, ETipoConexaoImpressora conexao,
            ETipoImpressora tipo,string modificadoPor)
        {
            Modelo = modelo;
            Patrimonio = patrimonio;
            Alugado = alugado;
            SetorId = setorId;
            LocalizacaoId = localizacaoId;
            Observacao = observacao;
            Ip = ip;
            Conexao = conexao;
            Tipo = tipo;
            ModificadoPor = modificadoPor;
        }
        public void Atualizar(string modelo, string patrimonio,
            bool alugado, Guid setorId, Guid localizacaoId,
            string observacao, string ip, ETipoConexaoImpressora conexao,
            ETipoImpressora tipo, string modificadoPor)
        {
            Modelo = modelo;
            Patrimonio = patrimonio;
            Alugado = alugado;
            SetorId = setorId;
            LocalizacaoId = localizacaoId;
            Observacao = observacao;
            Ip = ip;
            Conexao = conexao;
            Tipo = tipo;
            ModificadoPor = modificadoPor;
        }

        public string Modelo { get; private set; }
        public string Patrimonio { get; private set; }
        public bool Alugado { get; private set; }
        public Guid SetorId { get; private set; }
        public Guid LocalizacaoId { get; private set; }
        public string Observacao { get; private set; }
        public string Ip { get; private set; }
        public ETipoConexaoImpressora Conexao { get; private set; }
        public ETipoImpressora Tipo { get; private set; }


        public Setor Setor { get; set; }
        public Localizacao localizacao { get; set; }
    }

}
