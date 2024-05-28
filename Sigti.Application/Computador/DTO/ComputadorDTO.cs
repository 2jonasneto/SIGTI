using Sigti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.DTO
{
    public class ComputadorDTO:IDTO
    {
        public Guid Id { get;  set; }
        public bool Ativo { get;  set; }
        public string ModificadoPor { get;  set; }
        public DateTime DataModificacao { get;  set; }
        public string HostName { get;  set; }
        public string Processador { get;  set; }
        public string Memoria { get;  set; }
        public string Disco { get;  set; }
        public string Ip { get;  set; }
        public string Anydesk { get;  set; }
        public string Grupos { get;  set; }
        public string UltimoUsuarioLogado { get;  set; }
        public string Patrimonio { get;  set; }
        public string SistemaOperacional { get;  set; }
        public Guid SetorId { get;  set; }
        public Guid LocalizacaoId { get;  set; }
        public string Observacao { get;  set; }
    }
}
