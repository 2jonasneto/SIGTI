using Sigti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application
{
   
     public record AdicionarComputadorCommand(string hostName, string processador, string memoria,
            string disco, string ip, string anydesk, string grupos,
            string ultimoUsuarioLogado, string patrimonio, string sistemaOperacional,
            string modificadoPor, Guid setorId, Guid localizacaoId, string observacao) : ICommand;


    public record AtualizarComputadorCommand(string hostName, string processador, string memoria,
           string disco, string ip, string anydesk, string grupos,
           string ultimoUsuarioLogado, string patrimonio, string sistemaOperacional,
           string modificadoPor, Guid setorId, Guid localizacaoId, string observacao) : ICommand;
}
